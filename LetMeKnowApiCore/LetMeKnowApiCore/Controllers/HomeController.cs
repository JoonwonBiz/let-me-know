using Core;
using LetMeKnow.Biz;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LetMeKnowApiCore.Controllers
{
    [Route("v1/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("get_costco_discount_info")]
        [HttpPost]
        public string GetCostcoDiscountInfo()
        {
            BizCostcoDiscount bizCostcoDiscount = new();

            List<CostcoProduct> product = bizCostcoDiscount.GetCostcoDiscountInfo();

            return JsonConvert.SerializeObject(product);
        }
    }
}
