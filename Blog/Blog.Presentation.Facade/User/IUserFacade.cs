﻿using Blog.Application.User.AddToken;
using Blog.Application.User.ChangePassword;
using Blog.Application.User.Create;
using Blog.Application.User.Delete;
using Blog.Application.User.Edit;
using Blog.Application.User.Register;
using Blog.Application.User.RemoveToken;
using Blog.Application.User.SetRole;
using Blog.Query.User.DTOs;
using Common.Application;

namespace Blog.Presentation.Facade.User
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUser(RegisterUserCommand command);
        Task<OperationResult> EditUser(EditUserCommand command);
        Task<OperationResult> CreateUser(CreateUserCommand command);
        Task<OperationResult> AddToken(AddUserTokenCommand command);
        Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);
        Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);
        Task<OperationResult> SetRole(SetRoleCommand command);
        Task<OperationResult> Delete(DeleteUserCommand command);

        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
        Task<UserDto?> GetUserById(long userId);
        Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
        Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
    }
}
