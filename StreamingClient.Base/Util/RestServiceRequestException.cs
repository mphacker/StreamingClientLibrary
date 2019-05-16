﻿using System;
using System.Net;
using System.Net.Http;

namespace StreamingClient.Base.Util
{
    /// <summary>
    /// An exception detailing the failure of a REST web request.
    /// </summary>
    public class RestServiceRequestException : HttpRequestException
    {
        /// <summary>
        /// The URL of the request.
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// The result status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// The reason for the failure.
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// The content of the response.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Creates a new instance of the RestServiceRequestException.
        /// </summary>
        public RestServiceRequestException() : base() { }

        /// <summary>
        /// Creates a new instance of the RestServiceRequestException with a specified message.
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public RestServiceRequestException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance of the RestServiceRequestException with a specified message &amp; inner exception.
        /// </summary>
        /// <param name="message">The message of the exception</param>
        /// <param name="inner">The inner exception</param>
        public RestServiceRequestException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Creates a new instance of the RestServiceRequestException with a web request response.
        /// </summary>
        /// <param name="response">The response of the failing web request</param>
        public RestServiceRequestException(HttpResponseMessage response)
            : this(response.ReasonPhrase)
        {
            this.Request = response.RequestMessage.RequestUri.ToString();
            this.StatusCode = response.StatusCode;
            this.Reason = response.ReasonPhrase;
            this.Content = response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>A string representation of the object</returns>
        public override string ToString()
        {
            return this.Request + Environment.NewLine + this.Content + Environment.NewLine + base.ToString();
        }
    }
}
