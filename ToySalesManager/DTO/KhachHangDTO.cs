using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToySalesManager.DTO
{
    class KhachHangDTO
    {
        private string _makh, _hoten, _sdt, _diachi, _gioitinh, _ngaydangky, _daxoa;

        public KhachHangDTO()
        {
            this._makh = "";
            this._hoten = "";
            this._sdt = "";
            this._diachi = "";
            this._gioitinh = "";
            this._ngaydangky = "";
            this._daxoa = "";
        }

        public KhachHangDTO(string _makh, string _hoten, string _sdt, string _diachi, string _gioitinh, string _ngaydangky, string _daxoa)
        {
            this._makh = _makh;
            this._hoten = _hoten;
            this._sdt = _sdt;
            this._diachi = _diachi;
            this._gioitinh = _gioitinh;
            this._ngaydangky = _ngaydangky;
            this._daxoa = _daxoa;
        }

        public string Daxoa
        {
            get
            {
                return _daxoa;
            }

            set
            {
                _daxoa = value;
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

        public string Gioitinh
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

        public string Ngaydangky
        {
            get
            {
                return _ngaydangky;
            }

            set
            {
                _ngaydangky = value;
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
    }
}
