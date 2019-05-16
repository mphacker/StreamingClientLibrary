﻿namespace Twitch.Base.Models.V5.Emotes
{
    /// <summary>
    /// Information about a user emote.
    /// </summary>
    public class EmoteModel
    {
        /// <summary>
        /// The ID of the emote.
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// The ID of the channel associated with the emotes.
        /// </summary>
        public string channelID { get; set; }
        /// <summary>
        /// The text code for the emote.
        /// </summary>
        public string code { get; set; }
    }
}
