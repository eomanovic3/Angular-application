﻿//-------------------------------------------------------------------------------
// <copyright file="NinjectWebCommon.cs" company="Ninject Project Contributors">
//   Copyright (c) 2012 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

using WebAPI.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace WebAPI.App_Start
{
    using System;
    using System.Reflection;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject.Web.WebApi;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using BLL;
    using System.Web.Http;
    using DAL;

    /// <summary>
    /// Bootstrapper for the application.
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAddress>().To<AddressLogic>();
            kernel.Bind<ICity>().To<CityLogic>();
            kernel.Bind<ICounty>().To<CountyLogic>();
            kernel.Bind<IEmail>().To<EmailLogic>();
            kernel.Bind<IUserDetail>().To<UserDetailLogic>();
            kernel.Bind<IZip>().To<ZipLogic>();
            kernel.Bind<IStateInfo>().To<StateInfoLogic>();

            kernel.Bind<IAddressDal>().To<AddressDal>();
            kernel.Bind<ICityDal>().To<CityDal>();

            kernel.Load(Assembly.GetExecutingAssembly());
           
        }
    }
}