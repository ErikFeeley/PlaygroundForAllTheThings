using Ef6NTierTest.Service.Implementations;
using Ef6NTierTest.Service.Interfaces;
using StructureMap;

namespace Ef6NTierTest.Service.DependancyInjection
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            //For<IValueService>().Use<ValueService>(); dont actually need this when calling withdefaultconventions.
        }
    }
}
