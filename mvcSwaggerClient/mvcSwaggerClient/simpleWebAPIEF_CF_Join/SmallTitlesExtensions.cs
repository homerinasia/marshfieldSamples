﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using MvcSwaggerClient;
using MvcSwaggerClient.Models;

namespace MvcSwaggerClient
{
    public static partial class SmallTitlesExtensions
    {
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static SmallTitle DeletesmallTitle(this ISmallTitles operations, string id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISmallTitles)s).DeletesmallTitleAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<SmallTitle> DeletesmallTitleAsync(this ISmallTitles operations, string id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<MvcSwaggerClient.Models.SmallTitle> result = await operations.DeletesmallTitleWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static SmallTitle GetsmallTitle(this ISmallTitles operations, string id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISmallTitles)s).GetsmallTitleAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<SmallTitle> GetsmallTitleAsync(this ISmallTitles operations, string id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<MvcSwaggerClient.Models.SmallTitle> result = await operations.GetsmallTitleWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        public static IList<SmallTitle> GetsmallTitles(this ISmallTitles operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISmallTitles)s).GetsmallTitlesAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<SmallTitle>> GetsmallTitlesAsync(this ISmallTitles operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<MvcSwaggerClient.Models.SmallTitle>> result = await operations.GetsmallTitlesWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='smallTitle'>
        /// Required.
        /// </param>
        public static SmallTitle PostsmallTitle(this ISmallTitles operations, SmallTitle smallTitle)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISmallTitles)s).PostsmallTitleAsync(smallTitle);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='smallTitle'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<SmallTitle> PostsmallTitleAsync(this ISmallTitles operations, SmallTitle smallTitle, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<MvcSwaggerClient.Models.SmallTitle> result = await operations.PostsmallTitleWithOperationResponseAsync(smallTitle, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='smallTitle'>
        /// Required.
        /// </param>
        public static object PutsmallTitle(this ISmallTitles operations, string id, SmallTitle smallTitle)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISmallTitles)s).PutsmallTitleAsync(id, smallTitle);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the MvcSwaggerClient.ISmallTitles.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='smallTitle'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> PutsmallTitleAsync(this ISmallTitles operations, string id, SmallTitle smallTitle, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PutsmallTitleWithOperationResponseAsync(id, smallTitle, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
