using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Admin.Core.ViewModels;

namespace XXXXX.Admin.Core.Interfaces
{
    public interface IApplicationTranslationService
    {
        Task<IEnumerable<ApplicationTranslationViewModel>> GetMany(RequestHeaders headers);
        Task UpdateRange(RequestHeaders headers, IEnumerable<UpdateApplicationTranslationViewModel> payload);
    }
}