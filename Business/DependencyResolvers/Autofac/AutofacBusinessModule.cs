using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Dal

            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<EfBasketDal>().As<IBasketDal>();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<EfAddressDal>().As<IAddressDal>();

            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();

            builder.RegisterType<EfOrderStatusDal>().As<IOrderStatusDal>();

            //Manager - Service

            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<BasketManager>().As<IBasketService>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<AddressManager>().As<IAddressService>();

            builder.RegisterType<BrandManager>().As<IBrandService>();

            builder.RegisterType<CityManager>().As<ICityService>();

            builder.RegisterType<CountryManager>().As<ICountryService>();

            builder.RegisterType<OrderManager>().As<IOrderService>();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();

            builder.RegisterType<OrderStatusManager>().As<IOrderStatusService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
