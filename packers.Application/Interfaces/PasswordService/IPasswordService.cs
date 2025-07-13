using packers.Application.DTOs;

namespace packers.Application.Interfaces.PasswordHashing
{
    public interface IPasswordService
    {
        Task ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task ResetPasswordAsync(ResetPasswordRequestDto resetPasswordRequestDto);
        Task SetNewPasswordAsync(SetNewPasswordDto setNewPasswordDto);
    }
}