namespace Collections.Service;

/// <summary>
/// Contains operation to add, remove and view queue.
/// </summary>
/// <typeparam name="T"> Type of item in queue (string). </typeparam>
public class Task3<T>
{
    private readonly Queue<T> _queue = new ();

    /// <summary>
    /// Adds item to the queue.
    /// </summary>
    /// <param name="item"> Item to add in queue. </param>
    public void AddItem(T item) => this._queue.Enqueue(item);

    /// <summary>
    /// Removes front item in the queue.
    /// </summary>
    /// <returns> True if item exist in queue ;otherwise false. </returns>
    public bool RemoveItem()
    {
        if (this._queue.Count == 0)
        {
            return false;
        }

        this._queue.Dequeue();
        return true;
    }

    /// <summary>
    /// Gets queue.
    /// </summary>
    /// <returns> Queue of items. </returns>
    public Queue<T> GetQueue() => this._queue;
}
