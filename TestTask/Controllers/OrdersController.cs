using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Repositories.Contracts;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Controllers
{
    /// <summary>
    /// Контроллер заказов
    /// </summary>
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Репозиторий заказов
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <inheritdoc/>
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Получить все заказы в статусе «Зарегистрирован»
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            var orders = await _orderRepository.AllByStatusAsync(Status.Registred);

            return orders.Select(o => new OrderModel(o));
        }

        /// <summary>
        /// Получить информацию по заказу по номеру
        /// </summary>
        /// <param name="number">Номер заказа</param>
        [HttpGet("{number}")]
        public async Task<OrderModel> GetOrder(short number)
        {
            var orders = await _orderRepository.GetByNumberAsync(number);
            return new OrderModel(orders);
        }

        /// <summary>
        /// Получить заказы, зарегистрированные на дату
        /// </summary>
        /// <param name="date">Дата заказа</param>
        [HttpGet("forDate")]
        public async Task<IEnumerable<OrderModel>> GetDateOrders(DateTime date)
        {
            var orders = await _orderRepository.AllByDateAsync(date);

            return orders.Select(o => new OrderModel(o));
        }

        /// <summary>
        /// Добавить заказ
        /// </summary>
        /// <param name="order">Данные заказа</param>
        [HttpPost]
        public async Task<OrderModel> AddOrder(OrderPostModel order)
        {
            var newOrder = await _orderRepository.AddAsync(order.ToOrder());
            return new OrderModel(newOrder);
        }

        /// <summary>
        /// Изменить заказ
        /// </summary>
        /// <param name="order">Данные заказа</param>
        [HttpPut]
        public async Task<OrderModel> SaveOrder(OrderPutModel order)
        {
            var newOrder = await _orderRepository.SaveAsync(order.ToOrder());
            return new OrderModel(newOrder);
        }

        /// <summary>
        /// Изменить заказ
        /// </summary>
        /// <param name="order">Данные заказа</param>
        [HttpPatch]
        public async Task<OrderModel> PutchOrder(OrderPutchModel order)
        {
            var baseOrder = await _orderRepository.GetByNumberAsync(order.Number);
            if (order.Goods != null)
            {
                baseOrder.Goods = order.Goods.Select(g => g.ToOrderGood()).ToArray();
            }

            if (order.Name != null)
            {
                baseOrder.Name = order.Name;
            }

            if (order.Status.HasValue)
            {
                baseOrder.Status = order.Status.Value;
            }

            if (order.Date.HasValue)
            {
                baseOrder.Date = order.Date.Value;
            }

            baseOrder = await _orderRepository.SaveAsync(baseOrder);

            return new OrderModel(baseOrder);
        }

        /// <summary>
        /// Отменить заказ
        /// </summary>
        /// <param name="number">Номер заказа</param>
        [HttpDelete("{number}")]
        public async Task DeleteOrder(short number)
        {
            await _orderRepository.DeleteAsync(number);
        }
    }
}
