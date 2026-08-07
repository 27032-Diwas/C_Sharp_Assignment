using InventoryManager.Models;

namespace InventoryManager.Repository;

/// <summary>
/// Contains read and write operation to perform into file.
/// </summary>
public class FileRepository : IRead, IWrite
{
    /// <summary>
    /// Reads all products from file.
    /// </summary>
    /// <returns> List of products. </returns>
    public List<Product> ReadProducts()
    {
        if (!File.Exists("Products.csv"))
        {
            File.Create("Products.csv").Close();
        }

        string[] products = File.ReadAllLines("Products.csv");
        List<Product> productList = new ();
        foreach (string product in products)
        {
            string[] productInfo = product.Split(',');
            productList.Add(
                new Product(productInfo[0], productInfo[1])
                {
                    ProductPrice = Convert.ToInt32(productInfo[2]),
                    ProductQuantity = Convert.ToInt32(productInfo[3]),
                });
        }

        return productList;
    }

    /// <summary>
    /// Write all products into file.
    /// </summary>
    /// <param name="products"> List of products. </param>
    public void WriteProducts(List<Product> products)
    {
        List<string> productList = new ();
        foreach (Product product in products)
        {
            productList.Add($"{product.ProductId},{product.ProductName},{product.ProductPrice},{product.ProductQuantity}");
        }

        File.WriteAllLines("Products.csv", productList);
    }
}
