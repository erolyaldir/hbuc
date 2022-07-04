using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.Domain;
using RecommendationAPI.Entities.Dto;
using Newtonsoft.Json;
namespace ViewProducer.Application
{
    [Route("api/recomendation")]
    [ApiController]
    public class BestSellerRecomendationController : ControllerBase
    {
        IProductViewService _productViewService;
        public BestSellerRecomendationController(IProductViewService productViewService)
        {
            _productViewService = productViewService;
        }


        [HttpPost("bestseller")]
        public ActionResult<ProductViewResultDto> PostBody(string userId)
        {
            var result = _productViewService.GetBestSellers(userId);
            ProductViewResultDto productViewResultDto = new ProductViewResultDto();
            if (result.Item1.Count < 5)
            {
                productViewResultDto = new ProductViewResultDto
                {
                    UserId = userId,
                    ListType = "personalized",
                    ProductIds = new List<string>()

                };

            }
            else
            {
                if (result.Item2)
                {
                    productViewResultDto = new ProductViewResultDto
                    {
                        UserId = userId,
                        ListType = "personalized",
                        ProductIds = result.Item1.Select(x => x.ProductId).ToList()

                    };
                }
                else
                {
                    productViewResultDto = new ProductViewResultDto
                    {
                        UserId = userId,
                        ListType = "personalized",
                        ProductIds = result.Item1.Select(x => x.ProductId).ToList()

                    };
                }
            }


            return Ok(JsonConvert.SerializeObject(productViewResultDto));
        }

    }
}