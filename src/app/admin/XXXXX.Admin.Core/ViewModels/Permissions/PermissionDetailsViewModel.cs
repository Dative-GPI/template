using System;
using System.Collections.Generic;

namespace XXXXX.Admin.Core.ViewModels
{
    public class PermissionDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public List<TranslationPermissionViewModel> Translations { get; set; }
    }
}