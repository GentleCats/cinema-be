using cinema_be.Entities;
using FluentValidation;

namespace cinema_be.Validators
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
           

            RuleFor(t => t.BookingTime)
                .NotEmpty().WithMessage("Час бронювання є обов'язковим");

            RuleFor(t => t.UserId)
                .NotEmpty().WithMessage("UserId є обов'язковим")
                .GreaterThan(0).WithMessage("UserId має бути більше 0");

            RuleFor(t => t.SessionId)
                .NotEmpty().WithMessage("SessionId є обов'язковим")
                .GreaterThan(0).WithMessage("SessionId має бути більше 0");

            RuleFor(t => t.Seat)
                .NotEmpty().WithMessage("Місце є обов'язковим")
                .GreaterThan(0).WithMessage("Місце має бути більше 0");

            RuleFor(t => t.Row)
                .NotEmpty().WithMessage("Ряд є обов'язковим")
                .GreaterThan(0).WithMessage("Ряд має бути більше 0");

            RuleFor(t => t.Col)
                .NotEmpty().WithMessage("Колонка є обов'язковою")
                .GreaterThan(0).WithMessage("Колонка має бути більше 0");
        }
    }
}
