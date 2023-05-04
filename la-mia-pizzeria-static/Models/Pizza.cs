namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string ImgPath { get; set; }
        public decimal Price { get; set; }

        public static void Seed()
        {
            using (PizzaContext db = new PizzaContext())
            {
                var seed = new Pizza[]
                {
                    new Pizza
                    {
                        Name = "Marinara",
                        Ingredients = "Pomodoro, origano, aglio, olio",
                        ImgPath = "~/img/marinara.jpg",
                        Price = 4.00m
                    },
                    new Pizza
                    {
                        Name = "Margherita",
                        Ingredients = "Pomodoro, mozzarella",
                        ImgPath = "~/img/margherita.jpg",
                        Price = 4.00m
                    },
                    new Pizza
                    {
                        Name = "Capricciosa",
                        Ingredients = "Pomodoro, mozzarella, funghi, olive, capperi",
                        ImgPath = "~/img/capricciosa.jpg",
                        Price = 4.00m
                    }
                };

                db.AddRange(seed);
                db.SaveChanges();
            }
        }
    }
}
