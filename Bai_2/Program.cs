using System.Globalization;

interface Hinh
{
    double GetDienTich();
    double GetChuVi();
    void Nhap();
    void HienThi();
}

class HinhTron : Hinh
{
    private double banKinh;

    public double BanKinh
    {
        get => banKinh;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(BanKinh), "Ban kinh phai lon hon 0.");
            }

            banKinh = value;
        }
    }

    public HinhTron() : this(1)
    {
    }

    public HinhTron(double banKinh)
    {
        BanKinh = banKinh;
    }

    public double GetDienTich() => Math.PI * BanKinh * BanKinh;

    public double GetChuVi() => 2 * Math.PI * BanKinh;

    public void Nhap()
    {
        BanKinh = ConsoleHelper.ReadPositiveDouble("Nhap ban kinh: ");
    }

    public void HienThi()
    {
        Console.WriteLine($"Hinh tron: ban kinh = {BanKinh:0.##}, dien tich = {GetDienTich():0.##}, chu vi = {GetChuVi():0.##}");
    }
}

class HinhChuNhat : Hinh
{
    private double chieuDai;
    private double chieuRong;

    public double ChieuDai
    {
        get => chieuDai;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ChieuDai), "Chieu dai phai lon hon 0.");
            }

            chieuDai = value;
        }
    }

    public double ChieuRong
    {
        get => chieuRong;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ChieuRong), "Chieu rong phai lon hon 0.");
            }

            chieuRong = value;
        }
    }

    public HinhChuNhat() : this(1, 1)
    {
    }

    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        ChieuDai = chieuDai;
        ChieuRong = chieuRong;
    }

    public double GetDienTich() => ChieuDai * ChieuRong;

    public double GetChuVi() => 2 * (ChieuDai + ChieuRong);

    public void Nhap()
    {
        ChieuDai = ConsoleHelper.ReadPositiveDouble("Nhap chieu dai: ");
        ChieuRong = ConsoleHelper.ReadPositiveDouble("Nhap chieu rong: ");
    }

    public void HienThi()
    {
        Console.WriteLine($"Hinh chu nhat: dai = {ChieuDai:0.##}, rong = {ChieuRong:0.##}, dien tich = {GetDienTich():0.##}, chu vi = {GetChuVi():0.##}");
    }
}

class HinhTamGiac : Hinh
{
    private double canhA;
    private double canhB;
    private double canhC;

    public double CanhA
    {
        get => canhA;
        set => canhA = ValidatePositive(value, nameof(CanhA));
    }

    public double CanhB
    {
        get => canhB;
        set => canhB = ValidatePositive(value, nameof(CanhB));
    }

    public double CanhC
    {
        get => canhC;
        set => canhC = ValidatePositive(value, nameof(CanhC));
    }

    public HinhTamGiac() : this(3, 4, 5)
    {
    }

    public HinhTamGiac(double canhA, double canhB, double canhC)
    {
        if (canhA <= 0 || canhB <= 0 || canhC <= 0 || !IsTamGiac(canhA, canhB, canhC))
        {
            throw new ArgumentException("Ba canh khong tao thanh mot tam giac hop le.");
        }

        CanhA = canhA;
        CanhB = canhB;
        CanhC = canhC;
    }

    public bool IsTamGiac() => IsTamGiac(CanhA, CanhB, CanhC);

    public static bool IsTamGiac(double canhA, double canhB, double canhC) =>
        canhA > 0 && canhB > 0 && canhC > 0 &&
        canhA + canhB > canhC &&
        canhA + canhC > canhB &&
        canhB + canhC > canhA;

    public double GetDienTich()
    {
        double nuaChuVi = GetChuVi() / 2;
        return Math.Sqrt(nuaChuVi * (nuaChuVi - CanhA) * (nuaChuVi - CanhB) * (nuaChuVi - CanhC));
    }

    public double GetChuVi() => CanhA + CanhB + CanhC;

    public void Nhap()
    {
        while (true)
        {
            double a = ConsoleHelper.ReadPositiveDouble("Nhap canh A: ");
            double b = ConsoleHelper.ReadPositiveDouble("Nhap canh B: ");
            double c = ConsoleHelper.ReadPositiveDouble("Nhap canh C: ");

            if (!IsTamGiac(a, b, c))
            {
                Console.WriteLine("Ba canh khong thoa man bat dang thuc tam giac. Vui long nhap lai.");
                continue;
            }

            CanhA = a;
            CanhB = b;
            CanhC = c;
            return;
        }
    }

    public void HienThi()
    {
        Console.WriteLine($"Hinh tam giac: A = {CanhA:0.##}, B = {CanhB:0.##}, C = {CanhC:0.##}, dien tich = {GetDienTich():0.##}, chu vi = {GetChuVi():0.##}");
    }

    private static double ValidatePositive(double value, string propertyName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(propertyName, "Do dai canh phai lon hon 0.");
        }

        return value;
    }
}

static class ConsoleHelper
{
    public static double ReadPositiveDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out double value) && value > 0)
            {
                return value;
            }

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Gia tri phai la mot so lon hon 0.");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Hinh> danhSachHinh = new();
        int luaChon;

        do
        {
            Console.WriteLine("\n===== QUAN LY HINH =====");
            Console.WriteLine("1. Nhap hinh tron");
            Console.WriteLine("2. Nhap hinh chu nhat");
            Console.WriteLine("3. Nhap hinh tam giac");
            Console.WriteLine("4. Hien thi danh sach hinh");
            Console.WriteLine("0. Thoat");
            Console.Write("Lua chon: ");

            if (!int.TryParse(Console.ReadLine(), out luaChon))
            {
                luaChon = -1;
            }

            switch (luaChon)
            {
                case 1:
                    Hinh hinhTron = new HinhTron();
                    hinhTron.Nhap();
                    danhSachHinh.Add(hinhTron);
                    break;
                case 2:
                    Hinh hinhChuNhat = new HinhChuNhat();
                    hinhChuNhat.Nhap();
                    danhSachHinh.Add(hinhChuNhat);
                    break;
                case 3:
                    Hinh hinhTamGiac = new HinhTamGiac();
                    hinhTamGiac.Nhap();
                    danhSachHinh.Add(hinhTamGiac);
                    break;
                case 4:
                    if (danhSachHinh.Count == 0)
                    {
                        Console.WriteLine("Danh sach dang trong.");
                        break;
                    }

                    foreach (Hinh hinh in danhSachHinh)
                    {
                        hinh.HienThi();
                    }

                    break;
                case 0:
                    Console.WriteLine("Da thoat chuong trinh.");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        } while (luaChon != 0);
    }
}
