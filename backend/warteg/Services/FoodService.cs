using System;
using System.Collections.Generic;
using warteg.Models; 
using warteg.Repositories;


namespace warteg.Services
{
    public class FoodService
    {
        private readonly FoodRepository _foodRepository;

        public FoodService(FoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public List<Food> SearchFoodByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("Keyword cannot be empty.");
            }

            return _foodRepository.SearchFoodByName(keyword);
        }

        public Food GetFoodById(int foodId)
        {
            if (foodId <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid food ID.");
            }

            return _foodRepository.GetFoodById(foodId);
        }

        public List<Food> GetAllFood()
        {
            return _foodRepository.GetAllFood(); 
        }

    }
}
