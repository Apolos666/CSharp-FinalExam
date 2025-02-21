﻿using System.ComponentModel.DataAnnotations;
using CSharp_FinalExam.Infrastructure.CustomValidation;

namespace CSharp_FinalExam.Models;

public class DangKyHocPhan
{
    [Key] public int Id { get; set; }
    [Required] public int SinhVienId { get; set; }
    public SinhVien? SinhVien { get; set; }
    [Required] public int LopHocPhanId { get; set; }
    public LopHocPhan? LopHocPhan { get; set; }
    [DateVietFormat] public DateTime? NgayDangKy { get; set; } = DateTime.Now; // Todo: thêm cái ToString ở bên View
}