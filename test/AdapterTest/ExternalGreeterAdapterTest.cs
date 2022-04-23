using Adapter;
using System;
using Xunit;

namespace AdapterTest
{
    public class ExternalGreeterAdapterTest
    {
        public class ExternalGreeterAdapterShould : ExternalGreeterAdapterTest
        {
            [Fact]
            public void GuardAgainstNullAdaptee()
            {
                // act
                var error = Assert.Throws<ArgumentNullException>(() => new ExternalGreeterAdapter(null));

                // assert
                Assert.Equal("adaptee", error.ParamName);
            }
        }

        public class GreetingShould : ExternalGreeterAdapterTest
        {
            [Fact]
            public void ReturnDesiredGreeting()
            {
                // arrange
                var expected = "Adaptee says: hi System!";
                IGreeter sut = new ExternalGreeterAdapter(new ExternalGreeter());

                // act
                var result = sut.Greeting();

                // assert
                Assert.Equal(expected, result);
            }
        }
    }
}
