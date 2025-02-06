using cinema_be.Entities;
using FluentValidation;

namespace cinema_be.Validators
{
    public class HallValidator:AbstractValidator<Hall>
    {
        public HallValidator() {
            RuleFor(h => h.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(h => h.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be greater than 0.");

            RuleFor(h => h.Rows)
                .GreaterThan(0).WithMessage("Rows must be greater than 0.");

            RuleFor(h => h.Cols)
                .GreaterThan(0).WithMessage("Cols must be greater than 0.");

            RuleFor(h => h)
                .Must(h => h.Rows * h.Cols <= h.Capacity)
                .WithMessage("The total number of seats (Rows * Cols) cannot exceed the Capacity.");
        }
    }
}
