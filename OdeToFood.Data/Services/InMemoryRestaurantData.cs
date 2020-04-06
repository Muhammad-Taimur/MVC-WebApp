﻿using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;
        
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Cusine=CusineType.italian},
                new Restaurant {Id = 2, Name = "Taimur", Cusine=CusineType.Indian},
                new Restaurant {Id = 3, Name = "Mango Grove", Cusine=CusineType.French}
            };

        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id)+1;        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cusine = restaurant.Cusine;

            }
        }
    }
}
