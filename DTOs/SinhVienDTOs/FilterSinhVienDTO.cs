﻿using CSharp_FinalExam.Models;

namespace CSharp_FinalExam.DTOs.SinhVien;

public class FilterSinhVienDTO
{
    public string? FilterTen { get; set; }
    public bool IsFilterByDate { get; set; } = false;
    public bool IsFilterByGender { get; set; } = false;
    public bool IsFilterByGPA { get; set; } = false;
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public GioiTinhEnum? GioiTinhEnumFilter { get; set; }
    public double? GPAFilter { get; set; }
}