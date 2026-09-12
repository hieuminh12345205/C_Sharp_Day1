# C_Sharp_Day1

Repository gồm các bài tập Console C# được viết bằng .NET 10.

## Bài tập

### Bài 1

Nhập ba số nguyên `a`, `b`, `c` và tính tổng `a + b + c`.

### Bài 2

Chương trình quản lý các loại hình học bằng tính đa hình:

- Hình tròn.
- Hình chữ nhật.
- Hình tam giác.
- Tính diện tích và chu vi.
- Kiểm tra dữ liệu đầu vào hợp lệ.
- Kiểm tra ba cạnh có tạo thành tam giác hay không.
- Hiển thị danh sách các hình đã nhập.

## Kiến thức áp dụng

- Interface `Hinh`.
- Tính đa hình thông qua `List<Hinh>`.
- Phương thức khởi tạo.
- Đóng gói và kiểm tra dữ liệu trong các thuộc tính.
- Công thức Heron để tính diện tích tam giác.

## Cấu trúc dự án

```text
C_Sharp_Day1/
├── ConsoleApp1.slnx
├── Bai_1/
│   ├── Bai_1.csproj
│   └── Program.cs
├── Bai_2/
│   ├── Bai_2.csproj
│   └── Program.cs
└── README.md
```

## Yêu cầu

- .NET 10 SDK
- Visual Studio 2026 hoặc mới hơn

## Cách chạy

Mở file `ConsoleApp1.slnx` bằng Visual Studio. Chọn project muốn chạy, sau đó nhấn `Ctrl + F5`.

Chạy Bài 1 bằng terminal:

```powershell
dotnet run --project .\Bai_1\Bai_1.csproj
```

Chạy Bài 2 bằng terminal:

```powershell
dotnet run --project .\Bai_2\Bai_2.csproj
```

## Sử dụng Bài 2

1. Chọn loại hình trong menu.
2. Nhập các giá trị kích thước.
3. Chọn `Hiển thị danh sách hình` để xem diện tích và chu vi.
4. Chọn `Thoát` để kết thúc chương trình.
