namespace babi.ViewModels
{
    using babi.ViewModelSchemaFilters;
    using Swashbuckle.AspNetCore.SwaggerGen;

    [SwaggerSchemaFilter(typeof(CarSchemaFilter))]
    public class Car
    {
        public int CarId { get; set; }

        public int Cylinders { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
    }
}
