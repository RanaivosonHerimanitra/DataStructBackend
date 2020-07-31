using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend.Tests
{
    [TestFixture]
    public class DotnetQueueTests
    {
        private DotnetQueue<int> queue;
        private readonly int N = 5;

        [SetUp]
        public void SetUp()
        {
            queue = new DotnetQueue<int>(N);
        }

        [Test]
        public void LengthShouldBeN()
        {
            int lastElemen = 40;
            queue.Insert(10);
            queue.Insert(20);
            queue.Insert(30);
            queue.Insert(lastElemen);
            Assert.AreEqual(queue.PeekFront(), lastElemen, @"Front should be ${lastElemen}");
        }
    }
}
