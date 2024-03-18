using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CNPMNC1.Models
{
    public class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            //this.OrderDetails = new HashSet<>();
            ImagePro = "~/Content/images/1.jpg";
        }

        public string idsanpham { get; set; }
        public string tensanpham { get; set; }
        public string thuonghieu { get; set; }
        public string namsx { get; set; }
        public string mota { get; set; }
        public string loai_sanpham { get; set; }
        public Nullable<decimal> gia { get; set; }
        public string ImagePro { get; set; }
        public Nullable<decimal> giamgia { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}