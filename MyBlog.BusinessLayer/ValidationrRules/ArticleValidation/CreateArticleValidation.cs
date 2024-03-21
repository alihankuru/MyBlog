using FluentValidation;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.ValidationrRules.ArticleValidation
{
    public class CreateArticleValidation:AbstractValidator<Article>
    {
        public CreateArticleValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu title alanı boş bırakılmaz").MinimumLength(5).WithMessage("Lütffen en az 5 karakter veri girişi yapınız").MinimumLength(100).WithMessage("Lütfen en fazla 100 karakter veri girişi");

        }
    }
}
