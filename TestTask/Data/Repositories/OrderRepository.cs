using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Data.Models;
using TestTask.Data.Repositories.Contracts;

namespace TestTask.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> AddAsync(Order order)
        {
            foreach (var good in order.Goods)
            {
                var orderGood = _dbContext.Set<OrderGood>().FirstOrDefault(g => g.GoodArticle == good.GoodArticle && g.OrderNumber == good.OrderNumber);

                if (orderGood != null)
                {
                    good.Good = null;
                    good.Id = orderGood.Id;
                }
                else
                {
                    var baseGood = _dbContext.Set<Good>().FirstOrDefault(g => g.Article == good.GoodArticle);

                    if (baseGood != null) good.Good = null;
                }
            }

            await _dbContext.Set<Order>().AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> AllAsync()
        {
            return await _dbContext.Set<Order>().Include(p => p.Goods).ThenInclude(p => p.Good).ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> AllByDateAsync(DateTime date)
        {
            return await _dbContext.Set<Order>().Where(p => p.Date >= date.Date && p.Date < date.Date.AddDays(1)).Include(p => p.Goods).ThenInclude(p => p.Good).ToArrayAsync();
        }

        public async Task DeleteAsync(short number)
        {
            var order = await GetByNumberAsync(number);
            _dbContext.Set<Order>().Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetByNumberAsync(short number)
        {
            return await _dbContext.Set<Order>().Include(p => p.Goods).ThenInclude(p => p.Good).FirstOrDefaultAsync(o => o.Number == number);
        }

        public async Task<Order> SaveAsync(Order order)
        {
            foreach (var good in order.Goods)
            {
                var orderGood = _dbContext.Set<OrderGood>().FirstOrDefault(g => g.GoodArticle == good.GoodArticle && g.OrderNumber == good.OrderNumber);

                if (orderGood != null)
                {
                    good.Good = null;
                    good.Id = orderGood.Id;
                }
                else
                {
                    var baseGood = _dbContext.Set<Good>().FirstOrDefault(g => g.Article == good.GoodArticle);

                    if (baseGood != null) good.Good = null;
                }
            }

            order.Goods = null;

            _dbContext.Set<Order>().Update(order);

            await _dbContext.SaveChangesAsync();

            return order;
        }
    }
}