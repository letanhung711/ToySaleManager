using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToySalesManager.DTO
{
    class HoaDonDTO
    {
        private int _sohd, _thanhtien, _tienkhachtra, _dathanhtoan, _stt, _masp, _dongia, _khuyenmai, _sl;
        private string _ngaylap, _makh, _manv;

        public int Sohd
        {
            get
            {
                return _sohd;
            }

            set
            {
                _sohd = value;
            }
        }

        public int Thanhtien
        {
            get
            {
                return _thanhtien;
            }

            set
            {
                _thanhtien = value;
            }
        }

        public int Tienkhachtra
        {
            get
            {
                return _tienkhachtra;
            }

            set
            {
                _tienkhachtra = value;
            }
        }

        public int Dathanhtoan
        {
            get
            {
                return _dathanhtoan;
            }

            set
            {
                _dathanhtoan = value;
            }
        }

        public int Stt
        {
            get
            {
                return _stt;
            }

            set
            {
                _stt = value;
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

        public int Dongia
        {
            get
            {
                return _dongia;
            }

            set
            {
                _dongia = value;
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

        public int Sl
        {
            get
            {
                return _sl;
            }

            set
            {
                _sl = value;
            }
        }

        public string Ngaylap
        {
            get
            {
                return _ngaylap;
            }

            set
            {
                _ngaylap = value;
            }
        }

        public string Makh
        {
            get
            {
                return _makh;
            }

            set
            {
                _makh = value;
            }
        }

        public string Manv
        {
            get
            {
                return _manv;
            }

            set
            {
                _manv = value;
            }
        }

        public HoaDonDTO()
        {
            this.Sohd = 0;
            this.Thanhtien = 0;
            this.Tienkhachtra = 0;
            this.Dathanhtoan = 0;
            this.Stt = 0;
            this.Masp = 0;
            this.Dongia = 0;
            this.Khuyenmai = 0;
            this.Sl = 0;
            this.Ngaylap = "";
            this.Makh = "";
            this.Manv = "";
        }

        public HoaDonDTO(int _sohd, int _thanhtien, int _tienkhachtra, int _dathanhtoan, int _stt, int _masp, int _dongia, int _khuyenmai, int _sl, string _ngaylap, string _makh, string _manv)
        {
            this.Sohd = _sohd;
            this.Thanhtien = _thanhtien;
            this.Tienkhachtra = _tienkhachtra;
            this.Dathanhtoan = _dathanhtoan;
            this.Stt = _stt;
            this.Masp = _masp;
            this.Dongia = _dongia;
            this.Khuyenmai = _khuyenmai;
            this.Sl = _sl;
            this.Ngaylap = _ngaylap;
            this.Makh = _makh;
            this.Manv = _manv;
        }
    }
}
