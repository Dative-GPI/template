using System;
using System.Collections.Generic;

namespace XXXXX.Shell.Core.ViewModels
{
    public class RouteInfosViewModel
    {
        public Guid Id { get; set; }
        public Guid ExtensionId { get; set; }

        public bool ShowOnDrawer { get; set; }
        public string DrawerIcon { get; set; }
        public string DrawerCategory { get; set; }

        public string Path { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }

        public bool Exact { get; set; }

        #region Translated properties
        public string DrawerLabel { get; set; }
        #endregion
    }
}
