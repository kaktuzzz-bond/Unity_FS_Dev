using System;
using System.Collections;
using NUnit.Framework;

namespace Tests.EditModeTests
{
    public class ConverterTestCaseDataProvider
    {
        public static IEnumerable UpdateAutomaticallyCases()
        {
            yield return new TestCaseData(CreateConverterWithResources(amount: 0,
                                                                       resourceStorageCapacity: 5,
                                                                       productStorageCapacity: 5,
                                                                       resourceGrabValue: 2,
                                                                       productPerLoadValue: 3,
                                                                       produceTime: 0.9f), 0.1f)
                         .Returns(Tuple.Create(false, 0, 0))
                         .SetName("Converter 0/5: grab value 2, does not have resources");

            yield return new TestCaseData(CreateConverterWithResources(amount: 1,
                                                                       resourceStorageCapacity: 5,
                                                                       productStorageCapacity: 5,
                                                                       resourceGrabValue: 2,
                                                                       productPerLoadValue: 3,
                                                                       produceTime: 0.9f), 0.1f)
                         .Returns(Tuple.Create(false, 1, 0))
                         .SetName("Converter 1/5: grab value 2, does not have enough resources");

            yield return new TestCaseData(CreateConverterWithResources(amount: 3,
                                                                       resourceStorageCapacity: 5,
                                                                       productStorageCapacity: 5,
                                                                       resourceGrabValue: 2,
                                                                       productPerLoadValue: 3,
                                                                       produceTime: 0.9f), 0.3f)
                         .Returns(Tuple.Create(true, 1, 0))
                         .SetName("Timer: 0.9f - 0.3f, storage 3/5, grabbed 2 (1/5 remained), converter is locked");

            yield return new TestCaseData(CreateConverterWithResources(amount: 3,
                                                                       resourceStorageCapacity: 5,
                                                                       productStorageCapacity: 5,
                                                                       resourceGrabValue: 2,
                                                                       productPerLoadValue: 3,
                                                                       produceTime: 0.9f), 0.9f)
                         .Returns(Tuple.Create(false, 1, 3))
                         .SetName("Timer: 0.9f - 0.9f, storage 3/5, grabbed 2 (1/5 remained), converter is unlocked");
        }


        public static IEnumerable AddProductToStorageCases
        {
            get
            {
                yield return new TestCaseData(CreateConverterWithResources(amount: 5,
                                                                           resourceStorageCapacity: 5,
                                                                           productStorageCapacity: 5,
                                                                           resourceGrabValue: 2,
                                                                           productPerLoadValue: 3,
                                                                           produceTime: 0.5f), 0.5f)
                             .Returns(Tuple.Create(false, 3))
                             .SetName("Product storage was 0/5, tried to add 3, added 3, grabber is unlocked");

                yield return new TestCaseData(CreateConverterWithResources(amount: 5,
                                                                           resourceStorageCapacity: 5,
                                                                           productStorageCapacity: 5,
                                                                           resourceGrabValue: 2,
                                                                           productPerLoadValue: 5,
                                                                           produceTime: 0.5f), 0.5f)
                             .Returns(Tuple.Create(false, 5))
                             .SetName("Product storage was 0/5, tried to add 5, added 5, grabber is unlocked");

                yield return new TestCaseData(CreateConverterWithResources(amount: 5,
                                                                           resourceStorageCapacity: 5,
                                                                           productStorageCapacity: 2,
                                                                           resourceGrabValue: 2,
                                                                           productPerLoadValue: 3,
                                                                           produceTime: 0.5f), 0.5f)
                             .Returns(Tuple.Create(true, 0))
                             .SetName("Product storage was 0/2, tried to add 3, added 0, grabber is locked");
            }
        }

        public static IEnumerable GrabResourcesFromStorageCases
        {
            get
            {
                yield return new TestCaseData(CreateConverterWithResources(amount: 2,
                                                                           resourceStorageCapacity: 5,
                                                                           resourceGrabValue: 2), 0.5f)
                             .Returns(Tuple.Create(true, 0))
                             .SetName("Storage was 2/5, tried to grab 2, grabbed 2, remained 0, locked");

                yield return new TestCaseData(CreateConverterWithResources(amount: 1,
                                                                           resourceStorageCapacity: 5,
                                                                           resourceGrabValue: 2), 0.5f)
                             .Returns(Tuple.Create(false, 1))
                             .SetName("Storage was 1/5, tried to grab 2, grabbed 0, remained 1, unlocked");
            }
        }

        public static IEnumerable AddResourcesToEmptyStorageCases
        {
            get
            {
                //true
                yield return new TestCaseData(CreateConverterWithResources(amount: 0,
                                                                           resourceStorageCapacity: 5), 3)
                             .Returns(Tuple.Create(true, 3, 0))
                             .SetName("Storage is 0/5, add 3, giveback 0");

                yield return new TestCaseData(CreateConverterWithResources(amount: 0,
                                                                           resourceStorageCapacity: 5), 5)
                             .Returns(Tuple.Create(true, 5, 0))
                             .SetName("Storage is 0/5, add 5, giveback 0");

                //false
                yield return new TestCaseData(CreateConverterWithResources(amount: 0,
                                                                           resourceStorageCapacity: 5), 0)
                             .Returns(Tuple.Create(false, 0, 0))
                             .SetName("Storage is 0/5, add 0, giveback 0");

                yield return new TestCaseData(CreateConverterWithResources(amount: 0,
                                                                           resourceStorageCapacity: 5), -1)
                             .Returns(Tuple.Create(false, 0, 0))
                             .SetName("Storage is 0/5, add -1, giveback 0");

                yield return new TestCaseData(CreateConverterWithResources(amount: 0,
                                                                           resourceStorageCapacity: 3), 5)
                             .Returns(Tuple.Create(false, 3, 2))
                             .SetName("Storage is 0/3, add 5, giveback 2");
            }
        }

        public static IEnumerable AddResourcesToNonEmptyStorageCases
        {
            get
            {
                yield return new TestCaseData(CreateConverterWithResources(amount: 2,
                                                                           resourceStorageCapacity: 5), 1)
                             .Returns(Tuple.Create(true, 3, 0))
                             .SetName("Storage was 2/5, added 1, giveback 0");

                yield return new TestCaseData(CreateConverterWithResources(amount: 2,
                                                                           resourceStorageCapacity: 5), 3)
                             .Returns(Tuple.Create(true, 5, 0))
                             .SetName("Storage was 2/5, added 3, giveback 0");

                yield return new TestCaseData(CreateConverterWithResources(amount: 2,
                                                                           resourceStorageCapacity: 5), 4)
                             .Returns(Tuple.Create(false, 5, 1))
                             .SetName("Storage was 2/5, added 4, giveback 1");
            }
        }


        private static Feature.Converter<int, float> CreateConverterWithResources(int amount,
            int resourceStorageCapacity = 1,
            int productStorageCapacity = 1,
            int resourceGrabValue = 1,
            int productPerLoadValue = 1,
            float produceTime = 1f)
        {
            var converter = new Feature.Converter<int, float>(resourceStorageCapacity, productStorageCapacity,
                                                              resourceGrabValue, productPerLoadValue, produceTime);

            if (amount > 0)
                converter.AddResources(amount, out _);

            return converter;
        }
    }
}