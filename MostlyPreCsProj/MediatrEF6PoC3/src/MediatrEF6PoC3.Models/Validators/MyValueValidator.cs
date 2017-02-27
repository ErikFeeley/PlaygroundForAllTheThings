using FluentValidation;

namespace MediatrEF6PoC3.Models.Validators
{
    public class MyValueValidator : AbstractValidator<MyValue>
    {
        public MyValueValidator()
        {
            RuleFor(myValue => myValue.Blurb).Length(50).WithMessage("Must be shorter than 50 characaters");
        }
    }
}
