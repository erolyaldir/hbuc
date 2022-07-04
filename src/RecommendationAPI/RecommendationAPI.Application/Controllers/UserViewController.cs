using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.Domain;
using RecommendationAPI.Entities.Dto;
using Newtonsoft.Json;
namespace ViewProducer.Application
{
    [Route("api/recomendation")]
    [ApiController]
    public class UserViewController : ControllerBase
    {
        IProductViewService _productViewService;
        public UserViewController(IProductViewService productViewService)
        {
            _productViewService = productViewService;
        }


        [HttpPost("userhistory")]
        public ActionResult<ProductViewResultDto> PostBody(string userId)
        {
            var result = _productViewService.GetUserProductViews(userId);
            ProductViewResultDto productViewResultDto = new ProductViewResultDto
            {
                UserId = userId,
                ListType = "personalized",
                ProductIds = result.Count < 5 ? new List<string>() : result.Select(x => x.ProductId).ToList()
            };
            return Ok(JsonConvert.SerializeObject(productViewResultDto));
        }
        [HttpDelete]
        public IActionResult Delete(string userId, string productId)
        {
            _productViewService.DeleteUserProducts(userId, productId);
            return Ok();
        }
    }
}