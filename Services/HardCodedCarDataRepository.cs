using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class HardCodedCarDataRepository
    {
        static List<CarModel> cars = new List<CarModel>();

        public HardCodedCarDataRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                cars.Add(new Faker<CarModel>()
                    .RuleFor(car => car.Id, i)
                    .RuleFor(c => c.Model, f => f.Lorem.Word().ToUpper())
                    .RuleFor(c => c.Price, f => f.Random.Decimal(1000m, 5000m))
                    .RuleFor(c => c.Producer, f => f.Company.CompanyName())
                    .RuleFor(c => c.ProductionCountry, f => f.Address.Country())
                    .RuleFor(c => c.ProductionDate, f => f.Date.Past(200).Year)
                    );
            }
        }

        public int Delete(CarModel product)
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetAllProducts()
        {
            return cars;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(CarModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(CarModel product)
        {
            throw new NotImplementedException();
        }
    }
}
