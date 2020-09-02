using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CsvParser.Helpers;

namespace CsvParser.Windsor
{
    public class DependecyResolver
    {
        public WindsorContainer GetContainer()
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));

            container.Register(
                Component.For<IMyCsvHelper>().ImplementedBy(typeof(MyCsvHelper)).LifestyleSingleton());

            return container;
        }
    }
}
