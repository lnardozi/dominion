using CustomerReader.Classes;
using CustomerReader.Interfaces;
using NLog;
using Unity;
namespace CustomerReader
{
    public class Bootstrap
    {

        public static Logger logger = LogManager.GetLogger("fileLogger");
        public static IUnityContainer container = new UnityContainer();
        public static void IocContainer() {
            container.RegisterType<ICustomer, Customer>();
            container.RegisterType<IAddress, Address>();
            container.RegisterType<IReader, CSVReader>("CSV");
            container.RegisterType<IReader, XMLReader>("XML");
            container.RegisterType<IReader, JSONReader>("JSON");
        }

        public static T Resolve<T>(string name)
        {
            return container.Resolve<T>(name);
        }
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }




    }
}
