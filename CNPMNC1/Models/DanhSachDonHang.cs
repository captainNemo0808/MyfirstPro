using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC1.Models
{
    public class DanhSachDonHang
    {
         public string ID { get; set; }
         public string IDkhachhang { get; set; }
         public string Tinhtrang { get; set; }
         public DateTime ngaydathang { get; set; }
         public Nullable<decimal> tongtien {  get; set; }
         public string phuongthuctt { get; set; }
    }
}