using StructureMap;
using UgBoard.ViewModels;
using Caliburn.Micro;
using UgBoard.Framework;
using System;
using System.Collections.Generic;
using UgBoard.Models;
namespace UgBoard
{
    public class Bootstrapper : Caliburn.Micro.Bootstrapper<UgBoard.ViewModels.ShellViewModel>
    {
        public Bootstrapper()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<ShellViewModel>().Singleton().Use<ShellViewModel>();

                x.For<IWindowManager>().Singleton().Use<WindowManager>();
                x.For<IEventAggregator>().Singleton().Use<EventAggregator>();


                x.For<IBusyService>().Singleton().Use<DefaultBusyService>();
                x.For<ITwitterService>().Singleton().Use<DefaultTwitterService>();
                x.For<IConfigurationService>().Singleton().Use<DefaultConfigurationService>();
                x.For<IBackend>().Singleton().Use<DefaultBackend>();

                // First we create a new Setter Injection Policy that
                // forces StructureMap to inject all public properties
                // where the PropertyType is ITwitterService
                x.SetAllProperties(y =>
                {
                    y.OfType<ITwitterService>();
                });

                x.SetAllProperties(y =>
                {
                    y.OfType<IBackend>();
                });


            });
            //ObjectFactory.AssertConfigurationIsValid();

        }

        protected override object GetInstance(Type serviceType, string key)
        {

            return String.IsNullOrEmpty(key) ? ObjectFactory.Container.GetInstance(serviceType) : ObjectFactory.Container.GetInstance(serviceType, key);

        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return ObjectFactory.Container.GetAllInstances(serviceType).AsEnumerable();
        }

        protected override void BuildUp(object instance)
        {
            ObjectFactory.Container.BuildUp(instance);
        }  
    }
}
