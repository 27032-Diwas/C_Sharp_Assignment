using LINQ.Models;

namespace LINQ.Repository;

/// <summary>
/// Contains all read and write operations (CRUD).
/// </summary>
public class SupplierRepository
{
    private readonly List<Supplier> _suppliers = new List<Supplier>
    {
        new (1, "Apple Inc.", 1),
        new (2, "Samsung Electronics", 2),
        new (3, "Sony Corporation", 3),
        new (4, "Dell Technologies", 4),
        new (5, "Apple Inc.", 5),
        new (6, "LG Electronics", 6),
        new (7, "IKEA", 7),
        new (8, "Home Centre", 8),
        new (9, "Whirlpool", 9),
        new (10, "Bosch", 10),
        new (11, "Alienware", 11),
        new (12, "Acer", 12),
        new (13, "Fossil", 13),
        new (14, "JBL", 14),
        new (15, "Canon", 15),
    };

    /// <summary>
    /// Adds the supplier to the list.
    /// </summary>
    /// <param name="supplier"> Instance of supplier. </param>
    public void AddSupplier(Supplier supplier) => this._suppliers.Add(supplier);

    /// <summary>
    /// Gets all suppliers from the list.
    /// </summary>
    /// <returns> List of all suppliers. </returns>
    public List<Supplier> GetAllSuppliers() => this._suppliers;
}
