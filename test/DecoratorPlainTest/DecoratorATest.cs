using DecoratorPlain;
using Moq;
using Xunit;

namespace DecoratorPlainTest
{
    public class DecoratorATest
    {
        [Fact]
        public void ShouldWrapTheDecoratedResultInADecoratorATag()
        {
            // arrange
            const string testValue = "Test Value";
            Mock<IComponent> componentMock = new Mock<IComponent>();
            componentMock.Setup(x => x.Operation()).Returns(testValue);
            IComponent sut = new DecoratorA(componentMock.Object);

            // act
            string result = sut.Operation();

            // assert
            Assert.Equal($"<DecoratorA>{testValue}</DecoratorA>", result);
        }
    }
}
