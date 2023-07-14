using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace ProductSale.App.Validations
{
    public class JsonPatchDocumentValidator : AbstractValidator<JsonPatchDocument>
    {
        public JsonPatchDocumentValidator()
        {
            RuleForEach(o => o.Operations).ChildRules(c =>
            {
                c.RuleFor(x => x.op).NotEmpty()
                                        .WithMessage("Operation must not be null")
                                    .Must(x => x == "add" || x == "remove" || x == "replace" || 
                                               x == "move" || x == "copy" || x == "test")
                                        .WithMessage("Operation not valid");

                c.RuleFor(x => x.path).NotEmpty()
                                        .WithMessage("Path must not be null");

                c.RuleFor(x => x.value).NotEmpty()
                                        .WithMessage("Value must not be null");
            });
        }
    }
}
