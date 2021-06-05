using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories.Contracts
{
    /// <summary>
    /// Интерфейс репозитория товаров
    /// </summary>
    public interface IGoodRepository
    {
        /// <summary>
        /// Возвращает все товары
        /// </summary>
        Task<IEnumerable<Good>> AllAsync();

        /// <summary>
        /// Возвращает товер по артикулу
        /// </summary>
        /// <param name="article">Артикул</param>
        Task<Good> GetByArticleAsync(long article);
    }
}