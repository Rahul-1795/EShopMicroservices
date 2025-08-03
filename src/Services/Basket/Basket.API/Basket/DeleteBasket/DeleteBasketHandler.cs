namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBaskerResult>;

    public record DeleteBaskerResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }

    public class DeleteBasketCommandHandler(IBasketRepository repository)
        : ICommandHandler<DeleteBasketCommand, DeleteBaskerResult>
    {
        public async Task<DeleteBaskerResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            // Logic to delete the basket for the given UserName
            // For now, we assume the deletion is always successful
            var isSuccess = await repository.DeleteBasketAsync(command.UserName, cancellationToken);

            return new DeleteBaskerResult(isSuccess);
        }
    }
}
