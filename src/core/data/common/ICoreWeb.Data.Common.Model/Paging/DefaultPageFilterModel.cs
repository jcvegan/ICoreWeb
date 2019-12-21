using System.Linq;

namespace ICoreWeb.Data.Common.Model.Paging
{
    public class DefaultPageFilterModel : PageFilterModel
    {
        public DefaultPageFilterModel():base(50,1)
        {
        }
        public override IQueryable<TClass> ApplyFilter<TClass>(IQueryable<TClass> collection)
        {
            return collection.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
        }
    }
}