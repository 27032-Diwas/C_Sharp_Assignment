namespace LINQ.Service;

/// <summary>
/// Query builder method.
/// </summary>
/// <typeparam name="T"> Type of collection. </typeparam>
public class QueryBuilder<T>
{
    private readonly IEnumerable<T> _list;

    private List<Func<T, bool>> _filter;

    private List<Func<T, >>? _sort;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
    /// </summary>
    /// <param name="list"> Collection of data. </param>
    public QueryBuilder(IEnumerable<T> list)
    {
        this._list = list;
        this._filter = new ();
    }

    /// <summary>
    /// Add filter query to query list.
    /// </summary>
    /// <param name="predicate"> Filter query. </param>
    /// <returns> Instance of query builder with filter query.</returns>
    public QueryBuilder<T> Filter(Func<T, bool> predicate)
    {
        this._filter.Add(predicate);
        return this;
    }

    public QueryBuilder<T> Sort(Func<T, >)
    {

    }

    /// <summary>
    /// Execute the whole query.
    /// </summary>
    /// <returns> IEnumerable collection. </returns>
    public IEnumerable<T> Execute()
    {
        IEnumerable<T> list = this._list;
        foreach (Func<T, bool> predicate in this._filter)
        {
            list.Where(predicate);
        }

        list.OrderBy

        return list;
    }
}
