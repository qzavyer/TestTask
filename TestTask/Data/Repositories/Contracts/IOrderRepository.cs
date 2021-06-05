using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories.Contracts
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Возвращает все заказы
        /// </summary>
        Task<IEnumerable<Order>> AllAsync();

        /// <summary>
        /// Возвращает все заказы на указанную дату
        /// </summary>
        /// <param name="date">Дата</param>
        Task<IEnumerable<Order>> AllByDateAsync(DateTime date);

        /// <summary>
        /// Возвращает заказ по номеру
        /// </summary>
        /// <param name="number">Номер</param>
        Task<Order> GetByNumberAsync(short number);

        /// <summary>
        /// Сохраняет заказ
        /// </summary>
        /// <param name="order">Данные заказа</param>
        Task<Order> SaveAsync(Order order);

        /// <summary>
        /// Добавляет заказ
        /// </summary>
        /// <param name="order">Данные заказа</param>
        Task<Order> AddAsync(Order order);

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="number">Номер</param>
        Task DeleteAsync(short number);
    }
}