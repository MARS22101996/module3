using System.Linq.Expressions;

namespace Shops.BLL.Filtration.Abstract
{
    public interface IFilterChain<T>
        where T : Expression
    {
        IFilter<T> Root { get; }

        T Execute(T input);

        IFilterChain<T> Register(IFilter<T> filter);
    }
}