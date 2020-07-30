using FluentValidation;

namespace XPTO.Product.Application.Command.Validation
{
    public class AddProductValidation : AbstractValidator<RegisterProductCommand>
    {
        public AddProductValidation()
        {
            RuleFor(c => c.Name)
              .NotEqual(string.Empty)
              .WithMessage("The product 'Name' was not provided");

            RuleFor(c => c.StockBalance)
                .Must(MinimumStockBalance)
                .WithMessage("The 'StockBalance' isn't valid ");
        }

        private static bool MinimumStockBalance(int stockBalance)
        {
            return stockBalance >= 0;
        }
    }
}