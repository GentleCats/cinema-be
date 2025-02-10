using cinema_be.Entities;
using FluentValidation;

namespace cinema_be.Validators
{
    public class SessionValidator : AbstractValidator<Session>
    {
        public SessionValidator() {
            RuleFor(t => t.Price)
               .NotEmpty().WithMessage("Ціна є обов'язковою")
               .GreaterThan(0).WithMessage("Ціна має бути більше 0");
            RuleFor(s => s.MovieId)
            .NotEmpty().WithMessage("MovieId є обов'язковим")
            .GreaterThan(0).WithMessage("MovieId має бути більше 0");

            RuleFor(s => s.HallId)
                .NotEmpty().WithMessage("HallId є обов'язковим")
                .GreaterThan(0).WithMessage("HallId має бути більше 0");

            RuleFor(s => s.StartTime)
                .NotEmpty().WithMessage("Час початку є обов'язковим")
                .LessThan(s => s.EndTime).WithMessage("Час початку має бути менший за час закінчення");

            RuleFor(s => s.EndTime)
                .NotEmpty().WithMessage("Час закінчення є обов'язковим")
                .GreaterThan(s => s.StartTime).WithMessage("Час закінчення має бути більший за час початку");
            RuleFor(s => s.Date)
            .NotEmpty().WithMessage("Дата є обов'язковою");
        }
    }
}
