using FluentValidation;
using LocalForecast53.Core.Entities;

namespace LocalForecast53.Core.Validators
{
    public class CallHistoryValidator : AbstractValidator<CallHistory>
    {
        public CallHistoryValidator()
        {
            RuleFor(r => r.ResponseBody)
                .NotEmpty()
                .WithMessage("Retorno da API OpenWeather vazio.");
        }
    }
}
