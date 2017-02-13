using FluentValidation;
using MediatrEF6PoC3.Messages.Query;

namespace MediatrEF6PoC3.Messages.Validators
{
    public class GetMyValuesByIdQueryValidator : AbstractValidator<GetMyValueByIdQuery>
    {
        public GetMyValuesByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
