namespace babi.ViewModels
{
    using System.Collections.Generic;
    using babi.ViewModelSchemaFilters;
    using Swashbuckle.AspNetCore.SwaggerGen;

    [SwaggerSchemaFilter(typeof(PageResultCarSchemaFilter))]
    public class PageResult<T>
        where T : class
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public int Total { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
