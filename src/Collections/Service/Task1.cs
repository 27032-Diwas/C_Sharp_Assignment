namespace Collections.Service;

/// <summary>
/// Contains operations such as add, view and remove items.
/// </summary>
/// <typeparam name="T"> Type of item to be in list (string for books). </typeparam>
public class Task1<T>
{
    private readonly List<T> _items = new ();

    /// <summary>
    /// Adds item to the list.
    /// </summary>
    /// <param name="item"> Name of the item. </param>
    public void AddItem(T item) => this._items.Add(item);

    /// <summary>
    /// Removes item from the list.
    /// </summary>
    /// <param name="item"> Name of the item. </param>
    /// <returns> True if item is removed successfully otherwise false. </returns>
    public bool RemoveItem(T item) => this._items.Remove(item);

    /// <summary>
    /// Checks if item exist in list or not.
    /// </summary>
    /// <param name="item"> Name of the item. </param>
    /// <returns> True if item exist; otherwise false. </returns>
    public bool IsItemExist(T item) => this._items.Contains(item);

    /// <summary>
    /// Gets all items from the list.
    /// </summary>
    /// <returns> List of items. </returns>
    public IReadOnlyList<T> GetAllItems() => this._items;
}
