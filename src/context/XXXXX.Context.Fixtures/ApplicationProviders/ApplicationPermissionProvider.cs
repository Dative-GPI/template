using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace XXXXX.Context.Fixtures
{
    public class ApplicationPermissionProvider
    {
        private static List<Type> ShellAuthorizations = new List<Type>() {
            typeof(XXXXX.Shell.Core.Authorizations),
        };
        private static List<Type> AdminAuthorizations = new List<Type>() {
            typeof(XXXXX.Admin.Core.Authorizations),
        };


        public static Dictionary<string, string> GetAllShellPermissions()
        {
            return GeneratePermissions(ShellAuthorizations);
        }

        public static List<string> GetAllShellCategories()
        {
            var permissions = GetAllShellPermissions();
            return GenerateCategories(permissions);
        }

        public static Dictionary<string, string> GetAllAdminPermissions()
        {
            return GeneratePermissions(AdminAuthorizations);
        }

        public static List<string> GetAllAdminCategories()
        {
            var permissions = GetAllAdminPermissions();
            return GenerateCategories(permissions);
        }


        private static Dictionary<string, string> GeneratePermissions(List<Type> authorizations)
        {
            return authorizations
                .SelectMany(
                    authorizationType => authorizationType.GetFields(PublicStaticFlags)
                        .Where(field => field.IsLiteral && !field.IsInitOnly)
                        .Select(
                            field => (Name: field.Name, Value: field.GetRawConstantValue()?.ToString())
                        )
                )
                .ToDictionary(property => property.Value, property => property.Name);
        }

        private static List<string> GenerateCategories(Dictionary<string, string> permissions)
        {
            return permissions
                .Select(permission => ExtractCategory(permission.Key))
                .Distinct()
                .ToList();
        }

        private static string ExtractCategory(string permission)
        {
            return permission.Remove(permission.LastIndexOf('.'));
        }

        private const BindingFlags PublicStaticFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
    }
}