using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages                 // sürekli new yapmamak için static yaptık
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime= "Sistem bakımda";
        public static string ProductsListed = "Ürünler liselendi";
        public static string ProductCounToCategoryError= "Bu katagoride 10 dan fazla ürün olmaz.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var.";
        public  static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemez.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
