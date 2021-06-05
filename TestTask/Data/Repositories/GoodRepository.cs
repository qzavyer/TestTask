using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Data.Models;
using TestTask.Data.Repositories.Contracts;

namespace TestTask.Data.Repositories
{
    /// <summary>
    /// Репозиторий товаров
    /// </summary>
    internal class GoodRepository : IGoodRepository
    {
        /// <summary>
        /// Данные контекста
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        /// <inheritdoc/>
        public GoodRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Good>> AllAsync()
        {
            return await _dbContext.Set<Good>().ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<Good> GetByArticleAsync(long article)
        {
            return await _dbContext.Set<Good>().FirstOrDefaultAsync(g => g.Article == article);
        }
    }
}