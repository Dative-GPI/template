using System;
using System.Collections.Generic;

namespace Foundation.Clients.ViewModels.Shell
{
    public class OrganisationDetailsViewModel
    {
        public Guid Id { get; set; }
        public Guid OrganisationTypeId { get; set; }
        public Guid? ImageId { get; set; }
        public string ImageBlurHash { get; set; }
        public int? ImageHeight { get; set; }
        public int? ImageWidth { get; set; }
        public int UserCount { get; set; }
        public int LocationCount { get; set; }
        public int DeviceCount { get; set; }
        public Guid? AdminId {get; set; }
        public string AdminName { get; set; }
        public Guid? MainDashboardId { get; set; }

        #region Translated properties
        public string Label { get; set; }
        public string Description { get; set; }
        #endregion
    }
}