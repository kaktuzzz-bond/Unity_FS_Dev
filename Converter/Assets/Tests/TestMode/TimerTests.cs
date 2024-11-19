using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Converter;
using NUnit.Framework;
using Tests.Stubs;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests.TestMode
{
    public class TimerTests
    {
        private Converter<StubLog, StubPlank> _converter;

        


        [UnityTest]
        [TestCase(20, 10, 5, 0.5f, 1f,  1f, 5,ExpectedResult = (IEnumerator)null)]
        public IEnumerator TimerTestsWithEnumeratorPasses( int load, int unload, int capacity, float efficiency, float duration, float waitingTime, int expectedCount)
        {
            _converter = new Converter<StubLog, StubPlank>(load, unload, capacity);
            _converter.SetEfficiency(efficiency);
            _converter.SetDuration(duration);

            var logs = GetLogs(10);
            
            _converter.AddResources(logs);
            
            _converter.Start();
            
            _converter.Convert();
            
            yield return new WaitForSeconds(waitingTime);

            _converter.Stop();
            
            var planks = _converter.Unload().ToArray();
            
            
            Assert.AreEqual(expectedCount, planks.Length);
        }


        private StubLog[] GetLogs(int count)
        {
            var logs = new StubLog[count];

            for (int i = 0; i < count; i++)
            {
                logs[i] = new StubLog();
            }

            return logs;
        }
    }
}