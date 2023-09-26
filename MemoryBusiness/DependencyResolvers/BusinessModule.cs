using Autofac;
using Memory.Business.Abstract;
using Memory.Business.Concrete;
using Memory.DataAccess.Abstract;
using Memory.DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.DependencyResolvers
{
    public  class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<NotebookManager>().As<INotebookService>();

            builder.RegisterType<NoteBookDal>().As<INoteBookDal>();
            builder.RegisterType<CityDal>().As<ICityDal>();
           
            base.Load(builder);
        }
    }
}
