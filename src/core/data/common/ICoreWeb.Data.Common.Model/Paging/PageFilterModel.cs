using System.Linq;

namespace ICoreWeb.Data.Common.Model.Paging
{
    public abstract class PageFilterModel
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        protected PageFilterModel(int pageSize, int pageIndex)
        {
            this.PageSize = pageSize;
            this.CurrentPage = pageIndex;
        }

        public abstract IQueryable<TClass> ApplyFilter<TClass>(IQueryable<TClass> collection);
    }
}