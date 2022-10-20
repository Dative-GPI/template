using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels;

namespace Foundation.Clients.Abstractions.Gateway
{
    public interface IGatewayTranslationFoundationClient
    {
        void Init(IFoundationClient root);
        Task<IEnumerable<TranslationViewModel>> GetMany(string languageCode);
    }
}