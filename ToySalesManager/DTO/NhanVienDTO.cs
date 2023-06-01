using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToySalesManager.DTO
{
    class NhanVienDTO
    {
        private string _manv, _hoten, _email, _sdt, _matkhau,_ngaysinh,_diachi,_quyen,_hinh;
        private int _gioitinh,_dathoiviec;

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

        public string Hoten
        {
            get
            {
                return _hoten;
            }

            set
            {
                _hoten = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Sdt
        {
            get
            {
                return _sdt;
            }

            set
            {
                _sdt = value;
            }
        }

        public string Matkhau
        {
            get
            {
                return _matkhau;
            }

            set
            {
                _matkhau = value;
            }
        }

        public string Ngaysinh
        {
            get
            {
                return _ngaysinh;
            }

            set
            {
                _ngaysinh = value;
            }
        }

        public string Diachi
        {
            get
            {
                return _diachi;
            }

            set
            {
                _diachi = value;
            }
        }

        public string Quyen
        {
            get
            {
                return _quyen;
            }

            set
            {
                _quyen = value;
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

        public int Gioitinh
        {
            get
            {
                return _gioitinh;
            }

            set
            {
                _gioitinh = value;
            }
        }

        public int Dathoiviec
        {
            get
            {
                return _dathoiviec;
            }

            set
            {
                _dathoiviec = value;
            }
        }

        public NhanVienDTO()
        {
            this.Manv = "";
            this.Hoten = "";
            this.Email = "";
            this.Sdt = "";
            this.Matkhau = "";
            this.Ngaysinh = "";
            this.Diachi = "";
            this.Quyen = "";
            this.Hinh = "";
            this.Gioitinh = 0;
            this.Dathoiviec = 0;
        }

        public NhanVienDTO(string _manv, string _hoten, string _email, string _sdt, string _matkhau, string _ngaysinh, string _diachi, string _quyen, string _hinh, int _gioitinh, int _dathoiviec)
        {
            this.Manv = _manv;
            this.Hoten = _hoten;
            this.Email = _email;
            this.Sdt = _sdt;
            this.Matkhau = _matkhau;
            this.Ngaysinh = _ngaysinh;
            this.Diachi = _diachi;
            this.Quyen = _quyen;
            this.Hinh = _hinh;
            this.Gioitinh = _gioitinh;
            this.Dathoiviec = _dathoiviec;
        }
    }
}
