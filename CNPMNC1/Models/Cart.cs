using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC1.Models
{
    public class CartItem
    {
        public SanPham sanPham { get; set; }
        public int quantity { get; set; }
    }
    public class Cart
    {
        public Nullable<decimal> giamgia { get; set; }
        public string phuongthuctt { get; set; }
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items { get { return items; } }
        public void Add_Product_Cart(SanPham pro, int quan = 1)
        {
            var item = Items.FirstOrDefault(s => s.sanPham.idsanpham == pro.idsanpham);
            if (item == null) items.Add(new CartItem { sanPham = pro, quantity = quan });
            else item.quantity += quan;
        }
        public int Total_quantity()
        {
            return items.Sum(s => s.quantity);
        }
        public decimal Total_money()
        {
            var total = items.Sum(s => s.quantity * s.sanPham.gia);
            return (decimal)total;
        }
        public void Update_quantity(string id, int new_quan)
        {
            var item = items.Find(s => s.sanPham.idsanpham == id);
            if (item != null)
                item.quantity = new_quan;
        }
        public void Remove_cartitem(string id)
        {
            items.RemoveAll(s => s.sanPham.idsanpham == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}