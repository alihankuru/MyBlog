﻿using Microsoft.AspNetCore.Identity;

namespace MyBlog.PresentationLayer.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code="PasswordRequiresLower",
                Description="Lütfen en az 1 tane küçük harf girişi yapınız('a'-'z')."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 tane büyük harf girişi yapınız('a'-'z')."
            };
        }

       
    }
}
