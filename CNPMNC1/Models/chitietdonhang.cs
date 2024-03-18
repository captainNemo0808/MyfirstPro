using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC1.Models
{
    public class chitietdonhang
    {
        public string id { get; set; }
        public string iddanhsachdh {  get; set; }
        public string tensanpham { get; set; }
        public string thuonghieu { get; set; }
        public string namsx { get; set; }
        public string mota { get; set; }
        public string loai_sanpham { get; set; }
        public Nullable<decimal> gia { get; set; }
        public string ImagePro { get; set; }
        public string idsanpham {  get; set; }
        public int soluong {  get; set; }
        public Nullable<decimal> tongtien {  get; set; }
    }
}