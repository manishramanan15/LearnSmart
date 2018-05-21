using Autofac;
using LearnSmart.Services.Tutorials;
using LearnSmart.Services.Request;
using System;
using LearnSmart.Services.Navigation;

namespace LearnSmart.ViewModels.Base
{
    public class Locator
    {
        private static IContainer _container;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected Locator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<RequestService>().As<IRequestService>();
            builder.RegisterType<TutorialsService>().As<ITutorialsService>();

            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<DetailViewModel>();
            builder.RegisterType<HomepageViewModel>();
            builder.RegisterType<SplashViewModel>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}