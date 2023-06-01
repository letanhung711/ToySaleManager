using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToySalesManager.DTO
{
    class NCC_LoaiSPDTO
    {
        private string _maloaisp, _tenloaisp, _mancc, _tenncc, _diachi, _sdt;
        private int _ngungkinhdoanh, _ngunghoptac;

        public NCC_LoaiSPDTO()
        {
            this.Maloaisp = "";
            this.Tenloaisp = "";
            this.Mancc = "";
            this.Tenncc = "";
            this.Diachi = "";
            this.Sdt = "";
            this.Ngungkinhdoanh = 0;
            this.Ngunghoptac = 0;
        }

        public NCC_LoaiSPDTO(string _maloaisp, string _tenloaisp, string _mancc, string _tenncc, string _diachi, string _sdt, int _ngungkinhdoanh, int _ngunghoptac)
        {
            this.Maloaisp = _maloaisp;
            this.Tenloaisp = _tenloaisp;
            this.Mancc = _mancc;
            this.Tenncc = _tenncc;
            this.Diachi = _diachi;
            this.Sdt = _sdt;
            this.Ngungkinhdoanh = _ngungkinhdoanh;
            this.Ngunghoptac = _ngunghoptac;
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

        public string Maloaisp
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

        public string Mancc
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

        public int Ngunghoptac
        {
            get
            {
                return _ngunghoptac;
            }

            set
            {
                _ngunghoptac = value;
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

        public string Tenloaisp
        {
            get
            {
                return _tenloaisp;
            }

            set
            {
                _tenloaisp = value;
            }
        }

        public string Tenncc
        {
            get
            {
                return _tenncc;
            }

            set
            {
                _tenncc = value;
            }
        }
    }
}
