using FluentValidation;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.ValidationrRules.CategoryValidation
{
    public class CreateCategoryValidation:AbstractValidator<Category>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu categoryname alanı boş bırakılmaz"); 
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En az 3 karakter veri girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(3).WithMessage("Lütfen En fazla 30 karakter veri girişi yapınız");

        }
    }
}
