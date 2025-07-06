using CatalogAPI.Products.UpdateProduct;

namespace CatalogAPI.Products.DeleteProduct
{

    public record DeleteProductCommand(Guid Id)
        : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("Delete command handler for Delete product {@Query}", command);

            //var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            //if (product == null)
            //{
            //    throw new ProductNotFoundExceptions();
            //}
            
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync();

            return new DeleteProductResult(true);
        }
    }
}
