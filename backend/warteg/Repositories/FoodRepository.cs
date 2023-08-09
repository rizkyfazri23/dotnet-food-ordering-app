using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; 
using warteg.Models; 
using warteg.Data; 


namespace warteg.Repositories
{
    public class FoodRepository
    {
        private readonly WartegDbContext _dbContext;

        public FoodRepository(WartegDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Food> SearchFoodByName(string keyword)
        {
            return _dbContext.Foods
                .Where(food => food.Name.Contains(keyword))
                .ToList();
        }

        public Food GetFoodById(int foodId)
        {
            return _dbContext.Foods.FirstOrDefault(food => food.Id == foodId);
        }

        public List<Food> GetAllFood()
        {
            return _dbContext.Foods.ToList(); 
        }

    }
}
