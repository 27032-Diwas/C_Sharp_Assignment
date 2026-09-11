namespace Collections.Service;

/// <summary>
/// Contains operation to add, remove and view queue.
/// </summary>
/// <typeparam name="T"> Type of item in queue (string). </typeparam>
public class Task3<T>
{
    private readonly Queue<T> _queue = new ();

    /// <summary>
    /// Adds person to the queue.
    /// </summary>
    /// <param name="person"> Person to add in queue. </param>
    public void AddPerson(T person) => this._queue.Enqueue(person);

    /// <summary>
    /// Removes front person in the queue.
    /// </summary>
    /// <returns> True if person exist in queue ;otherwise false. </returns>
    public bool RemovePerson()
    {
        if (!this._queue.Any())
        {
            return false;
        }

        this._queue.Dequeue();
        return true;
    }

    /// <summary>
    /// Gets queue.
    /// </summary>
    /// <returns> Queue of person. </returns>
    public Queue<T> GetQueue() => this._queue;
}
