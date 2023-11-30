using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar ad soyadı kısmı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail kısmı boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az iki karakter girişi yapınız.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En az fazla 50 karakter veri girişi yapınız.");
        }
    }
}
