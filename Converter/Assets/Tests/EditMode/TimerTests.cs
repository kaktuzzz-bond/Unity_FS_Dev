using System;
using Converter;
using NUnit.Framework;

namespace Tests.EditMode
{
    [TestFixture]
    public class TimerTests
    {
        [Test]
        public void Tick_WithNegativeDeltaTime_ThrowException()
        {
            var timer = new Timer(1f);

            Assert.Catch<ArgumentOutOfRangeException>(() => timer.Tick(-0.1f));
        }


        [Test]
        public void Tick_OnTimeoutWithAutostart_EventRaised()
        {
            var timer = new Timer(1f);

            var wasTimeout = false;

            timer.OnTimeUp += () => wasTimeout = true;

            timer.Tick(0.6f);

            Assert.IsTrue(wasTimeout);
        }


        [Test]
        public void Tick_OnTimeoutWithoutAutostart_EventRaised()
        {
            var timer = new Timer(1f, false);

            var wasTimeout = false;

            timer.OnTimeUp += () => wasTimeout = true;

            timer.Tick(0.5f);
            Assert.IsFalse(wasTimeout);
            timer.Tick(0.5f);
            Assert.IsTrue(wasTimeout);

            //Reset:
            wasTimeout = false;

            timer.Tick(0.5f);
            Assert.IsFalse(wasTimeout);
            timer.Tick(0.5f);
            Assert.IsTrue(wasTimeout);
        }


        [Test]
        public void Constructor_InitializeWithPositiveValue_ExpectNotNull()
        {
            var timer = new Timer(1);

            Assert.IsNotNull(timer);
        }


        [Test]
        public void Constructor_InitializeWithNegativeValue_ThrowException()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Timer(-1));
        }
    }
}