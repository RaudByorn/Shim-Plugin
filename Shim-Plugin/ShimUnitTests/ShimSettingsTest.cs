using System;

using ShimPlugin.Model;
using ShimPlugin.Model.Exceptions;

using NUnit.Framework;

/* 10 <= InnerRadius <= 500
 * 10 <= OuterRadius <= 1000
 * 10 <= Height <= 500
 * 0 <= InnerFillet <= 250
 * 0 <= OuterFillet <= 250
 * 0 <= GrooveRadius <= 250 */

//500, 1000, 500, 250, 250, 250,

namespace ShimUnitTests
{
    [TestFixture]
    public class ShimSettingsTest
    {
        [TestCase(10, 10, 10, 0, 0, 0, TestName = "(Positive)ShimSettingsConstructor-Min")]
        [TestCase(500, 1000, 500, 250, 250, 250, TestName = "(Positive)ShimSettingsConstructor-Max")]
        [Test]
        public void TestPositiveShimSettingsConstructor(double innerRadius, double outerRadius,
            double height, double innerFillet, double outerFillet, double grooveRadius)
        {
            Assert.DoesNotThrow((() =>
            {
                new ShimSettings(innerRadius, outerRadius, 
                    height, innerFillet, outerFillet, grooveRadius);
            }
            ));
        }


        [TestCase(9, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-Under")]
        [TestCase(501, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-Over")]
        [TestCase(double.NaN, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-DoubleNaN")]
        [TestCase(double.MinValue, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-DoubleMin")]
        [TestCase(double.MaxValue, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-DoubleMax")]
        [TestCase(double.NegativeInfinity, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-NegativeInf")]
        [TestCase(double.PositiveInfinity, 1000, 500, 250, 250, 250, typeof(InnerRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-InnerRadius-PositiveInf")]

        [TestCase(500, 9, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-Under")]
        [TestCase(500, 1001, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-Over")]
        [TestCase(500, double.NaN, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-DoubleNaN")]
        [TestCase(500, double.MinValue, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-DoubleMin")]
        [TestCase(500, double.MaxValue, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-DoubleMax")]
        [TestCase(500, double.NegativeInfinity, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-NegativeInf")]
        [TestCase(500, double.PositiveInfinity, 500, 250, 250, 250, typeof(OuterRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-OuterRadius-PositiveInf")]

        [TestCase(500, 1000, 9, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-Under")]
        [TestCase(500, 1000, 501, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-Over")]
        [TestCase(500, 1000, double.NaN, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-DoubleNaN")]
        [TestCase(500, 1000, double.MinValue, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-DoubleMin")]
        [TestCase(500, 1000, double.MaxValue, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-DoubleMax")]
        [TestCase(500, 1000, double.NegativeInfinity, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-NegativeInf")]
        [TestCase(500, 1000, double.PositiveInfinity, 250, 250, 250, typeof(HeightException),
            TestName = "(Negative)ShimSettingsConstructor-Height-PositiveInf")]

        [TestCase(500, 1000, 500, -1, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-Under")]
        [TestCase(500, 1000, 500, 251, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-Over")]
        [TestCase(500, 1000, 500, double.NaN, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-DoubleNaN")]
        [TestCase(500, 1000, 500, double.MinValue, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-DoubleMin")]
        [TestCase(500, 1000, 500, double.MaxValue, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-DoubleMax")]
        [TestCase(500, 1000, 500, double.NegativeInfinity, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-NegativeInf")]
        [TestCase(500, 1000, 500, double.PositiveInfinity, 250, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-InnerFillet-PositiveInf")]

        [TestCase(500, 1000, 500, 250, -1, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-Under")]
        [TestCase(500, 1000, 500, 250, 251, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-Over")]
        [TestCase(500, 1000, 500, 250, double.NaN, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-DoubleNaN")]
        [TestCase(500, 1000, 500, 250, double.MinValue, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-DoubleMin")]
        [TestCase(500, 1000, 500, 250, double.MaxValue, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-DoubleMax")]
        [TestCase(500, 1000, 500, 250, double.NegativeInfinity, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-NegativeInf")]
        [TestCase(500, 1000, 500, 250, double.PositiveInfinity, 250, typeof(FilletException),
            TestName = "(Negative)ShimSettingsConstructor-OuterFillet-PositiveInf")]

        [TestCase(500, 1000, 500, 250, 250, -1, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-Under")]
        [TestCase(500, 1000, 500, 250, 250, 251, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-Over")]
        [TestCase(500, 1000, 500, 250, 250, double.NaN, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-DoubleNaN")]
        [TestCase(500, 1000, 500, 250, 250, double.MinValue, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-DoubleMin")]
        [TestCase(500, 1000, 500, 250, 250, double.MaxValue, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-DoubleMax")]
        [TestCase(500, 1000, 500, 250, 250, double.NegativeInfinity, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-NegativeInf")]
        [TestCase(500, 1000, 500, 250, 250, double.PositiveInfinity, typeof(GrooveRadiusException),
            TestName = "(Negative)ShimSettingsConstructor-GrooveRadius-PositiveInf")]
        [Test]
        public void TestNegativeShimSettingsConstructor(double innerRadius, double outerRadius,
            double height, double innerFillet, double outerFillet, double grooveRadius, 
            Type exceptionType)
        {
            Assert.That(() => {
                new ShimSettings(innerRadius, outerRadius,
                    height, innerFillet, outerFillet, grooveRadius);
            }, Throws.TypeOf(exceptionType));
        }

        [TestCase(500, TestName = "(Positive)ShimSettings-InnerRadius-Get")]
        [Test]
        public void TestInnerRadiusGet(double value)
        {
            ShimSettings shimSettings =
                new ShimSettings(500, 1000, 500, 250, 250, 250);
            Assert.AreEqual(value, shimSettings.InnerRadius);
        }

        [TestCase(1000, TestName = "(Positive)ShimSettings-OuterRadius-Get")]
        [Test]
        public void TestOuterRadiusGet(double value)
        {
            ShimSettings shimSettings =
                new ShimSettings(500, 1000, 500, 250, 250, 250);
            Assert.AreEqual(value, shimSettings.OuterRadius);
        }

        [TestCase(500, TestName = "(Positive)ShimSettings-Height-Get")]
        [Test]
        public void TestHeightGet(double value)
        {
            ShimSettings shimSettings =
                new ShimSettings(500, 1000, 500, 250, 250, 250);
            Assert.AreEqual(value, shimSettings.Height);
        }

        [TestCase(250, TestName = "(Positive)ShimSettings-InnerFillet-Get")]
        [Test]
        public void TestInnerFilletGet(double value)
        {
            ShimSettings shimSettings =
                new ShimSettings(500, 1000, 500, 250, 250, 250);
            Assert.AreEqual(value, shimSettings.InnerFillet);
        }

        [TestCase(250, TestName = "(Positive)ShimSettings-OuterFillet-Get")]
        [Test]
        public void TestOuterFilletGet(double value)
        {
            ShimSettings shimSettings =
                new ShimSettings(500, 1000, 500, 250, 250, 250);
            Assert.AreEqual(value, shimSettings.OuterFillet);
        }

        [TestCase(250, TestName = "(Positive)ShimSettings-GrooveRadius-Get")]
        [Test]
        public void TestGrooveRadiusGet(double value)
        {
            ShimSettings shimSettings =
                new ShimSettings(500, 1000, 500, 250, 250, 250);
            Assert.AreEqual(value, shimSettings.GrooveRadius);
        }
    }
}
