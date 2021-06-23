using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace XPInc.Cantarim.UI.Mobile.CrossPlatform.Extensions
{
    /// <summary>
    /// Métodos de extensão para coleção de serviços utilizados para injeção de dependência.
    /// </summary>    
    [ExcludeFromCodeCoverage]
    public static class ServiceProviderExtensions
    {
        #region Métodos públicos

        /// <summary>
        /// Adiciona os tipos especificados na coleção de serviços para injeção de dependência.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceTypes"></param>
        /// <returns></returns>
        public static IServiceCollection BatchAddTransient(this IServiceCollection services, IEnumerable<Type> serviceTypes)
        {
            foreach (var type in serviceTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }

        #endregion
    }
}
