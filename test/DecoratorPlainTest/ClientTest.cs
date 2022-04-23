using DecoratorPlain;
using ForEvolve.Testing.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DecoratorPlainTest
{
    public class ClientTest
    {
        public class ExecuteAsync : ClientTest
        {
            private readonly HttpContextHelper httpContextHelper = new HttpContextHelper();

            [Fact]
            public async Task ShouldResponseWriteTheResultOfTheComponentOperation()
            {
                const string testValue = "Test Value";
                // arrange
                var componentMock = new Mock<IComponent>();
                componentMock.Setup(x => x.Operation()).Returns(testValue).Verifiable();
                var sut = new Client(componentMock.Object);

                // act
                await sut.ExecuteAsync(httpContextHelper.HttpContextMock.Object);

                // assert
                httpContextHelper.HttpResponseFake.BodyShouldEqual($"Operation: {testValue}");
            }
        }
    }
}
