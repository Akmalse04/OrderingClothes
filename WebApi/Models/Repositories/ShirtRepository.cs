namespace WebApi.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
           new Shirt {ShirtId=1, Brand="My Brand", Color="Blue", Gender="Men",Price=30,Size=10},
            new Shirt {ShirtId=2, Brand="My Brand", Color="Black", Gender="Men",Price=36,Size=12},
            new Shirt {ShirtId=3,Brand="Your brand",Color="Pink",Gender="Women",Price=28,Size=8},
             new Shirt {ShirtId=4, Brand="Your Brand", Color="Yellow", Gender="women",Price=30,Size=9},
        };
        public static List<Shirt> GetShirts()
        {
            return shirts;
        }
        public static bool ShirtExist(int id)
        {
            return shirts.Any(x=>x.ShirtId == id);
        }
        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
              !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
              !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value);
        }
        public static void AddShirt(Shirt shirt)
        {
            int maxId =shirts.Max(x=> x.ShirtId);
            shirt.ShirtId = maxId+1;
            shirts.Add(shirt);  
        }
        public static void UpdateShirt(Shirt shirt)
        {
            var shirttoUpdate=shirts.First(x=>x.ShirtId==shirt.ShirtId);
            shirttoUpdate.Brand = shirt.Brand;
            shirttoUpdate.Price=shirt.Price;
            shirttoUpdate.Size = shirt.Size;
            shirttoUpdate.Color = shirt.Color;
            shirttoUpdate.Gender=shirt.Gender;
        }
        public static void DeleteShirt(int shirtId) { 
            var shirt=GetShirtById(shirtId);
            if (shirt != null)
            {
                shirts.Remove(shirt);
            }
        }
    }
}
