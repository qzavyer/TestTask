using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Data.Models;
using TestTask.Data.Repositories.Contracts;

namespace TestTask.Data.Repositories
{
    internal class GoodRepository : IGoodRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GoodRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Good>> AllAsync()
        {
            return await _dbContext.Set<Good>().ToArrayAsync();
        }

        public async Task<Good> GetByArticleAsync(long article)
        {
            return await _dbContext.Set<Good>().FirstOrDefaultAsync(g => g.Article == article);
        }
    }
}