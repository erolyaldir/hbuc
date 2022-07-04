using str.Entities.Dto;

namespace StreamReader.Domain 
{
    public interface IProductViewService
    {
        public void AddProductView(ProductViewDto productView);
    }
}
