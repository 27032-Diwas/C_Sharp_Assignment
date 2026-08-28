namespace LINQ.Service;

/// <summary>
/// Query builder method.
/// </summary>
/// <typeparam name="T"> Type of collection. </typeparam>
public class QueryBuilder<T>
{
    private IEnumerable<T> _query;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
    /// </summary>
    /// <param name="list"> Collection of data. </param>
    public QueryBuilder(IEnumerable<T> list)
    {
        this._query = list;
    }

    /// <summary>
    /// Filter the list.
    /// </summary>
    /// <param name="filter"> Filter query. </param>
    /// <returns> Instance of query builder with filter query. </returns>
    public QueryBuilder<T> Filter(Func<T, bool> filter)
    {
        this._query = this._query.Where(filter);
        return this;
    }

    /// <summary>
    /// Sort the list.
    /// </summary>
    /// <typeparam name="TKey"> Key of the instance. </typeparam>
    /// <param name="sort"> Sort query. </param>
    /// <returns> Instance of query builder with filter query. </returns>
    public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> sort)
    {
        this._query = this._query.OrderBy(sort);
        return this;
    }

    /// <summary>
    /// Sort the list in descending order.
    /// </summary>
    /// <typeparam name="TKey"> Key of the instance. </typeparam>
    /// <param name="sort"> Sort query. </param>
    /// <returns> Instance of query builder with filter query. </returns>
    public QueryBuilder<T> SortByDescending<TKey>(Func<T, TKey> sort)
    {
        this._query = this._query.OrderByDescending(sort);
        return this;
    }

    /// <summary>
    /// Join operation.
    /// </summary>
    /// <typeparam name="TInner"> Inner collection type. </typeparam>
    /// <typeparam name="TKey"> Key element type. </typeparam>
    /// <typeparam name="TResult"> Result instance. </typeparam>
    /// <param name="inner"> Inner collection. </param>
    /// <param name="outerKeySelector"> Property in source used to compare. </param>
    /// <param name="innerKeySelector"> Property in inner collection to compare. </param>
    /// <param name="resultSelector"> Return type instance. </param>
    /// <returns> Instance of query builder with filter query. </returns>
    public QueryBuilder<TResult> Join<TInner, TKey, TResult>(
            IEnumerable<TInner> inner,
            Func<T, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<T, TInner, TResult> resultSelector)
    {
        return new QueryBuilder<TResult>(this._query.Join(inner, outerKeySelector, innerKeySelector, resultSelector));
    }

    /// <summary>
    /// Execute the whole query.
    /// </summary>
    /// <returns> IEnumerable collection. </returns>
    public IEnumerable<T> Execute()
    {
        return this._query.ToList();
    }
}
