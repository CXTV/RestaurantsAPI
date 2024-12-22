using FluentValidation;


namespace Restaurants.Application.DishesUseCase.Commands.CreateDish
{
    public class CreateDishCommandValidator: AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Price).GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than or equal to 0");

            RuleFor(dish => dish.Kilocalories).GreaterThanOrEqualTo(0)
                .WithMessage("Kilocalories must be greater than or equal to 0");
        }
    }
}
