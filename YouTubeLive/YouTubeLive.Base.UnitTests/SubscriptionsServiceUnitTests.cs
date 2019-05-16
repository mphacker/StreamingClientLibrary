﻿using Google.Apis.YouTube.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace YouTubeLive.Base.UnitTests
{
    [TestClass]
    public class SubscriptionsServiceUnitTests : UnitTestBase
    {
        [TestMethod]
        public void GetMySubscriptions()
        {
            TestWrapper(async (YouTubeLiveConnection connection) =>
            {
                IEnumerable<Subscription> results = await connection.Subscriptions.GetMySubscriptions(maxResults: 10);

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
            });
        }

        [TestMethod]
        public void GetMySubscribers()
        {
            TestWrapper(async (YouTubeLiveConnection connection) =>
            {
                IEnumerable<Subscription> results = await connection.Subscriptions.GetMySubscribers(maxResults: 10);

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
            });
        }

        [TestMethod]
        public void GetMyRecentSubscribers()
        {
            TestWrapper(async (YouTubeLiveConnection connection) =>
            {
                IEnumerable<Subscription> results = await connection.Subscriptions.GetMyRecentSubscribers(maxResults: 10);

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
            });
        }
    }
}
