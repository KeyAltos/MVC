using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{   

    public class ServiceRevolverModule : NinjectModule
    {
        public override void Load()
        {   
            Bind<IUnitOfWork>().To<UnitOfWork>();            
        }
    }
}
