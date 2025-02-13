using cinema_be.Models.DTOs;
using FluentValidation;

namespace cinema_be.Validators
{
    public class CreateHallDtoValidator : AbstractValidator<CreateHallDto>
    {
        public CreateHallDtoValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Назва є обов'язковою")
                .MaximumLength(100).WithMessage("Назва не повинна перевищувати 100 символів.");

            RuleFor(h => h.Capacity)
                .NotEmpty().WithMessage("Місткість є обов'язковою")
                .GreaterThan(0).WithMessage("Місткість має бути більше 0.");

            RuleFor(h => h.Rows)
                .NotEmpty().WithMessage("Кількість рядів є обов'язковою")
                .GreaterThan(0).WithMessage("Кількість рядів має бути більше 0.");

            RuleFor(h => h.Cols)
                .NotEmpty().WithMessage("Кількість колонок є обов'язковою")
                .GreaterThan(0).WithMessage("Кількість колонок має бути більше 0.");

            RuleFor(h => h)
                .Must(h => h.Rows * h.Cols <= h.Capacity)
                .WithMessage("Загальна кількість місць (Рядки * Колонки) не може перевищувати місткість залу.");
        }
    }
}
