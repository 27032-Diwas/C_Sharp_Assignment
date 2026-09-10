namespace Collections.Service;

/// <summary>
/// Contain operation to add, remove and view students.
/// </summary>
/// <typeparam name="TKey"> Type of key in dictionary (string). </typeparam>
/// <typeparam name="TValue"> Type of value in dictionary (double). </typeparam>
public class Task4<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _students = new ();

    /// <summary>
    /// Adds student to dictionary.
    /// </summary>
    /// <param name="name"> Name of the student. </param>
    /// <param name="mark"> Mark of the student. </param>
    /// <returns> True if student does not exist in dictionary; otherwise false. </returns>
    public bool AddStudent(TKey name, TValue mark)
    {
        if (this._students.ContainsKey(name))
        {
            return false;
        }

        this._students.Add(name, mark);
        return true;
    }

    /// <summary>
    /// Removes student from the list.
    /// </summary>
    /// <param name="name"> Name of student. </param>
    /// <returns> True if student does not exist in dictionary; otherwise false. </returns>
    public bool RemoveStudent(TKey name)
    {
        if (this._students.ContainsKey(name))
        {
            this._students.Remove(name);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets students.
    /// </summary>
    /// <returns> Students as dictionary. </returns>
    public IReadOnlyDictionary<TKey, TValue> GetStudents() => this._students;
}
