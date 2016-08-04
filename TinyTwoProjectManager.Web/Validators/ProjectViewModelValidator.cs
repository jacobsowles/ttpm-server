using FluentValidation;
using TinyTwoProjectManager.Web.ViewModels;

namespace TinyTwoProjectManager.Web.Validators
{
    public class ProjectViewModelValidator : AbstractValidator<ProjectViewModel>
    {
        public ProjectViewModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(1, 100).WithMessage("Project name is required and must be between 1 and 100 characters in length.");
        }
    }
}