using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DM.Services.Implementation;
using DM.Services.Interface;

namespace DocumentManagerAPI.Extensions
{
	public static class DIExtension
	{

		public static ContainerBuilder AddServices(this ContainerBuilder builder)
		{
			builder.RegisterService<IDocumentReadService, DocumentReadService>();
			builder.RegisterService<IDocumentEditService, DocumentEditService>();
			builder.RegisterService<IDocumentService, DocumentService>();
			builder.RegisterService<IFileStorageService, FileStorageService>();

			return builder;
		}

        private static void RegisterService<TService, TImplementation>(this ContainerBuilder builder)
           where TService : class where TImplementation : class, TService
        {
            var a = builder.RegisterType<TImplementation>().As<TService>();
        }
    }
}
