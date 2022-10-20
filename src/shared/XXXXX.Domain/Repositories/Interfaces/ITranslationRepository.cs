using System.Collections.Generic;
using System.Threading.Tasks;

using XXXXX.Domain.Models;
using XXXXX.Domain.Repositories.Filters;

namespace XXXXX.Domain.Repositories.Interfaces
{
    public interface ITranslationRepository
    {
        Task<IEnumerable<Translation>> GetMany();
    }
}