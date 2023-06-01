using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToySalesManager.DTO
{
    class NhapHangDTO
    {
        private int _maphieu, _stt, _mancc, _sl, _masp, _gianhap;
        private string _ngaylap, _manv,_trangthai;

        public NhapHangDTO()
        {
            this.Maphieu = 0;
            this.Stt = 0;
            this.Mancc = 0;
            this.Sl = 0;
            this.Masp = 0;
            this.Gianhap = 0;
            this.Ngaylap = "";
            this.Manv = "";
            this.Trangthai = "";
        }

        public NhapHangDTO(int _maphieu, int _stt, int _mancc, int _sl, int _masp, int _gianhap, string _ngaylap, string _manv, string _trangthai)
        {
            this.Maphieu = _maphieu;
            this.Stt = _stt;
            this.Mancc = _mancc;
            this.Sl = _sl;
            this.Masp = _masp;
            this.Gianhap = _gianhap;
            this.Ngaylap = _ngaylap;
            this.Manv = _manv;
            this.Trangthai = _trangthai;
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

        public int Maphieu
        {
            get
            {
                return _maphieu;
            }

            set
            {
                _maphieu = value;
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

        public string Trangthai
        {
            get
            {
                return _trangthai;
            }

            set
            {
                _trangthai = value;
            }
        }
    }
}
