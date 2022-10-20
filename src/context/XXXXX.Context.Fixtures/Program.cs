using System;
using System.IO;
using System.Linq;
using XXXXX.Context.Core.DTOs;
using XXXXX.Context.Migrations.Shared;

namespace XXXXX.Context.Fixtures {
    class Program {
        private static string FixtureFolderPath => Path.GetFullPath("./Fixtures");
        
        static void Main(string[] args) {
            Console.WriteLine("Generating fixtures...");

            BuildPermissionFixtures();
            BuildPermissionCategoryFixtures();
            BuildPermissionAdminFixtures();
            BuildPermissionAdminCategoryFixtures();
            BuildTranslationFixtures();

            Console.WriteLine("Fixtures generated.");
        }

        private static void BuildPermissionFixtures()
        {
            var fixtureProvider = new XmlFixturesProvider<PermissionDTO>(FixtureFolderPath);
            var applicationPermissions = ApplicationPermissionProvider.GetAllShellPermissions();
            var fixturePermissions = fixtureProvider.GetAll();

            var toAdd = applicationPermissions
                .Select(permission => permission.Key)
                .Except(fixturePermissions.Select(permission => permission.Code))
                .ToList();
            var toKeep = fixturePermissions
                .Where(permission => (
                    applicationPermissions.ContainsKey(permission.Code) &&
                    PermissionNameToLabel(applicationPermissions[permission.Code]) == permission.LabelDefault
                ))
                .ToList();
            var toUpdate = fixturePermissions
                .Where(permission => (
                    applicationPermissions.ContainsKey(permission.Code) &&
                    PermissionNameToLabel(applicationPermissions[permission.Code]) != permission.LabelDefault
                ))
                .ToList();

            fixtureProvider.Persist(
                toAdd.Select(permissionKey => new PermissionDTO() {
                    Id = Guid.NewGuid(),
                    Code = permissionKey,
                    LabelDefault = PermissionNameToLabel(applicationPermissions[permissionKey])
                })
                .Concat(toUpdate.Select(permission => new PermissionDTO() {
                    Id = permission.Id,
                    Code = permission.Code,
                    LabelDefault = PermissionNameToLabel(applicationPermissions[permission.Code])
                }))
                .Concat(toKeep)
                .OrderBy(permission => permission.Code)
            );
        }

        private static void BuildPermissionCategoryFixtures()
        {
            var fixtureProvider = new XmlFixturesProvider<PermissionCategoryDTO>(FixtureFolderPath);
            var applicationCategories = ApplicationPermissionProvider.GetAllShellCategories();
            var fixtureCategories = fixtureProvider.GetAll();

            var toAdd = applicationCategories
                .Except(fixtureCategories.Select(category => category.Code))
                .ToList();
            var toKeep = fixtureCategories
                .Where(category => applicationCategories.Contains(category.Code))
                .ToList();
            // toupdate is unnecessary here since everything is generated from the code

            fixtureProvider.Persist(
                toAdd.Select(categoryCode => new PermissionCategoryDTO() {
                    Id = Guid.NewGuid(),
                    Code = categoryCode,
                    LabelDefault = categoryCode.Replace(".", " ").ToLower(),
                    Prefix = categoryCode + "."
                })
                .Concat(toKeep)
                .OrderBy(category => category.Code)
            );
        }


        private static void BuildPermissionAdminFixtures()
        {
            var fixtureProvider = new XmlFixturesProvider<PermissionAdminDTO>(FixtureFolderPath);
            var applicationPermissionAdmins = ApplicationPermissionProvider.GetAllAdminPermissions();
            var fixturePermissions = fixtureProvider.GetAll();

            var toAdd = applicationPermissionAdmins
                .Select(permission => permission.Key)
                .Except(fixturePermissions.Select(permission => permission.Code))
                .ToList();
            var toKeep = fixturePermissions
                .Where(permission => (
                    applicationPermissionAdmins.ContainsKey(permission.Code) &&
                    PermissionNameToLabel(applicationPermissionAdmins[permission.Code]) == permission.LabelDefault
                ))
                .ToList();
            var toUpdate = fixturePermissions
                .Where(permission => (
                    applicationPermissionAdmins.ContainsKey(permission.Code) &&
                    PermissionNameToLabel(applicationPermissionAdmins[permission.Code]) != permission.LabelDefault
                ))
                .ToList();

            fixtureProvider.Persist(
                toAdd.Select(permissionKey => new PermissionAdminDTO() {
                    Id = Guid.NewGuid(),
                    Code = permissionKey,
                    LabelDefault = PermissionNameToLabel(applicationPermissionAdmins[permissionKey])
                })
                .Concat(toUpdate.Select(permission => new PermissionAdminDTO() {
                    Id = permission.Id,
                    Code = permission.Code,
                    LabelDefault = PermissionNameToLabel(applicationPermissionAdmins[permission.Code])
                }))
                .Concat(toKeep)
                .OrderBy(permission => permission.Code)
            );
        }

        private static void BuildPermissionAdminCategoryFixtures()
        {
            var fixtureProvider = new XmlFixturesProvider<PermissionAdminCategoryDTO>(FixtureFolderPath);
            var applicationAdminCategories = ApplicationPermissionProvider.GetAllAdminCategories();
            var fixtureCategories = fixtureProvider.GetAll();

            var toAdd = applicationAdminCategories
                .Except(fixtureCategories.Select(category => category.Code))
                .ToList();
            var toKeep = fixtureCategories
                .Where(category => applicationAdminCategories.Contains(category.Code))
                .ToList();
            // toupdate is unnecessary here since everything is generated from the code

            fixtureProvider.Persist(
                toAdd.Select(categoryCode => new PermissionAdminCategoryDTO() {
                    Id = Guid.NewGuid(),
                    Code = categoryCode,
                    LabelDefault = categoryCode.Replace(".", " ").ToLower(),
                    Prefix = categoryCode + "."
                })
                .Concat(toKeep)
                .OrderBy(category => category.Code)
            );
        }

        private static void BuildTranslationFixtures()
        {
            var fixtureProvider = new XmlFixturesProvider<TranslationDTO>(FixtureFolderPath);
            var translations = new TranslationProvider().GetAllTranslations();
            var fixtureTranslations = fixtureProvider.GetAll();

            var toAdd = translations
                .Select(translation => translation.Key)
                .Except(fixtureTranslations.Select(t => t.Code))
                .ToList();
            var toKeep = fixtureTranslations
                .Where(t => translations.ContainsKey(t.Code) && translations[t.Code] == t.ValueDefault)
                .ToList();
            var toUpdate = fixtureTranslations
                .Where(t => translations.ContainsKey(t.Code) && translations[t.Code] != t.ValueDefault)
                .ToList();

            fixtureProvider.Persist(
                toAdd.Select(translationCode => new TranslationDTO() {
                    Id = Guid.NewGuid(),
                    Code = translationCode,
                    ValueDefault = translations[translationCode],
                    Disabled = false
                })
                .Concat(toUpdate.Select(tr => new TranslationDTO() {
                    Id = tr.Id,
                    Code = tr.Code,
                    ValueDefault = translations[tr.Code],
                    Disabled = false
                }))
                .Concat(toKeep)
                .OrderBy(t => t.Code)
            );
        }


        private static string PermissionNameToLabel(string permissionName) {
            return permissionName.Replace("_", " ").ToLower();
        }
    }
}