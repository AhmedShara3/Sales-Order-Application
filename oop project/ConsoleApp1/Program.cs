using System;
using System.Collections.Generic;


namespace Sales 
{
    class Stock
    {
       private List<Product> products = new List<Product>();

         public void AddProduct(Product product)
        {
        products.Add(product);
        }
      
       public void RemoveAll(int id)
       {
            products.RemoveAll(p =>p.Id == id);
       }

       public void SearchProduct(int id )
       {
        products.Find(p=>p.Id == id);

       } 

       public void PrintStock()
       {
        System.Console.WriteLine("The Stock List is :");
        for(int i = 0 ;i<products.Count ; i++)
        {
            System.Console.WriteLine(products[i]);
         }

       }   
    }
    class Product 
    {
        public int Id{set;get;} 
        public int Quantity {set ; get ;}
        public string Name {set ; get ;}
        public double Price {set;get;}

        public Product(int id , int quantity , string name , double price)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Name = name;
            this.Price = price;
        }
         public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
    }
         
    }

    class Customer
    {
        public int Id {set ; get;}
        public string Name {set ; get ;}

        public Customer(int id , string name)
        {
            this.Id  = id ;
            this.Name  = name;
        }
        public override string ToString()
        {
            return $"ID :{Id} , Name : {Name}" ;   
        }
    }
    class Order
    {
        public int OrderNumber{set;get;}
        public DateTime OrderTime {set; get;}
        public string Status {set ; get;} 

        public Order()
        {
            OrderNumber = new Random().Next(1,100000);
            OrderTime =  DateTime.Now;
            Status = "New";
        }
        public void UpdateStatus(String status)
        {
            Status = status;
        }
        public override string ToString()
        {
            return $"Order no. : {OrderNumber}  , Date: {OrderTime}, Status: {Status}" ;
        }
    }

    class Transaction
    {
        public Order Order {set ; get;}
        public double AmountPaid {set ; get ;}
        public string PymentMethod {set; get;}

        public Transaction( Order order,int amountpaid ,string paymentmethod)
        {
            this.Order = order;
            this.AmountPaid = amountpaid;
            this.PymentMethod = paymentmethod;

        }


        class Program 
        {
            public static void Main()
            {   var stock = new Stock();
                var customers = new List<Customer>();
                var transactions = new List<Transaction>();


                
                bool running = true;
                while(running =true)
                {   
                    Console.WriteLine("\nSales Order Application");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. View Stock");
                    Console.WriteLine("3. Add Customer");
                    Console.WriteLine("4. View Customers");
                    Console.WriteLine("5. Create Order");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an option: ");

                    int choice = int.Parse(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                        Console.Write("Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Product Price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("Enter Product Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        stock.AddProduct(new Product(id, quantity, name, price));
                        break ;
                       
                        case 2 :
                        stock.PrintStock();
                        break;
                         
                        case 3 :
                        System.Console.WriteLine("Enter customer id :");
                        int customerId = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Enter customer name :");
                        string customerName = Console.ReadLine();
                        customers.Add(new Customer(customerId, customerName));
                        break;
                        
                        
                        case 4 :
                        System.Console.WriteLine("Customer List :");
                        foreach(var customer in customers)
                        System.Console.WriteLine(customer);
                        break;

                        case 5 :
                        Order newOrder = new Order();
                        Console.WriteLine("Order Created: " + newOrder);
                        transactions.Add(new Transaction(newOrder, 0, "Pending"));
                        break;

                         case 6:
                        running = false;
                        break;
                        default:
                        Console.WriteLine("Invalid Option!");
                        break;


                    }
                }


            }
        }

    }
}
