using FluentValidation;

namespace TaskInteview.Dtos
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public int DepartmentId { get; set; }
    }
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Bosh olmaz");
            RuleFor(c => c.Surname).NotEmpty().WithMessage("Bosh olmaz");
            RuleFor(c => c.BirthDate).NotEmpty().WithMessage("Bosh olmaz").MaximumLength(10).MinimumLength(10);
            RuleFor(c => c.DepartmentId).NotEmpty().WithMessage("Bosh olmaz");
        }
    }

}
