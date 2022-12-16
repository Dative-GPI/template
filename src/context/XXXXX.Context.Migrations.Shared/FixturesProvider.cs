using System.Collections.Generic;
using System.IO;
using XXXXX.Context.Core.DTOs;

namespace XXXXX.Context.Migrations.Shared
{
    public class FixturesProvider
    {
        private readonly string _fixtureFolderPath;

        public FixturesProvider(string fixtureFolderPath)
        {
            this._fixtureFolderPath = fixtureFolderPath;
        }

        public IEnumerable<PermissionDTO> GetPermissions() => new XmlFixturesProvider<PermissionDTO>(
            GetFixtureFolderPath()).GetAll();
        public IEnumerable<PermissionCategoryDTO> GetPermissionCategories() => new XmlFixturesProvider<PermissionCategoryDTO>(
            GetFixtureFolderPath()).GetAll();
        public IEnumerable<PermissionAdminDTO> GetPermissionAdmins() => new XmlFixturesProvider<PermissionAdminDTO>(
            GetFixtureFolderPath()).GetAll();
        public IEnumerable<PermissionAdminCategoryDTO> GetPermissionAdminCategories() => new XmlFixturesProvider<PermissionAdminCategoryDTO>(
            GetFixtureFolderPath()).GetAll();

        public IEnumerable<TranslationDTO> GetTranslations() => new XmlFixturesProvider<TranslationDTO>(
            GetFixtureFolderPath()).GetAll();


        private string GetFixtureFolderPath() => Path.GetFullPath(_fixtureFolderPath);
        private string GetFixturePath(string file) => Path.Join(GetFixtureFolderPath(), file);
    }
}