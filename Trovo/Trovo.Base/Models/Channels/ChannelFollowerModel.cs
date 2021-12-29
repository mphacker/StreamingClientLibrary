﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Trovo.Base.Models.Channels
{
    /// <summary>
    /// Information about a channel follower.
    /// </summary>
    [DataContract]
    public class ChannelFollowerModel
    {
        /// <summary>
        /// Unique id of a user.
        /// </summary>
        [DataMember]
        public string user_id { get; set; }

        /// <summary>
        /// The display name of a user, displayed in chats, channels and all across Trovo. This could be different from username.
        /// </summary>
        [DataMember]
        public string nickname { get; set; }

        /// <summary>
        /// User's profile picture
        /// </summary>
        [DataMember]
        public string profile_pic { get; set; }

        /// <summary>
        /// Return the following time
        /// </summary>
        [DataMember]
        public string followed_at { get; set; }
    }
}
