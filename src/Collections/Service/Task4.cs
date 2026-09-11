namespace Collections.Service;

/// <summary>
/// Contain operation to add, remove and view dictionary.
/// </summary>
/// <typeparam name="TKey"> Type of key in dictionary (string for student names). </typeparam>
/// <typeparam name="TValue"> Type of value in dictionary (double for marks). </typeparam>
public class Task4<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _items = new ();

    /// <summary>
    /// Adds item key and their value to dictionary.
    /// </summary>
    /// <param name="key"> Key of the item. </param>
    /// <param name="false"> Value of the item. </param>
    /// <returns> True if item does not exist in dictionary; otherwise false. </returns>
    public bool AddItem(TKey key, TValue @false)
    {
        if (this._items.ContainsKey(key))
        {
            return false;
        }

        this._items.Add(key, @false);
        return true;
    }

    /// <summary>
    /// Removes item from the dictionary.
    /// </summary>
    /// <param name="key"> Key of item. </param>
    /// <returns> True if item does not exist in dictionary; otherwise false. </returns>
    public bool RemoveItem(TKey key)
    {
        if (this._items.ContainsKey(key))
        {
            this._items.Remove(key);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets items.
    /// </summary>
    /// <returns> items as dictionary. </returns>
    public IReadOnlyDictionary<TKey, TValue> GetStudentsInfo() => this._items;
}
