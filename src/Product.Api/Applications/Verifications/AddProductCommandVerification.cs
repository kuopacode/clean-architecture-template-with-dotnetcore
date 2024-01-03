using FluentValidation;
using Product.Api.Applications.Commands;

namespace Product.Api.Applications.Verifications
{
    public class AddProductCommandVerification : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandVerification()
        {
            RuleFor(command => command)
            .Must(command => command.ProductPics.Any())
            .WithMessage("Picture is required.");

            RuleFor(command => command)
            .Must(command => command.ProductCategories.Any())
            .WithMessage("Category is required.");

            RuleFor(command => command)
            .Must(command => command.ProductPriceSchedules.Any())
            .WithMessage("PriceSchedule is required.");

            RuleFor(command => command)
            .Must(command => command.SaleEndDate > DateTime.Now)
            .WithMessage("SaleEndDate cannot be the past.");
        }
    }
}
