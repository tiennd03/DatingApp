using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0206266_BuiXuanTien_1
{
    internal class BangDia
    {
        public string MaBangDia { get; set; }
        public string TenBangDia { get; set; }
        public string MaLoaiBangDia { get; set; }
        public DateTime NgayTao { get; set; }
        public BangDia(string maBangDia, string tenBangDia, string maLoaiBangDia, DateTime ngayTao)
        {
            MaBangDia = maBangDia;
            TenBangDia = tenBangDia;
            MaLoaiBangDia = maLoaiBangDia;
            NgayTao = ngayTao;
        }
        public override string ToString()
        {
            return $"MaBangDia: {MaBangDia}, TenBangDia: {TenBangDia}, MaLoaiBangDia:{MaLoaiBangDia}, NgayTao{NgayTao.ToShortDateString()}";
        }
    }
}
