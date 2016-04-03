namespace LeagueSharp.Data.Utility
{
    internal interface IFilter
    {
        #region Public Methods and Operators

        object Apply(object data);

        #endregion
    }

    internal interface IFilter<T>
    {
        #region Public Methods and Operators

        T Apply(T data);

        #endregion
    }
}