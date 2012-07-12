[assembly: WebActivator.PreApplicationStartMethod(typeof(PoPs.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(PoPs.Web.App_Start.NinjectWebCommon), "Stop")]

namespace PoPs.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using PoPs.Service;
    using PoPs.Repository.Repositories;
    using PoPs.Web.Infrastructure;
    using PoPs.Repository;
    using System.Web.Security;
    using System.Web.Mvc;
    using FluentValidation.Mvc;
    using PoPs.Web.Validations;
    using FluentValidation;
    using PoPs.Web.Models;
    using PoPs.Infrasctructure;
    using PoPs.Infrasctructure.Email;

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

            var validatorFactory = new NinjectValidatorFactory(kernel);
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(validatorFactory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            kernel.Bind<IPopService>().To<PopService>();
            kernel.Bind<IPopRepository>().To<PopRepository>();

            kernel.Bind<ITagService>().To<TagService>();
            kernel.Bind<ITagRepository>().To<TagRepository>();

            kernel.Bind(typeof(IValidator<UserRegisterViewModel>)).To<UserRegisterViewModelValidator>();
            kernel.Bind(typeof(IValidator<UserLoginViewModel>)).To<UserLoginViewModelValidator>();
            kernel.Bind(typeof(IValidator<UserForgotPasswordViewModel>)).To<UserForgotPasswordViewModelValidator>();
            kernel.Bind<IEmailSender>().To<EmailSender>();
            kernel.Bind<EmailSettings>().To<EmailSettings>();
        }   
            
    }
}
