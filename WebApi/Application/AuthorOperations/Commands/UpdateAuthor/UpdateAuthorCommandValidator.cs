using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(2).When(x=> x.Model.Name.Trim() != string.Empty);
            RuleFor(command => command.Model.Surname).MinimumLength(2).When(x=> x.Model.Surname.Trim() != string.Empty);
            RuleFor(command => command.Model.DateOfBirth).NotEmpty().LessThan(DateTime.Now);
        }
    }
}