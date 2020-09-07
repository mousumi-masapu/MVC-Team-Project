using OnlineShop.Core;
using OnlineShop.Core.Contarcts;
using OnlineShop.Core.Models;
using OnlineShop.DataAccess.SQL;
using OnlineShop.Servises;
using OnlineShop.WebUI.Controllers;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace OnlineShop.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepository<Product>, SqlRepository<Product>>();
            container.RegisterType<IRepository<Category>, SqlRepository<Category>>();
            container.RegisterType<IRepository<Basket>, SqlRepository<Basket>>();
            container.RegisterType<IRepository<BasketItem>, SqlRepository<BasketItem>>();
            container.RegisterType<IRepository<CheckOutInformation>, SqlRepository<CheckOutInformation>>();
            container.RegisterType<IBasketService, BasketService>();

            //register a user it is probably in the standard AccountController.
            // Unity tries to call the constructor with two parameters, for example
             //Unity to call the parameterless constructor
            container.RegisterType<AccountController>(new InjectionConstructor());

        }
    }
}