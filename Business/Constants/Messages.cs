using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductListError = "Ürünler listelenemedi";

        public static string UserAddSuccess = "Kullanıcı eklenemedi";
        public static string UserAddError = "Kullanıcı eklenemedi";
        public static string UserSearchError = "Kullanıcı bulunamadı";
        public static string UserClaimListError = "Kullanıcının rollerin listelenemedi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme griş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistired = "Kullanıcı başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";
    }
}
