using cinema_be.Models.DTOs;
using FluentValidation;

namespace cinema_be.Validators
{
    public class CreateSessionDtoValidator : AbstractValidator<CreateSessionDto>
    {
        public CreateSessionDtoValidator()
        {
            RuleFor(s => s.MovieId)
                .NotEmpty().WithMessage("MovieId є обов'язковим")
                .GreaterThan(0).WithMessage("MovieId має бути більше 0");

            RuleFor(s => s.HallId)
                .NotEmpty().WithMessage("HallId є обов'язковим")
                .GreaterThan(0).WithMessage("HallId має бути більше 0");

            RuleFor(s => s.StartTime)
                .NotEmpty().WithMessage("Час початку є обов'язковим");

            RuleFor(s => s.EndTime)
                .NotEmpty().WithMessage("Час закінчення є обов'язковим")
                .GreaterThan(s => s.StartTime).WithMessage("Час закінчення має бути більший за час початку");

            RuleFor(s => s.Price)
                .NotEmpty().WithMessage("Ціна є обов'язковою")
                .GreaterThan(0).WithMessage("Ціна має бути більше 0");

            RuleFor(s => s.Date)
                .NotEmpty().WithMessage("Дата є обов'язковою");
        }
    }
}
