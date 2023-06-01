using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToySalesManager.DTO
{
    class SanPhamDTO
    {
        private string _tensp, _dvt, _ngaysx, _ngayhethan, _hinh;
        private int _masp, _maloaisp, _mancc, _gianhap, _giaban, _soluong, _khuyenmai, _loinhuan, _ngungkinhdoanh;

        public string Tensp
        {
            get
            {
                return _tensp;
            }

            set
            {
                _tensp = value;
            }
        }

        public string Dvt
        {
            get
            {
                return _dvt;
            }

            set
            {
                _dvt = value;
            }
        }

        public string Ngaysx
        {
            get
            {
                return _ngaysx;
            }

            set
            {
                _ngaysx = value;
            }
        }

        public string Ngayhethan
        {
            get
            {
                return _ngayhethan;
            }

            set
            {
                _ngayhethan = value;
            }
        }

        public string Hinh
        {
            get
            {
                return _hinh;
            }

            set
            {
                _hinh = value;
            }
        }

        public int Masp
        {
            get
            {
                return _masp;
            }

            set
            {
                _masp = value;
            }
        }

        public int Maloaisp
        {
            get
            {
                return _maloaisp;
            }

            set
            {
                _maloaisp = value;
            }
        }

        public int Mancc
        {
            get
            {
                return _mancc;
            }

            set
            {
                _mancc = value;
            }
        }

        public int Gianhap
        {
            get
            {
                return _gianhap;
            }

            set
            {
                _gianhap = value;
            }
        }

        public int Giaban
        {
            get
            {
                return _giaban;
            }

            set
            {
                _giaban = value;
            }
        }

        public int Soluong
        {
            get
            {
                return _soluong;
            }

            set
            {
                _soluong = value;
            }
        }

        public int Khuyenmai
        {
            get
            {
                return _khuyenmai;
            }

            set
            {
                _khuyenmai = value;
            }
        }

        public int Loinhuan
        {
            get
            {
                return _loinhuan;
            }

            set
            {
                _loinhuan = value;
            }
        }

        public int Ngungkinhdoanh
        {
            get
            {
                return _ngungkinhdoanh;
            }

            set
            {
                _ngungkinhdoanh = value;
            }
        }

        public SanPhamDTO()
        {
            this.Tensp = "";
            this.Dvt = "";
            this.Ngaysx = "";
            this.Ngayhethan = "";
            this.Hinh = "";
            this.Masp = 0;
            this.Maloaisp = 0;
            this.Mancc = 0;
            this.Gianhap = 0;
            this.Giaban = 0;
            this.Soluong = 0;
            this.Khuyenmai = 0;
            this.Loinhuan = 0;
            this.Ngungkinhdoanh = 0;
        }
        public SanPhamDTO(string _tensp, string _dvt, string _ngaysx, string _ngayhethan, string _hinh, int _masp, int _maloaisp, int _mancc, int _gianhap, int _giaban, int _soluong, int _khuyenmai, int _loinhuan, int _ngungkinhdoanh)
        {
            this.Tensp = _tensp;
            this.Dvt = _dvt;
            this.Ngaysx = _ngaysx;
            this.Ngayhethan = _ngayhethan;
            this.Hinh = _hinh;
            this.Masp = _masp;
            this.Maloaisp = _maloaisp;
            this.Mancc = _mancc;
            this.Gianhap = _gianhap;
            this.Giaban = _giaban;
            this.Soluong = _soluong;
            this.Khuyenmai = _khuyenmai;
            this.Loinhuan = _loinhuan;
            this.Ngungkinhdoanh = _ngungkinhdoanh;
        }

    }
}
