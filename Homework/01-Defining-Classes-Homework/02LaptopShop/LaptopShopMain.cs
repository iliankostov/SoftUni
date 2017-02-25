namespace LaptopShop
{
    using System;
    class LaptopShopMain
    {
        static void Main()
        {
            Laptop lenovo = new Laptop("Lenovo Yoga 2 Pro", 2259.00M, "Lenovo",
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                8, "Intel HD Graphics 4400", 128, "13.3\"(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display",
                "Li-Ion, 4-cells, 2550 mAh", 4.5F);

            Laptop hp = new Laptop("HP 250 G2", 699.00M);

            Console.WriteLine(lenovo);
            Console.WriteLine(hp);
        }
    }
}