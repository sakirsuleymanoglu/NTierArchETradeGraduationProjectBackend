using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;

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

            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            //Manager - Service

            builder.RegisterType<BasketManager>().As<IBasketService>();

            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<AddressManager>().As<IAddressService>();

            builder.RegisterType<BrandManager>().As<IBrandService>();

            builder.RegisterType<CityManager>().As<ICityService>();

            builder.RegisterType<CountryManager>().As<ICountryService>();

            builder.RegisterType<OrderManager>().As<IOrderService>();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();

            builder.RegisterType<OrderStatusManager>().As<IOrderStatusService>();

            builder.RegisterType<ProductImageManager>().As<IProductImageService>();

            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

           
        }
    }
}
