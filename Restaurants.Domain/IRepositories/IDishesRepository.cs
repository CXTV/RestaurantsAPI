using Restaurants.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.IRepositories
{
    public interface IDishesRepository
    {
        Task<int> CreateDishAsync(Dish dish);
    }
}
