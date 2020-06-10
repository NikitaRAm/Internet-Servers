//using PhonesLib; - для json
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using PhonesLibSql;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phones.DI
{
    public class NIConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary<Contact>>().To<PhoneDictionary>(); // TASK 1 - новый экземпляр на каждый вызов

            //Bind<IPhoneDictionary<Contact>>().To<PhoneDictionary>().InThreadScope();  //TASK 2 - новый экземпляр на каждый поток

            //Bind<IPhoneDictionary<Contact>>().To<PhoneDictionary>().InRequestScope(); //TASK 3 - новый экземпляр на каждый HTTP-запрос
        }
    }
}