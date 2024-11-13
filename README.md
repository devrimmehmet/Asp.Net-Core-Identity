# Projeyi Çalıştırma

proje açıldığında terminalden

`update-database`

komutunu yazmayı unutmayınız. Bu komut veritabanının yüklenmesini sağlayacaktır.

### Proje veritabanı olarak varsayılan mssql bir veritabanı kullanır ve update-migration işlemi yaptığınızda localinizde (.) belirtecini kullanır farklı bir bağlantı bilgisi kullanıyorsanız kendinize göre uyarlayınız.

# Asp.Net-Core-Identity

Asp.Net Core Üyelik Sistemi (Asp.Net Core Identity) .Net7 - Fatih Çakıroğlu'nun eğitimi temelli bir çalışma.

---

Temel Bilgiler

- Cookie
- Authentication(Kimlik Doğrulama)
- Authorization(Kimlik Yetkilendirme)
- Claims(key-value)
- Role
- Üçüncü taraf kimlik doğrulaması (Third party authentication)

---

Kullanılan paketler

*Microsoft.EntityFrameworkCore 7.0.12
*Microsoft.EntityFrameworkCore.SqlServer 7.0.12
*Microsoft.EntityFrameworkCore.Tools 7.0.12
*Microsoft.AspNetCore.Identity.EntityFrameworkCore 7.0.12

---

IdentityDbContext

    *IdentityUser Entity
    *IdentityRole Entity

---

- SignUp
- SignIn
- Password Validasyonları
- LogOut
- ResetPassword(ForgetPassword)
- Security Stamp
- Concurrency Stamp
- UserIdentity Ek Property oluşturma (Picture,City,BirthDate,Gender)
- Rol Bazlı Yetkilendirme(Role-based authorization) "Admin,User,Editor"
- Claims Bazlı Yetkilendirme(Claims-based authorization)
- Policy Bazlı Yetkilendirme(Policy-based authorization)
