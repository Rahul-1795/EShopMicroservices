using BuildingBlocks.Exceptions;

namespace CatalogAPI.Exceptions
{
    public class ProductNotFoundExceptions : NotFoundException
    {

        public ProductNotFoundExceptions(Guid Id) : 
            base("Product", Id) 
        { 
        }
    }
}
