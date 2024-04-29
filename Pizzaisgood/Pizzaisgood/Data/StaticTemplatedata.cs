using Pizzaisgood.Model;

namespace Pizzaisgood.Data
{
    public static class StaticTemplatedata
    {

        public static List<DataitemsModel> Datafill = new()
        {
            new DataitemsModel() {Name = "Bacon",
                Description = "Indulge in the irresistible flavors of our Bacon Pizza, a savory delight that combines classic ingredients with the smoky richness of crispy bacon. Each bite is a harmonious blend of tangy tomato sauce, melty mozzarella cheese, and perfectly cooked bacon pieces, creating a mouthwatering experience that satisfies your pizza cravings" ,
                ItemPrice = 12.00M,ImageUrl = "img/pizzas/bacon.jpg", CategoryType = "pizza" ,IsAvailable = true},

            new DataitemsModel() {Name = "Meaty",
                Description = "Savor the hearty flavors of our Meaty Pizza, a carnivore's dream come true. Packed with an assortment of savory meats, this pizza promises a mouthwatering experience with every slice. Whether you're a meat lover or simply craving a robust and satisfying meal, our Meaty Pizza delivers on taste and indulgence" ,
                ItemPrice = 14.00M,ImageUrl = "img/pizzas/meaty.jpg", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Salad",
                Description = "Experience the perfect fusion of freshness and flavor with our Salad Pizza. This innovative creation combines the classic appeal of pizza with the crisp, vibrant goodness of a garden salad, offering a delightful and satisfying meal for those seeking a lighter yet delicious option. Each bite is a harmonious blend of savory pizza toppings and refreshing salad greens, creating a unique and memorable dining experience" ,
                ItemPrice = 9.00M,ImageUrl = "img/pizzas/salad.jpg", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Margherita",
                Description = "Indulge in the timeless simplicity and authentic flavors of our Margherita Pizza, a classic Italian favorite that celebrates the essence of fresh ingredients and traditional craftsmanship. Named in honor of Queen Margherita of Italy, this pizza showcases the vibrant colors of the Italian flag with its red tomatoes, white mozzarella, and green basil, embodying the spirit of Italian culinary heritage" ,
                ItemPrice = 10.00M,ImageUrl = "img/pizzas/margherita.jpg", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Cheese",
                Description = "Our Cheese Pizza celebrates the timeless appeal of simplicity and the comforting richness of melted cheese. It's a classic favorite that appeals to pizza lovers of all ages, offering a delicious canvas of gooey, melted cheese atop a flavorful tomato sauce and perfectly baked crust. Whether enjoyed as is or customized with additional toppings, our Cheese Pizza is a crowd-pleaser that never goes out of style" ,
                ItemPrice = 12.00M,ImageUrl = "img/pizzas/cheese.jpg", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Pepperoni",
                Description = "Pepperoni Pizza is a beloved classic that embodies the perfect marriage of zesty flavors, savory toppings, and gooey melted cheese. Each bite delivers a satisfying blend of tangy tomato sauce, spicy pepperoni slices, and creamy cheese, making it a timeless favorite among pizza enthusiasts worldwide" ,
                ItemPrice = 11.00M,ImageUrl = "img/pizzas/pepperoni.jpg", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Olive",
                Description = " Olive Pizza is a delightful combination of briny olives, savory toppings, and a perfect blend of cheeses, creating a Mediterranean-inspired taste experience. Each slice is a harmonious balance of salty olives, tangy tomato sauce, creamy cheese, and aromatic herbs, making it a flavorful choice for olive enthusiasts and lovers of unique pizza flavors" ,
                ItemPrice = 9.00M,ImageUrl = "img/pizzas/Olive.webp", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Red Pepper",
                Description = "Red Pepper Pizza is a vibrant and flavorful delight that showcases the sweet and slightly smoky essence of roasted red peppers. It's a perfect harmony of tangy tomato sauce, creamy cheese, and the bold, roasted flavors of red peppers, creating a pizza experience that is both satisfying and distinctive" ,
                ItemPrice = 11.00M,ImageUrl = "img/pizzas/Red_Pepper.webp", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Seafood",
                Description = "Dive into a symphony of oceanic flavors with our Seafood Pizza, a culinary masterpiece that combines the freshest seafood treasures with savory toppings and a perfectly baked crust. Each bite is a celebration of the sea's bounty, featuring succulent shrimp, tender squid, flavorful fish, and a medley of complementary ingredients that create a truly memorable dining experience" ,
                ItemPrice = 14.00M,ImageUrl = "img/pizzas/Seafood.webp", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Cheesecake",
                Description = "Indulge in a slice of creamy heaven with our delectable Cheesecake, a classic dessert that combines velvety smoothness with rich flavors and a buttery crust. Each bite is a symphony of creamy cheesecake filling, complemented by a variety of toppings or flavor infusions, making it a beloved treat for dessert enthusiasts and special occasions alike" ,
                ItemPrice = 5.00M,ImageUrl = "img/altro/Cheesecake.webp", CategoryType = "altro" ,IsAvailable = true},

             new DataitemsModel() {Name = "Spinach",
                Description = "Spinach Pizza is a delightful fusion of vibrant greens, savory cheese, and flavorful toppings, offering a fresh and satisfying pizza experience. Packed with nutritious spinach leaves, creamy cheese, and optional complementary ingredients, this pizza is a favorite among vegetarians and those seeking a lighter yet delicious pizza option." ,
                ItemPrice = 9.00M,ImageUrl = "img/pizzas/Spinach.webp", CategoryType = "pizza" ,IsAvailable = true},

             new DataitemsModel() {Name = "Chicken Nuggets",
                Description = "Chicken Nuggets are a beloved classic, offering crispy, golden-brown bites of tender chicken goodness that are perfect for snacking, meals, or party platters. Made from high-quality chicken breast meat and seasoned to perfection, these nuggets are a favorite among both kids and adults alike." ,
                ItemPrice = 5.00M,ImageUrl = "img/altro/Chicken_nugget.webp", CategoryType = "altro" ,IsAvailable = true},

             new DataitemsModel() {Name = "Chocolate Lava Cake",
                Description = "Indulge in the ultimate chocolate lover's dream with our decadent Chocolate Lava Cake, a divine dessert that combines rich, molten chocolate center with a moist and fluffy cake exterior. Every bite is a harmonious blend of warm, gooey chocolate lava oozing from a perfectly baked cake shell, creating a luxurious and indulgent dessert experience" ,
                ItemPrice = 7.00M,ImageUrl = "img/altro/Chocolate_Lava_Cake.webp", CategoryType = "altro" ,IsAvailable = true},

             new DataitemsModel() {Name = "French Fries",
                Description = "French Fries are a beloved classic, featuring crispy golden exteriors and fluffy, tender interiors that make them irresistible to snack on or pair with a variety of dishes. Made from high-quality potatoes and cooked to perfection, our fries are seasoned to enhance their delicious flavor and provide a satisfying crunch in every bite." ,
                ItemPrice = 3.00M,ImageUrl = "img/altro/French_fries.webp", CategoryType = "altro" ,IsAvailable = true},

             new DataitemsModel() {Name = "Garlic Bread",
                Description = "Garlic Bread is a deliciously aromatic and flavorful treat that combines crispy bread with savory garlic butter, creating a perfect accompaniment to pasta dishes, soups, salads, or enjoyed on its own as a delightful snack. Each slice is infused with garlic goodness and toasted to golden perfection, making it a favorite among bread lovers" ,
                ItemPrice = 2.00M,ImageUrl = "img/altro/Garlic_Bread.webp", CategoryType = "altro" ,IsAvailable = true},

             new DataitemsModel() {Name = "Yogurt Magro",
                Description = "Low-Fat Yogurt, or Yogurt Magro, is a dairy product made from milk that has undergone a process to reduce its fat content while retaining the beneficial probiotics and nutrients found in yogurt. It offers a creamy and tangy taste similar to regular yogurt but with lower fat content, making it a popular choice among health-conscious individuals or those looking to manage their calorie intake" ,
                ItemPrice = 2.00M,ImageUrl = "img/altro/yogurt_magro.webp", CategoryType = "altro" ,IsAvailable = true},

             new DataitemsModel() {Name = "1L Water bottle",
                Description = "Water is good" ,
                ItemPrice = 2.00M,ImageUrl = "img/altro/drinks/1L_drink.webp", CategoryType = "drinks" ,IsAvailable = true},

             new DataitemsModel() {Name = "0.5L Water bottle",
                Description = "water is good" ,
                ItemPrice = 1.00M,ImageUrl = "img/altro/drinks/50cl_drink.webp", CategoryType = "drinks" ,IsAvailable = true},

             
        };
    }
}

