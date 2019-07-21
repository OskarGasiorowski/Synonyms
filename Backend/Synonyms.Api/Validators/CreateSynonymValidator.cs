using System.Text.RegularExpressions;
using FluentValidation;
using Synonyms.AppLogic.MediatR.CreateSynonym;
using Synonyms.Database.Models;

namespace Synonyms.Api.Validators
{
    public class CreateSynonymValidator : AbstractValidator<CreateSynonymCommand>
    {
        private const string AlphaPatter = "^[\\s\\p{L}]+$";
        
        public CreateSynonymValidator()
        {
            RuleFor(command => command.Term)
                .Matches(AlphaPatter)
                .MaximumLength(50)
                .MinimumLength(2);

            RuleForEach(command => command.Synonyms)
                .Matches(AlphaPatter);
        }
    }
}