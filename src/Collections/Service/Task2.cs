using System.Text;

namespace Collections.Service;

/// <summary>
/// Reverse the stack.
/// </summary>
/// <typeparam name="T"> Type of item to be in stack (char). </typeparam>
public class Task2<T>
{
    private readonly Stack<T> _items = new ();

    /// <summary>
    /// Push item to the stack.
    /// </summary>
    /// <param name="item"> item to add to stack. </param>
    public void AddItem(IEnumerable<T> item)
    {
        foreach (T c in item)
        {
            this._items.Push(c);
        }
    }

    /// <summary>
    /// Gets reversed item.
    /// </summary>
    /// <returns> Reversed string of entered item. </returns>
    public string GetReversedStack() => this.RemoveItem();

    /// <summary>
    /// Pops item from the stack and append to string.
    /// </summary>
    private string RemoveItem()
    {
        var sb = new StringBuilder();

        while (this._items.Any())
        {
            sb.Append(this._items.Pop());
        }

        return sb.ToString();
    }
}
