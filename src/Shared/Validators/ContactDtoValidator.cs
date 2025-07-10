using FluentValidation;

namespace Shared;

public class ContactDtoValidator : AbstractValidator<ContactDto>
{
    public ContactDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleForEach(x => x.PhoneNumbers).SetValidator(new PhoneNumberDtoValidator());
    }
}

public class PhoneNumberDtoValidator : AbstractValidator<PhoneNumberDto>
{
    public PhoneNumberDtoValidator()
    {
        RuleFor(x => x.Number).NotEmpty();
    }
}
