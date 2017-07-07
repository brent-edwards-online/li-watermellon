namespace Watermellons.App_Start
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Extras.AggregateService;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;

    /// <summary>
    /// The inversion of control config.
    /// </summary>
    public static class IocConfig
    {
        /// <summary>
        /// Gets the my container.
        /// </summary>
        public static IContainer MyContainer { get; private set; }

        /// <summary>
        /// The configure.
        /// </summary>
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            OnConfigure(builder);

            if (MyContainer == null)
            {
                MyContainer = builder.Build();
            }
            else
            {
                builder.Update(MyContainer);
            }

            // This tells the Web API to use MyContainer as its dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(MyContainer);

            // This tells MVC to use MyContainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(MyContainer));
        }

        /// <summary>
        /// The on configure.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void OnConfigure(ContainerBuilder builder)
        {
            // This is where you register all dependencies.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // The line below tells autofac, everytime an implementation IUnitOfWork, IDatabaseFactory and IBaseService is needed, pass in an instance of the class.
            builder.RegisterType<Watermellons.Repository.UnitOfWork>().As<Watermellons.Repository.IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<Watermellons.Repository.DatabaseFactory>().As<Watermellons.Repository.IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterType<Watermellons.Repository.CompetitionEntryRepository>().As<Watermellons.Repository.ICompetitionEntryRepository>().InstancePerHttpRequest();

            builder.RegisterType<Watermellons.Services.CompetitionEntryService>().As<Watermellons.Services.ICompetitionEntryService>().InstancePerHttpRequest();
            builder.RegisterType<Watermellons.Services.BasicEmailService>().As<Watermellons.Services.IEmailService>().InstancePerHttpRequest();
            builder.RegisterType<Watermellons.Services.MessageFormatter>().As<Watermellons.Services.IMessageFormatter>().InstancePerHttpRequest();

            builder.RegisterFilterProvider();
        }
    }
}