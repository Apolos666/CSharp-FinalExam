# Trần Đức Quang - 21115053120343 - 223LTC01

﻿# Bài tâp lớn cuối kì C# - Quản lý sinh viên
Dự án "Quản Lý Sinh Viên" là một ứng dụng web được xây dựng bằng C#, nhằm mục đích quản lý thông tin sinh viên một cách hiệu quả và tiện lợi.

## Tính năng
Ứng dụng cung cấp các tính năng sau:
- Quản lý sinh viên: Cho phép thêm, sửa, xoá và xem danh sách các table liên quan.
- Tìm kiếm và lọc: Cung cấp khả năng tìm kiếm sinh viên theo các thuộc tính cụ thể và lọc danh sách sinh viên theo các tiêu chí khác nhau.
- Lưu trữ ảnh: Sử dụng [Azure Blob Storage](https://azure.microsoft.com/en-us/products/storage/blobs) để lưu trữ ảnh của sinh viên.
- Bảo mật thông tin: Sử dụng [Azure Key Vault](https://azure.microsoft.com/en-us/products/key-vault) để lưu trữ và bảo mật các thông tin quan trọng.
- Xác thực và uỷ quyền người dùng: Sử dụng JWT (JSON WEB Token) và Google Authentication để thực hiện việc đăng nhập và đăng ký.

## Hướng dẫn cài đặt
1. Tiến hành clone project
`git clone https://github.com/Apolos666/CSharp-FinalExam.git`
2. Tiến hành chạy file migrations `dotnet ef database update` hoặc `database-update`
3. Lưu ý: Để project có thể hoạt động đúng, cần cung cấp **Azure Client Credential (DirectoryId, ClientId, ClientSecret)** và **Google Client Credential (ClientId, ClientSecret)**. Đây là thông tin quan trọng nên mình không thể cung cấp ở đây, bạn có thể tự tạo và điền vào file [AzureRegistration](https://github.com/Apolos666/CSharp-FinalExam/blob/main/Services/ServicesRegistration/AzureRegistration.cs) và file [SecurityService](https://github.com/Apolos666/CSharp-FinalExam/blob/main/Services/ServicesRegistration/SecurityService.cs)
  - 2.1. Cách để thiết lập Enviroment Variable
      ```
      [Environment]::SetEnvironmentVariable("Your enviroment variable name", "your enviroment value", "User")
      ```
4. Tiến hành chạy project bằng lệnh `dotnet run dev` hoặc nhấn vào nút play nếu bạn sử dụng Visual studio

## Công nghệ sử dụng
- Ngôn ngữ lập trình: C#
- Framework: Asp.net core mvc 8.0
- Thư viện: Tailwind, Axios, AutoMapper, Alpinejs
- Cơ chế xác thực: JWT, Google Authentication
- Lưu trữ: Azure Blob Storage, SQL SERVER 2019
- Bảo mật: Azure Key Vault
