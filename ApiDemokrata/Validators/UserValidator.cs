using ApiDemokrata.Domain;
using FluentValidation;

namespace ApiDemokrata.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("El primer nombre es obligatorio")
                .MaximumLength(50).WithMessage("El primer nombre no puede tener más de 50 caracteres")
                .Matches(@"^[a-zA-Z]+$").WithMessage("El primer nombre solo puede contener letras");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("El primer apellido es obligatorio")
                .MaximumLength(50).WithMessage("El primer apellido no puede tener más de 50 caracteres")
                .Matches(@"^[a-zA-Z]+$").WithMessage("El primer apellido solo puede contener letras");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("El salario debe ser mayor a 0");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("La fecha de nacimiento es obligatoria")
                .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento debe ser en el pasado");
        }  
    }
}
