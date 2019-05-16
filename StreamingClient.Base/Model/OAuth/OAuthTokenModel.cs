﻿using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace StreamingClient.Base.Model.OAuth
{
    /// <summary>
    /// A token received from an OAuth authentication service.
    /// </summary>
    public class OAuthTokenModel
    {
        /// <summary>
        /// The ID of the client service.
        /// </summary>
        public string clientID { get; set; }
        /// <summary>
        /// The secret of the client service.
        /// </summary>
        public string clientSecret { get; set; }
        /// <summary>
        /// The authorization code sent when authenticating against the OAuth service.
        /// </summary>
        public string authorizationCode { get; set; }

        /// <summary>
        /// The token used for refreshing the authentication.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string refreshToken { get; set; }
        /// <summary>
        /// The token used for accessing the OAuth service.
        /// </summary>
        [JsonProperty("access_token")]
        public string accessToken { get; set; }
        /// <summary>
        /// The expiration time of the token in seconds from when it was obtained.
        /// </summary>
        [JsonProperty("expires_in")]
        public int expiresIn { get; set; }

        /// <summary>
        /// The time when the token was obtained.
        /// </summary>
        [DataMember]
        public DateTimeOffset AcquiredDateTime { get; set; }

        /// <summary>
        /// The expiration time of the token.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset ExpirationDateTime { get { return this.AcquiredDateTime.AddSeconds(this.expiresIn); } }

        /// <summary>
        /// Creates a new instance of an OAuth token.
        /// </summary>
        public OAuthTokenModel()
        {
            this.AcquiredDateTime = DateTimeOffset.Now;
        }
    }
}
