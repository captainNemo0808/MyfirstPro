using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC1.Models
{
    public class DoanhThu
    {
        public string ID { get; set; }
        public DateTime ngaythanhtoan {  get; set; }
        public Nullable<decimal> tongtien { get; set; }
        public string idkh { get; set; }
    }
}