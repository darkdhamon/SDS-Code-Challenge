using System;
using DeveloperSample.ClassRefactoring.Model;
using DeveloperSample.ClassRefactoring.Model.Enums;
using Xunit;

namespace DeveloperSample.ClassRefactoring.Tests
{
    public class ClassRefactorTest
    {
        //[Fact]
        //public void AfricanSwallowHasCorrectSpeed()
        //{
        //    var swallow = SwallowFactory.GetSwallow(SwallowType.African);
        //    Assert.Equal(22, swallow.GetAirspeedVelocity());
        //}

        //[Fact]
        //public void LadenAfricanSwallowHasCorrectSpeed()
        //{
        //    var swallow = SwallowFactory.GetSwallow(SwallowType.African);
        //    swallow.ApplyLoad(SwallowLoad.Coconut);
        //    Assert.Equal(18, swallow.GetAirspeedVelocity());
        //}

        //[Fact]
        //public void EuropeanSwallowHasCorrectSpeed()
        //{
        //    var swallow = SwallowFactory.GetSwallow(SwallowType.European);
        //    Assert.Equal(20, swallow.GetAirspeedVelocity());
        //}

        //[Fact]
        //public void LadenEuropeanSwallowHasCorrectSpeed()
        //{
        //    var swallow = SwallowFactory.GetSwallow(SwallowType.European);
        //    swallow.ApplyLoad(SwallowLoad.Coconut);
        //    Assert.Equal(16, swallow.GetAirspeedVelocity());
        //}

        [Theory]
        [InlineData(SwallowType.African, SwallowLoad.None, 22)]
        [InlineData(SwallowType.African, SwallowLoad.Coconut, 18)]
        [InlineData(SwallowType.European, SwallowLoad.None, 20)]
        [InlineData(SwallowType.European, SwallowLoad.Coconut, 16)]
        public void LadenSwallowHasCorrectSpeed(SwallowType swallowType, SwallowLoad swallowLoad, int expectedAirspeed)
        {
            var swallow = SwallowFactory.GetSwallow(swallowType);
            swallow.ApplyLoad(swallowLoad);
            Assert.Equal(expectedAirspeed, swallow.GetAirspeedVelocity());
        }

        
        
        [Theory]
        [InlineData(SwallowType.African)]
        [InlineData(SwallowType.European)]
        public void SwallowLadenWithUnknownLoad_Throws_InvalidOperationException(SwallowType swallowType)
        {
            var swallow = SwallowFactory.GetSwallow(swallowType);
            swallow.ApplyLoad((SwallowLoad)(-1));
            Assert.Throws<InvalidOperationException>(() => swallow.GetAirspeedVelocity());
        }
        
    }
}