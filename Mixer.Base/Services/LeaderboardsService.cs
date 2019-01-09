﻿using Mixer.Base.Model.Channel;
using Mixer.Base.Model.Leaderboards;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mixer.Base.Services
{
    /// <summary>
    /// The APIs for leaderboard-based services.
    /// </summary>
    public class LeaderboardsService : MixerServiceBase
    {
        /// <summary>
        /// Creates an instance of the LeaderboardsService.
        /// </summary>
        /// <param name="connection">The Mixer connection to use</param>
        public LeaderboardsService(MixerConnection connection) : base(connection, version: 2) { }

        /// <summary>
        /// Gets the weekly sparks leaderboard for the specified channel.
        /// </summary>
        /// <param name="channel">The channel to get the leaderboard for</param>
        /// <returns>The weekly sparks leaderboard for the channel specified</returns>
        public async Task<IEnumerable<SparksLeaderboardModel>> GetWeeklyLeaderboard(ChannelModel channel)
        {
            return await this.GetAsync<IEnumerable<SparksLeaderboardModel>>("leaderboards/sparks-weekly/channels/" + channel.id.ToString());
        }

        /// <summary>
        /// Gets the monthly sparks leaderboard for the specified channel.
        /// </summary>
        /// <param name="channel">The channel to get the leaderboard for</param>
        /// <returns>The monthly sparks leaderboard for the channel specified</returns>
        public async Task<IEnumerable<SparksLeaderboardModel>> GetMonthlyLeaderboard(ChannelModel channel)
        {
            return await this.GetAsync<IEnumerable<SparksLeaderboardModel>>("leaderboards/sparks-monthly/channels/" + channel.id.ToString());
        }

        /// <summary>
        /// Gets the yearly sparks leaderboard for the specified channel.
        /// </summary>
        /// <param name="channel">The channel to get the leaderboard for</param>
        /// <returns>The yearly sparks leaderboard for the channel specified</returns>
        public async Task<IEnumerable<SparksLeaderboardModel>> GetYearlyLeaderboard(ChannelModel channel)
        {
            return await this.GetAsync<IEnumerable<SparksLeaderboardModel>>("leaderboards/sparks-yearly/channels/" + channel.id.ToString());
        }

        /// <summary>
        /// Gets the all-time sparks leaderboard for the specified channel.
        /// </summary>
        /// <param name="channel">The channel to get the leaderboard for</param>
        /// <returns>The all-time sparks leaderboard for the channel specified</returns>
        public async Task<IEnumerable<SparksLeaderboardModel>> GetAllTimeLeaderboard(ChannelModel channel)
        {
            return await this.GetAsync<IEnumerable<SparksLeaderboardModel>>("leaderboards/sparks-alltime/channels/" + channel.id.ToString());
        }
    }
}
