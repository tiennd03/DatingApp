using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _0206266_BuiXuanTien_1;
class Program
{
    static List<LoaiBangDia> dsLoaiBangDia = new List<LoaiBangDia>();
    static List<BangDia> dsBangDia = new List<BangDia>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Quan ly loai bang dia");
            Console.WriteLine("2. Quan ly bang dia");
            Console.WriteLine("3. Tim kiem bang dia");
            Console.WriteLine("4. Tim kiem");
            Console.WriteLine("5. In thong ke");
            Console.WriteLine("0. Thoat");

            int chon;
            if (int.TryParse(Console.ReadLine(), out chon))
            {
                switch (chon)
                {
                    case 1:
                        QuanLyLoaiBangDia();
                        break;
                    case 2:
                        QuanLyBangDia();
                        break;
                    case 3:
                        TimKiemBangDia();
                        break;
                    case 4:
                        TimKiemTheoTen();
                        break;
                    case 5:
                        InThongKe();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nhap khong hop le. Vui long nhap so.");
            }

            Console.WriteLine("\n-----------------------------\n");
        }
    }

    static void QuanLyLoaiBangDia()
    {
        Console.WriteLine("Chon chuc nang quan ly Loai Bang Dia:");
        Console.WriteLine("1. Them loai bang dia");
        Console.WriteLine("2. Sua loai bang dia");
        Console.WriteLine("3. Xoa loai bang dia");
        Console.WriteLine("0. Quay lai");

        int chon;
        if (int.TryParse(Console.ReadLine(), out chon))
        {
            switch (chon)
            {
                case 1:
                    ThemLoaiBangDia();
                    break;
                case 2:
                    SuaLoaiBangDia();
                    break;
                case 3:
                    XoaLoaiBangDia();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nhap khong hop le. Vui long nhap so.");
        }
    }

    static void ThemLoaiBangDia()
    {
        Console.WriteLine("Nhap ma loai:");
        string maLoai = Console.ReadLine();
        Console.WriteLine("Nhap ten loai:");
        string tenLoai = Console.ReadLine();
        Console.WriteLine("Nhap ghi chu:");
        string ghiChu = Console.ReadLine();
        LoaiBangDia loaiBangDia = new LoaiBangDia(maLoai, tenLoai, ghiChu);
        dsLoaiBangDia.Add(loaiBangDia);
        Console.WriteLine("Them loai bang dia thanh cong.");
    }

    static void SuaLoaiBangDia()
    {
        Console.WriteLine("Nhap ma loai can sua:");
        string maLoaiSua = Console.ReadLine();
        LoaiBangDia loaiCanSua = dsLoaiBangDia.FirstOrDefault(loai => loai.MaLoai == maLoaiSua);
        if (loaiCanSua != null)
        {
            Console.WriteLine("Nhap ten loai moi:");
            loaiCanSua.TenLoai = Console.ReadLine();
            Console.WriteLine("Nhap ghi chu moi:");
            loaiCanSua.GhiChu = Console.ReadLine();
            Console.WriteLine("Sua thong tin loai bang dia thanh cong.");
        }
        else
        {
            Console.WriteLine("Khong tim thay ma loai can sua.");
        }
    }

    static void XoaLoaiBangDia()
    {
        Console.WriteLine("Nhap ma loai can xoa:");
        string maLoaiXoa = Console.ReadLine();
        LoaiBangDia loaiCanXoa = dsLoaiBangDia.FirstOrDefault(loai => loai.MaLoai == maLoaiXoa);
        if (loaiCanXoa != null)
        {
            dsLoaiBangDia.Remove(loaiCanXoa);
            Console.WriteLine("Xoa thong tin loai bang dia thanh cong.");
        }
        else
        {
            Console.WriteLine("Khong tim thay ma loai can xoa.");
        }
    }

    static void QuanLyBangDia()
    {
        Console.WriteLine("Chon chuc nang quan ly bang dia:");
        Console.WriteLine("1. Them bang dia");
        Console.WriteLine("2. Sua bang dia");
        Console.WriteLine("3. Xoa bang dia");
        Console.WriteLine("0. Quay lai");

        int chon;
        if (int.TryParse(Console.ReadLine(), out chon))
        {
            switch (chon)
            {
                case 1:
                    ThemBangDia();
                    break;
                case 2:
                    SuaBangDia();
                    break;
                case 3:
                    XoaBangDia();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nhap khong hop le. Vui long nhap so.");
        }
    }

    static void ThemBangDia()
    {
        Console.WriteLine("Nhap ma bang dia:");
        string maBangDia = Console.ReadLine();
        Console.WriteLine("Nhap ten bang dia:");
        string tenBangDia = Console.ReadLine();
        Console.WriteLine("Nhap ma loai bang dia:");
        string maLoaiBangDia = Console.ReadLine();
        Console.WriteLine("Nhap ngay tao (yyyy-MM-dd):");
        DateTime ngayNhap;
        while (!DateTime.TryParse(Console.ReadLine(), out ngayNhap))
        {
            Console.WriteLine("Nhap khong hop le. Vui long nhap lai NgayTao:");
        }
        BangDia bangDia = new BangDia(maBangDia, tenBangDia, maLoaiBangDia, ngayNhap);
        dsBangDia.Add(bangDia);
        Console.WriteLine("Them Bang Dia thanh cong.");
    }

    static void SuaBangDia()
    {
        Console.WriteLine("Nhap ma bang dia can sua:");
        string maBangDiaSua = Console.ReadLine();
        BangDia bangDiaCanSua = dsBangDia.FirstOrDefault(bangDia => bangDia.MaBangDia == maBangDiaSua);
        if (bangDiaCanSua != null)
        {
            Console.WriteLine("Nhap ten bang dia moi:");
            bangDiaCanSua.TenBangDia = Console.ReadLine();
            Console.WriteLine("Nhap ma loai bang dia moi:");
            bangDiaCanSua.MaLoaiBangDia = Console.ReadLine();
            Console.WriteLine("Nhap ngay tao moi (yyyy-MM-dd):");
            DateTime ngayNhap;
            while (!DateTime.TryParse(Console.ReadLine(), out ngayNhap))
            {
                Console.WriteLine("Nhap khong hop le. Vui long nhap lai NgayTao:");
            }
            bangDiaCanSua.NgayTao = ngayNhap;
            Console.WriteLine("Sua thong tin bang dia thanh cong.");
        }
        else
        {
            Console.WriteLine("Khong tim thay ma bang dia can sua.");
        }
    }

    static void XoaBangDia()
    {
        Console.WriteLine("Nhap ma bang dia can xoa:");
        string maBangDiaXoa = Console.ReadLine();
        BangDia bangDiaCanXoa = dsBangDia.FirstOrDefault(bangDia => bangDia.MaBangDia == maBangDiaXoa);
        if (bangDiaCanXoa != null)
        {
            dsBangDia.Remove(bangDiaCanXoa);
            Console.WriteLine("Xoa thong tin bang dia thanh cong.");
        }
        else
        {
            Console.WriteLine("Khong tim thay ma bang dia can xoa.");
        }
    }

    static void TimKiemBangDia()
    {
        Console.WriteLine("Nhap ma loai hoac ma bang dia can tim:");
        string keyword = Console.ReadLine();
        var ketQua = dsBangDia.Where(bangDia => bangDia.MaLoaiBangDia == keyword || bangDia.MaBangDia == keyword);
        InKetQuaTimKiemBangDia(ketQua);
    }

    static void TimKiemTheoTen()
    {
        Console.WriteLine("Nhap ten bang dia can tim:");
        string keyword = Console.ReadLine();
        var ketQua = dsBangDia.Where(bangDia => bangDia.TenBangDia.ToLower().Contains(keyword.ToLower()));
        InKetQuaTimKiemBangDia(ketQua);
    }

    static void InKetQuaTimKiemBangDia(IEnumerable<BangDia> ketQua)
    {
        foreach (var bangDia in ketQua)
        {
            Console.WriteLine(bangDia);
        }
    }

    static void InThongKe()
    {
        Console.WriteLine("In thong ke danh sach bang dia group by MaLoai ra file vat ly.");
        Console.WriteLine("Nhap ten file de luu thong ke:");
        string tenFile = Console.ReadLine();

        try
        {
            using (StreamWriter sw = new StreamWriter(tenFile))
            {
                var thongKe = dsBangDia.GroupBy(bangDia => bangDia.MaLoaiBangDia)
                                       .Select(grp => new
                                       {
                                           MaLoai = grp.Key,
                                           SoLuong = grp.Count()
                                       });

                foreach (var item in thongKe)
                {
                    sw.WriteLine($"MaLoai: {item.MaLoai}, SoLuong: {item.SoLuong}");
                }

                Console.WriteLine($"In thong ke thanh cong. Xem file {tenFile}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Co loi xay ra: {ex.Message}");
        }
    }
}
