using DecoratorPlain;
using Moq;
using Xunit;

namespace DecoratorPlainTest
{
    public class DecoratorBTest
    {
        [Fact]
        public void ShouldWrapTheDecoratedResultInADecoratorBTag()
        {
            // arrange
            const string testValue = "Test Value";
            Mock<IComponent> componentMock = new Mock<IComponent>();
            componentMock.Setup(x => x.Operation()).Returns(testValue);
            DecoratorB sut = new DecoratorB(componentMock.Object);

            // act
            string result = sut.Operation();

            // assert
            Assert.Equal($"<DecoratorB>{testValue}</DecoratorB>", result);
        }
    }
}
