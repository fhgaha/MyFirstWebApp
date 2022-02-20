using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductModelDTO
    {
        [DisplayName("ID number")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Cost to Customer")]
        public decimal Price { get; set; }

        public string PriceString { get; set; }

        [DisplayName("What you get...")]
        public string Description { get; set; }

        public string ShortDescription { get; set; }
        public decimal Tax { get; set; }

        public ProductModelDTO()
        {

        }

        public ProductModelDTO(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;

            PriceString = string.Format("{0:C}", price); //"{0:C}" formats as currency
            ShortDescription = description.Length <= 25 ? description : description.Substring(0, 25);
            Tax = price * 0.08m;
        }

        public ProductModelDTO(ProductModel p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            PriceString = string.Format("{0:C}", p.Price); //"{0:C}" formats as currency
            ShortDescription = p.Description.Length <= 25 ? p.Description : p.Description.Substring(0, 25);
            Tax = p.Price * 0.08m;
        }
    }
}
