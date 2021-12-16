using BLL.IoCConfig;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.IoC
{
    public static class IoCManage
    {
        private static NinjectModule Service = new NinjectConfig();
        private static StandardKernel Kernel = new StandardKernel(Service);

        public static object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }
    }
}
