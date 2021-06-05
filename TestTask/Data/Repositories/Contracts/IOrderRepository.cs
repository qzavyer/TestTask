using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> AllAsync();
        Task<IEnumerable<Order>> AllByDateAsync(DateTime date);
        Task<Order> GetByNumberAsync(short number);
        Task<Order> SaveAsync(Order order);
        Task<Order> AddAsync(Order order);
        Task DeleteAsync(short number);
    }
}