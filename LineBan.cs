using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLIBIDA
{
    public class LineBan
    {
        public int Gio { get; set; }
        public int Phut { get; set; }
        public LineBan()
        {

        }
        public LineBan(double thoiGian)
        {
            var tg = LayGio(thoiGian);
            Gio = (int)tg;//ví dụ: 8.513 ---> 8h
            Phut =(int)((tg - Math.Truncate(tg))*60);
        }
        public double LayGio(double thoiGian)
        {
            //ví dụ: 8.51234123 ---> 8.5h
            return Math.Round(thoiGian, 1);
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}", Gio, Phut);
        }
        public int ThanhTien(double thoiGian, int donGia)
        {
            return (int)(LayGio(thoiGian) * donGia);
        }
    }
}
