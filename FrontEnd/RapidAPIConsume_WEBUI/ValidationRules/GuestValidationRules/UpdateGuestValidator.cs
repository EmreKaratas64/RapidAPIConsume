using FluentValidation;
using RapidAPIConsume_WEBUI.DTOs.GuestDtos;

namespace RapidAPIConsume_WEBUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen bir isim giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen bir soyisim giriniz");
            RuleFor(x => x.City).NotEmpty().WithMessage("Lütfen bir şehir giriniz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim uzunluğu en az 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyisim uzunluğu en az 2 karakter olmalıdır");
            RuleFor(x => x.City).MinimumLength(2).WithMessage("Şehir uzunluğu en az 2 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim uzunluğu en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyisim uzunluğu en fazla 30 karakter olmalıdır");
            RuleFor(x => x.City).MaximumLength(15).WithMessage("Şehir uzunluğu en fazla 15 karakter olmalıdır");

        }
    }
}
