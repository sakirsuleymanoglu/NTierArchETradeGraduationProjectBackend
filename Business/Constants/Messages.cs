using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string ThereIsAUser;
        public static string UserClaimsListed;
        public static string UserInsertionSuccess;
        public static string UserDeletedSuccess;
        public static string UsersListed;
        public static string ThereIsAEmail;
        public static string EmailNotFound;
        public static string UserOperationClaimInsertionSuccess;
        public static string LoginSuccessful;
        public static string PasswordError;
        public static string UserInsertionError;
        public static string RegistirationSuccessful = "Kayıt başarılı bir şekilde gerçekleşti.";
        public static string UserUpdatedSuccess;
        public static string UserAlreadyExists { get; set; }
        public static string UserNotFound { get; set; }
        public static string UserClaimsNotFound { get; set; }
    }
}
