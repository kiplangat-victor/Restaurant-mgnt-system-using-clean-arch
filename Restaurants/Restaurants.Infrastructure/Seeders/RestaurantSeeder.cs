using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder : IRestaurantSeeder
    {
        private readonly RestaurantsDbContext _dbContext;

        public RestaurantSeeder(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public Task seed()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            return new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (a short of Kentucky Fried Chicken) is a fast food chain restaurant",
                    ContactEmail = "rest@gmail.com",
                    ContactNumber = "254789898989",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Kigen Hot Chicken",
                            Description = "Kigen Hot chickens(10pcs)",
                            Price = "KES 900"
                        },
                        new Dish
                        {
                            Name = "Nuget Hot Chicken",
                            Description = "Kigen Hot chickens(10pcs)",
                            Price = "KES 234"
                        },
                        new Dish
                        {
                            Name = "Kigen Hot Chicken",
                            Description = "Kigen Hot chickens(10pcs)",
                            Price = "KES 900"
                        }
                    },
                    Address = new Address
                    {
                        City = "Kipkoibet",
                        Street = "Konoin constituency",
                        PostalCode = "90 Mogogosiek"
                    }
                },
                new Restaurant
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (a short of Kentucky Fried Chicken) is a fast food chain restaurant",
                    ContactEmail = "rest@gmail.com",
                    ContactNumber = "254789898989",
                    HasDelivery = true,
                    Address = new Address
                    {
                        City = "Kipkoibet",
                        Street = "Konoin constituency",
                        PostalCode = "90 Mogogosiek"
                    }
                }
            };
        }
    }
}
