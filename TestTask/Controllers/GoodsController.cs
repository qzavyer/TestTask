using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Repositories.Contracts;
using TestTask.Models;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("goods")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodRepository _goodRepository;

        public GoodsController(IGoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<GoodModel>> GetGoods()
        {
            var model = await _goodRepository.AllAsync();

            return model.Select(g => new GoodModel(g));
        }

        [HttpGet("{article}")]
        public async Task<GoodModel> GetGood(long article)
        {
            var good = await _goodRepository.GetByArticleAsync(article);
            return good == null ? null : new GoodModel(good);
        }
    }
}
