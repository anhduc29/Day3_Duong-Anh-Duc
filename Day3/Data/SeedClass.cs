using Day3.Models;

namespace Day3.Data
{
    public class SeedClass
    {
        public static List<Category> categories = new List<Category>
        {
            new Category() { Id = 1, Name = "Category 1", Description = "Description for Category 1" },
            new Category() { Id = 2, Name = "Category 2", Description = "Description for Category 2" },
            new Category() { Id = 3, Name = "Category 3", Description = "Description for Category 3" }
        };
    }
}