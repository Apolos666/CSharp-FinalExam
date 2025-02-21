﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSharp_FinalExam.DTOs.IdentityDTOs;

public class UserLogin
{
    [Required(ErrorMessage = "Email hoặc UserName là bắt buộc")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Tên người dùng phải có ít nhất 6 ký tự")]
    [DisplayName("Email hoặc UserName")]
    public string UserOrEmail { get; set; }
    
    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ cái viết hoa, một chữ cái viết thường và một số")]
    public string Password { get; set; }

    [DefaultValue(false)]
    public bool IsRememberMe { get; set; }

    public string? ErrorMessage { get; set; }
}