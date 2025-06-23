using Packer.Application.DTOs;

namespace Packer.Application.Interfaces.PasswordHashing
{
    public interface IPasswordService
    {
        Task ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task ResetPasswordAsync(ResetPasswordRequestDto resetPasswordRequestDto);
        Task SetNewPasswordAsync(SetNewPasswordDto setNewPasswordDto);
    }
}