using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Repositories.Contracts;
using TestTask.Models;

namespace TestTask.Controllers
{
    /// <summary>
    /// Контроллер товаров
    /// </summary>
    [ApiController]
    [Route("goods")]
    public class GoodsController : ControllerBase
    {
        /// <summary>
        /// Репозиторий товаров
        /// </summary>
        private readonly IGoodRepository _goodRepository;

        /// <inheritdoc/>
        public GoodsController(IGoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        /// <summary>
        /// Получить все товары ИМ
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<GoodModel>> GetGoods()
        {
            var model = await _goodRepository.AllAsync();

            return model.Select(g => new GoodModel(g));
        }

        /// <summary>
        /// Получить информацию по товару по артикулу
        /// </summary>
        /// <param name="article">Артикул</param>
        [HttpGet("{article}")]
        public async Task<GoodModel> GetGood(long article)
        {
            var good = await _goodRepository.GetByArticleAsync(article);
            return good == null ? null : new GoodModel(good);
        }
    }
}
