//using BLL.IoCConfig;
//using BLL.Services.Interfaces;
//using Ninject;
//using Ninject.Modules;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HotelPL.Configurations
//{
//    public static class Configuration
//    {
//        private static NinjectModule Service = new NinjectConfig();
//        private static NinjectModule UoW = new IocLoading();
//        private static StandardKernel Kernel = new StandardKernel(Service, UoW);

//        public static object GetService(Type serviceType)
//        {
//            return Kernel.TryGet(serviceType);
//        }
//    }
//}
