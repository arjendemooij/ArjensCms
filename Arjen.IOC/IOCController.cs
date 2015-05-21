using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Arjen.IOC
{
    public enum IOCImplementationType
    {
        StructureMap
    }

    public class IOCController
    {
        private static IIOCImplementation _implementation;

        public static bool IsAvailable()
        {
            return _implementation != null;
        }

        public static void Initialize(IOCImplementationType type)
        {
            switch (type)
            {
                case IOCImplementationType.StructureMap:
                    _implementation = new StructureMapIOC();
                    break;
                default:
                    throw new Exception("Unsupported implementationType");
                    break;
            }

            _implementation.Initialize();
        }

        public static void RegisterFactoryMethod<TInterface>(Func<TInterface> createInstance)
        {
            _implementation.RegisterFactoryMethod<TInterface>(createInstance);
        }

        public static void Register<TInterface, TClass>() where TClass : TInterface
        {
            _implementation.Register<TInterface, TClass>();
        }

        public static TInterface GetInstance<TInterface>()
        {
            return _implementation.GetInstance<TInterface>();
        }

        public static void RegisterInstance<TInterface>(TInterface instance) where TInterface : class
        {
            _implementation.RegisterInstance<TInterface>(instance);
        }

        public static object GetInstance(Type instanceType)
        {
            return _implementation.GetInstance(instanceType);
        }

        public static void AutoRegisterInterface(Assembly assembly)
        {
            _implementation.AutoRegisterInterface(assembly);
        }
    }

    public class StructureMapIOC : IIOCImplementation
    {
        public void Initialize()
        {
            ObjectFactory.Initialize();
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            ObjectFactory.Configure(x => x.For<TInterface>().Use<TImplementation>());
        }

        public void RegisterInstance<TInterface>(TInterface instance) where TInterface : class
        {
            ObjectFactory.Configure(x => x.For<TInterface>().Use(instance));
        }


        public TInterface GetInstance<TInterface>()
        {
            return ObjectFactory.GetInstance<TInterface>();

        }

        public object GetInstance(Type instanceType)
        {
            return ObjectFactory.GetInstance(instanceType);
        }

        public void AutoRegisterInterface(Assembly assembly)
        {
            ObjectFactory.Container.Configure(
                x => x.Scan(s =>
                    {
                        s.Convention<InterfaceNameConvention>();
                        s.Assembly(assembly);

                    }));
        }

        public void RegisterFactoryMethod<TInterface>(Func<TInterface> createInstance)
        {
            ObjectFactory.Container.Configure(x => x.For<TInterface>()
                .Use<TInterface>(context => createInstance()));
        }

        internal class InterfaceNameConvention : IRegistrationConvention
        {
            #region IRegistrationConvention Members

            public void Process(Type type, Registry registry)
            {
                string interfaceName = "I" + type.Name;
                Type interfaceType = type.GetInterface(interfaceName);

                if (type.IsAbstract || !type.IsClass || interfaceType == null)
                {
                    return;
                }
                registry.AddType(interfaceType, type);
            }

            #endregion IRegistrationConvention Members
        }


    }

    public interface IIOCImplementation
    {
        void Initialize();
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        void RegisterInstance<TInterface>(TInterface instance) where TInterface : class;
        TInterface GetInstance<TInterface>();
        object GetInstance(Type instanceType);
        void AutoRegisterInterface(Assembly assembly);
        void RegisterFactoryMethod<T>(Func<T> createInstance);
    }
}
