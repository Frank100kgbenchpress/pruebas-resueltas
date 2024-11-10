using System;
using System.Diagnostics;

static class Program
{
    public static void Main()
    {
        IProduct perritos = new Product { Name = "Perritos", Price = 1000 };
        IProduct leche = new Product { Name = "Leche", Price = 2000 };
        IProduct pollo = new Product { Name = "Pollo", Price = 3000 };
        IProduct baterias = new Product { Name = "Baterías", Price = 400 };
        IProduct frazadas = new Product { Name = "Frazadas", Price = 800 };

        ICombo combo1 = new Combo
        {
            Price = 5000,
            Products = new[]
            {
                new ProductQuantity { Product = perritos, Quantity = 2 },
                new ProductQuantity { Product = leche, Quantity = 2 },
                new ProductQuantity { Product = frazadas, Quantity = 1 }
            }
        };

        ICombo combo2 = new Combo
        {
            Price = 4000,
            Products = new[]
            {
                new ProductQuantity { Product = pollo, Quantity = 1 },
                new ProductQuantity { Product = leche, Quantity = 1 }
            }
        };

        ICombo combo3 = new Combo
        {
            Price = 3000,
            Products = new[]
            {
                new ProductQuantity { Product = baterias, Quantity = 10 }
            }
        };


        IProduct[] products = { perritos, leche, pollo, baterias, frazadas };
        ICombo[] combos = { combo1, combo2, combo3 };
        IProductQuantity[] desired = {
            new ProductQuantity { Product = perritos, Quantity = 3 },
            new ProductQuantity { Product = leche, Quantity = 2 },
            new ProductQuantity { Product = pollo, Quantity = 1 },
            new ProductQuantity { Product = baterias, Quantity = 35 },
        };

        int result = Exam.Solve(products, combos, desired);
        Console.WriteLine(result);
        Debug.Assert(result == 20000);
    }
}


// Estas clases son para su conveniencia,
// nosotros no los usaremos en el tester,
// así que asegúrese de programar contra las interfaces

public class Product : IProduct
{
    public int Price { get; set; }
    public required string Name { get; set; }
}

public class ProductQuantity : IProductQuantity
{
    public required IProduct Product { get; set; }
    public int Quantity { get; set; }
}

public class Combo : ICombo
{
    public int Price { get; set; }
    public required IProductQuantity[] Products { get; set; }
}
