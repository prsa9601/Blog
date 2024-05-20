using Blog.Domain.UserAgg.Services;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Blog.Domain.UserAgg
{
    public class User : BaseEntity
    {
        private User()
        {
            
        }
        public User(string name, string family, string password, string phoneNumber, string userName, IUserDomainService userDomainService)
        {
            Guard(phoneNumber,userName,userDomainService);
            Name = name;
            Family = family;
            AvatarName = "Avatar.png";
            Password = password;
            PhoneNumber = phoneNumber;
            UserName = userName;
            Roles = new List<UserRole>();
            Tokens = new List<UserToken>();
        }
        public string Name { get; set; }
        public string Family { get; set; }
        public string AvatarName { get; set; } 
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public List<UserRole> Roles { get; }
        public List<UserToken> Tokens { get; }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }
        
        public void SetUserRoles(List<long> roles)
        {
            List<UserRole> userRoles = new List<UserRole>();
            foreach (var item in roles)
            {
                userRoles.Add( new UserRole(item));
            }
            userRoles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(userRoles);
        }

        public void Edit(string name, string family, string phoneNumber, string userName,
            IUserDomainService userDomainService)
        {
            Guard(phoneNumber, userName, userDomainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            UserName = userName;
            
        }

        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));

            Password = newPassword;
        }
        public static User RegisterUser(string phoneNumber, string password, string userName, IUserDomainService userDomainService)
        {
            return new User("", "", password, phoneNumber, userName, userDomainService);
        }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }
        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                imageName = "avatar.png";

            AvatarName = imageName;
        }
        public string RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("invalid TokenId");

            Tokens.Remove(token);
            return token.HashJwtToken;
        }

        public void Guard(string phoneNumber, string userName, IUserDomainService userDomainService)
        {
            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (string.IsNullOrWhiteSpace(userName))
                    throw new InvalidDomainDataException(" نام کاربری نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (userDomainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");
            if (userName != UserName)
                if (userDomainService.UserNameIsExist(phoneNumber))
                    throw new InvalidDomainDataException(" نام کاربری تکراری است");
            if(userName!=UserName)
                if (userDomainService.UserNameIsExist(userName))
                    throw new Exception("نام کاربری تکراری است!");
                     
            if(phoneNumber!=PhoneNumber)
                if (userDomainService.PhoneNumberIsExist(phoneNumber))
                    throw new Exception("شما با این شماره تماس ثبت نام کرده اید!");
        }

    }

  
}
