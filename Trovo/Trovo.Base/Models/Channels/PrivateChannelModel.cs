﻿namespace Trovo.Base.Models.Channels
{
    /// <summary>
    /// Private information for a channel.
    /// </summary>
    public class PrivateChannelModel : ChannelModel
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// The stream key for the user.
        /// </summary>
        public string stream_key { get; set; }
    }
}
