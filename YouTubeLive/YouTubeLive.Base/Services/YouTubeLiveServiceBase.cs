﻿using StreamingClient.Base.Model.OAuth;
using StreamingClient.Base.Services;
using StreamingClient.Base.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTubeLive.Base.Model;

namespace YouTubeLive.Base.Services
{
    /// <summary>
    /// The abstract class in charge of handling RESTful requests against the YouTube Live APIs.
    /// </summary>
    public abstract class YouTubeLiveServiceBase : OAuthRestServiceBase
    {
        private const string YouTubeLiveRestAPIBaseAddressFormat = "https://www.googleapis.com/youtube/v3/";

        /// <summary>
        /// The YouTube Live connection.
        /// </summary>
        protected YouTubeLiveConnection connection;

        private string baseAddress;

        /// <summary>
        /// Creates an instance of the YouTubeLiveServiceBase.
        /// </summary>
        /// <param name="connection">The Twitch connection to use</param>
        public YouTubeLiveServiceBase(YouTubeLiveConnection connection) : this(connection, YouTubeLiveRestAPIBaseAddressFormat) { }

        /// <summary>
        /// Creates an instance of the YouTubeLiveServiceBase.
        /// </summary>
        /// <param name="connection">The Twitch connection to use</param>
        /// <param name="baseAddress">The base address to use</param>
        public YouTubeLiveServiceBase(YouTubeLiveConnection connection, string baseAddress)
        {
            Validator.ValidateVariable(connection, "connection");
            this.connection = connection;
            this.baseAddress = baseAddress;
        }

        internal YouTubeLiveServiceBase() : this(YouTubeLiveRestAPIBaseAddressFormat) { }

        internal YouTubeLiveServiceBase(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        /// <summary>
        /// Performs a GET REST request using the provided request URI for YouTube API-wrapped data.
        /// </summary>
        /// <param name="requestUri">The request URI to use</param>
        /// <param name="maxResults">The maximum number of results. Will be either that amount or slightly more</param>
        /// <returns>A type-casted object of the contents of the response</returns>
        protected async Task<IEnumerable<T>> GetPagedAsync<T>(string requestUri, int maxResults = 1)
        {
            List<T> results = new List<T>();
            string nextPageToken = null;

            if (!requestUri.Contains("?"))
            {
                requestUri += "?";
            }
            else
            {
                requestUri += "&";
            }

            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.Add("maxResults", ((maxResults > 50) ? 50 : maxResults).ToString());

            do
            {
                if (!string.IsNullOrEmpty(nextPageToken))
                {
                    queryParameters["pageToken"] = nextPageToken;
                }
                YouTubePagedResult<T> result = await this.GetAsync<YouTubePagedResult<T>>(requestUri + string.Join("&", queryParameters.Select(kvp => kvp.Key + "=" + kvp.Value)));

                if (result != null)
                {
                    nextPageToken = result.nextPageToken;
                    results.AddRange(result.items);
                }
            } while (results.Count < maxResults && !string.IsNullOrEmpty(nextPageToken));
            return results;
        }

        /// <summary>
        /// Wrapper method for handling calls on YouTube's .NET client API.
        /// </summary>
        /// <param name="func">The function being called</param>
        /// <returns>A typed-result</returns>
        protected async Task<T> YouTubeServiceWrapper<T>(Func<Task<T>> func)
        {
            try
            {
                await this.GetOAuthToken();
                return await func();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            return default(T);
        }

        /// <summary>
        /// Gets the OAuth token for the connection of this service.
        /// </summary>
        /// <param name="autoRefreshToken">Whether to automatically refresh the OAuth token or not if it has to be</param>
        /// <returns>The OAuth token for the connection</returns>
        protected override async Task<OAuthTokenModel> GetOAuthToken(bool autoRefreshToken = true)
        {
            if (this.connection != null)
            {
                return await this.connection.GetOAuthToken(autoRefreshToken);
            }
            return null;
        }

        /// <summary>
        /// Gets the base address for all RESTful calls for this service.
        /// </summary>
        /// <returns>The base address for all RESTful calls</returns>
        protected override string GetBaseAddress() { return this.baseAddress; }
    }
}
