using DecoratorPlain;
using Xunit;

namespace DecoratorPlainTest
{
    public class ComponentATest
    {
        [Fact]
        public void ShouldReturnHelloFromOperation()
        {
            // arrange
            IComponent sut = new ComponentA();

            // act
            string result = sut.Operation();

            // assert
            Assert.Equal("Hello from ComponentA", result);
        }
    }
}
