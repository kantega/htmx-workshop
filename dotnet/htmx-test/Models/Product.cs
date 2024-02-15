using System;
namespace htmx_test.Models
{
	public class Product
	{	
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int inStock { get; set; }
        public int inCart { get; set; }
    }
	
}

