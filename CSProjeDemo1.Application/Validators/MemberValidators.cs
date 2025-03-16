using FluentValidation;
using CSProjeDemo1.Application.DTOs;

namespace CSProjeDemo1.Application.Validators
{
    /// <summary>
    /// Validator for CreateMemberDto
    /// TR: CreateMemberDto için doğrulayıcı
    /// </summary>
    public class CreateMemberDtoValidator : AbstractValidator<CreateMemberDto>
    {
        public CreateMemberDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required. TR: Ad alanı zorunludur.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters. TR: Ad 50 karakteri geçemez.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required. TR: Soyad alanı zorunludur.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters. TR: Soyad 50 karakteri geçemez.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required. TR: Email alanı zorunludur.")
                .EmailAddress().WithMessage("Invalid email format. TR: Geçersiz email formatı.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters. TR: Email 100 karakteri geçemez.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required. TR: Telefon numarası zorunludur.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits. TR: Telefon numarası 10 haneli olmalıdır.");
        }
    }

    public class UpdateMemberDtoValidator : AbstractValidator<UpdateMemberDto>
    {
        public UpdateMemberDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format. TR: Geçersiz email formatı.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters. TR: Email 100 karakteri geçemez.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits. TR: Telefon numarası 10 haneli olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Phone));
        }
    }
} 