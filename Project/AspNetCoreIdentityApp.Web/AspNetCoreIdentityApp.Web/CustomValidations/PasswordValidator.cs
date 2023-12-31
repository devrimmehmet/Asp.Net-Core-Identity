﻿using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors=new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() {Code="PasswordContainsUserName",Description="Şifre alanı kullanıcı adını içeremez."});
            }
            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new() {Code="PasswordStartWith1234",Description="Şifre alanı 1234 ile başlayamaz."});
            }
            if (errors.Any()) // Hatalardan Herhangi biri varsa
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }



            return Task.FromResult(IdentityResult.Success);

        }
    }
}
