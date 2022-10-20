using System;

namespace Foundation.Clients.ViewModels.Shell
{
    public class OrganisationInfosViewModel
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public string ImageBlurHash { get; set; }
        public int? ImageHeight { get; set; }
        public int? ImageWidth { get; set; }
        public int UserCount { get; set; }

        #region Translated properties
        public string Label { get; set; }
        #endregion
    }
}