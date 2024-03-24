using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ИтогООП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Castomer castomer1 = new Castomer ("Красноармейская 34",85647485, "Иван");
            Castomer castomer2 = new Castomer("Борисова 3", 37463538, "Елена");
            Shop shop1 = new Shop("Ostrova", "Крупская 7");
            Shop shop = new Shop("","");


            Product product1 = new Product("23", "15000 p.", 1, "Куртка зимняя", "3 дня");
            Product product2 = new Product("56", "1600 p.", 3, "Перчатки, носки, набор наклеек", "от 7 дней");
            Product product3 = new Product("34", "30000 p.", 1, "Велосипед", "12 часов");

            Courier courier1 = new Courier(736463782, "Василий");
            Courier courier2 = new Courier(456436238, "Дмитрий");
            Courier courier3 = new Courier(456436238, "Дмитрий");
            HomeDelivery homeDelivery = new HomeDelivery(castomer1.Name, castomer1.Address);
            PickPointDelivery pickPointDelivery = new PickPointDelivery("21 день",castomer2.Name, castomer2.Address);
            ShopDelivery shopDelivery = new ShopDelivery(shop1.Name,"Ирина", shop1.Address);

            Order<HomeDelivery> order1 = new Order<HomeDelivery>(homeDelivery, 1, product1, courier1, shop = null,castomer1);
            Order<PickPointDelivery> order2 = new Order<PickPointDelivery>(pickPointDelivery, 2, product2,  courier2, shop=null, castomer2);
            Order<ShopDelivery> order3 = new Order<ShopDelivery>(shopDelivery, 3, product3,  courier3, shop1);

            order1.OrderInformation();
            Console.WriteLine();
            order2.OrderInformation();
            Console.WriteLine();
            order3.OrderInformation();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    abstract class Delivery
    {
        public string Address;
        public Delivery(string address) 
        {
            Address = address;
        }
    }

    class HomeDelivery : Delivery
    {
        public string ClientName;
        public HomeDelivery(string clientName, string address) : base(address) 
        {
            ClientName = clientName;
        }
    }

    class PickPointDelivery : Delivery
    {
        public string ClientName;
        public string StorageTime;
        public PickPointDelivery(string storageTime, string clientName, string address) : base(address) 
        {
            StorageTime = storageTime;
            ClientName = clientName;
        }
    }

    class ShopDelivery : Delivery
    {
        public string ClientName;
        public string ShopName;
        
        public ShopDelivery(string shopName, string clientName, string address) : base (address) 
        {
            ClientName = clientName;
            ShopName = shopName;
        }
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        
        public Product product;
        public Castomer castomer;
        public Courier courier;
        public Shop shop;
        



        public void OrderInformation()
        {
            if (Delivery is PickPointDelivery)
            {
                Console.WriteLine("Доставка в пункт выдачи");
            }
            if (Delivery is ShopDelivery)
            {
                Console.WriteLine("Доставка в магазин");
            }
            if (Delivery is HomeDelivery)
            {
                Console.WriteLine("Доставка на дом");
            }
            if (courier != null) 
            {
                Console.WriteLine("Имя курьера:" + courier.Name);
            }
            Console.WriteLine("Номер заказа:" + product.Number);
            if (castomer != null) 
            {   Console.WriteLine("Имя покупателя:" + castomer.Name);
                Console.WriteLine("Время доставки:" + product.Time);
            }
            Console.WriteLine("Содержание заказа:" + product.Description);
            Console.WriteLine("Цена заказа:" + product.Price);
            Console.WriteLine("Время доставки:" + product.Time);
            if (shop != null) { Console.WriteLine("Магазин:" + shop.Name +", "+ shop.Address); }
            
            

        }
        public Order(TDelivery delivery, int number, Product product, Courier courier, Shop shop = null,Castomer castomer = null)
        {
            Delivery = delivery;
            Number = number;
            this.courier = courier; 
            this.product = product;
            this.shop = shop;
            this.castomer = castomer;
            
            
        }
    }
    class Courier 
    {
        public int Phone;
        public string Name;
        public Courier(int pnone, string name)
        {
            Phone = pnone;
            Name = name;
        }
    }
    class Shop
    {
        public string Name;
        public string Address;
        public Shop(string name, string address) 
        { 
            Name = name;
            Address = address;
                
        }

    }
    class Castomer 
    {
        public string Address;
        public int Phone;
        public string Name;
        
        public Castomer(string address, int phone, string name)
        {
            Address = address;
            Phone = phone;
            Name = name;
            
            
        }
    }
    class Product 
    {
        public string Number;
        public string Price;
        public int Count;
        public string Description;
        public string Time;
        public Product(string number, string price, int count, string description, string time)
        {
            Number = number;
            Price = price;
            Count = count;
            Description = description;
            Time = time;

        }
    }
}
