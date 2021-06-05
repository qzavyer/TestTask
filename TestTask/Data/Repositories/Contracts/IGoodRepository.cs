using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories.Contracts
{
    public interface IGoodRepository
    {
        Task<IEnumerable<Good>> AllAsync();

        Task<Good> GetByArticleAsync(long article);
    }
}