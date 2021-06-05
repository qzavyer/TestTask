using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data.Repositories.Contracts;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            var orders = await _orderRepository.AllAsync();

            return orders.Select(o => new OrderModel(o));
        }

        [HttpGet("{number}")]
        public async Task<OrderModel> GetOrder(short number)
        {
            var orders = await _orderRepository.GetByNumberAsync(number);
            return new OrderModel(orders);
        }

        [HttpGet("forDate")]
        public async Task<IEnumerable<OrderModel>> GetDateOrders(DateTime date)
        {
            var orders = await _orderRepository.AllByDateAsync(date);

            return orders.Select(o => new OrderModel(o));
        }

        [HttpPost]
        public async Task<OrderModel> AddOrder(OrderPostModel order)
        {
            var newOrder = await _orderRepository.AddAsync(order.ToOrder());
            return new OrderModel(newOrder);
        }

        [HttpPut]
        public async Task<OrderModel> SaveOrder(OrderPutModel order)
        {
            var newOrder = await _orderRepository.SaveAsync(order.ToOrder());
            return new OrderModel(newOrder);
        }

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

        [HttpDelete("{number}")]
        public async Task DeleteOrder(short number)
        {
            await _orderRepository.DeleteAsync(number);
        }


    }
}
