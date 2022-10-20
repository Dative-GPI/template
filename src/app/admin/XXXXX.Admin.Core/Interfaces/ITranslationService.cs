using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface ITranslationService
    {
        Task<IEnumerable<TranslationViewModel>> GetMany(RequestHeaders headers);
    }
}