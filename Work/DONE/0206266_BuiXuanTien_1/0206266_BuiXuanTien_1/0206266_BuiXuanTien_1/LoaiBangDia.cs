using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0206266_BuiXuanTien_1
{
    internal class LoaiBangDia
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string GhiChu { get; set; }

        public LoaiBangDia(string maLoai, string tenLoai, string ghiChu)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
            GhiChu = ghiChu;
        }
    }
}
