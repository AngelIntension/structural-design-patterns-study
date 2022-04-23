using Composite.Models;
using Moq;
using System;
using System.Text;
using Xunit;

namespace CompositeTest
{
    public class CorporationTest
    {
        public class CorporationShould : CorporationTest
        {
            [Fact]
            public void SetGivenName()
            {
                // arrange
                const string testName = "Test Name";
                Corporation sut = new Corporation(testName);

                // act
                var result = sut.Name;

                // assert
                Assert.Equal(testName, result);
            }

            [Fact]
            public void GuardAgainstNullName()
            {
                // arrange
                string nullName = null;

                // assert
                var error = Assert.Throws<ArgumentNullException>(() => new Corporation(nullName));
                Assert.Equal("name", error.ParamName);
            }
        }

        public class CountShould : CorporationTest
        {
            [Fact]
            public void ReturnCorrectNumberOfDescendants()
            {
                // arrange
                var corporationMock1 = new Mock<Corporation>("corporationMock1");
                corporationMock1.Setup(x => x.Count()).Returns(3);

                var corporationMock2 = new Mock<Corporation>("corporationMock2");
                corporationMock2.Setup(x => x.Count()).Returns(2);

                var sut = new Corporation("test");
                sut.Add(corporationMock1.Object);
                sut.Add(corporationMock2.Object);

                // act
                int result = sut.Count();

                // assert
                Assert.Equal(5, result);
            }
        }

        public class TypeShould : CorporationTest
        {
            [Fact]
            public void ReturnCorporationType()
            {
                // arrange
                var sut = new Corporation("name");

                // act
                string result = sut.Type;

                // assert
                Assert.Equal(sut.GetType().Name, result);
            }
        }

        public class RemoveShould : CorporationTest
        {
            [Fact]
            public void RemoveGivenChild()
            {
                // arrange
                var corporationMock1 = new Mock<Corporation>("corporationMock1");
                corporationMock1.Setup(x => x.Count()).Returns(7);

                var corporationMock2 = new Mock<Corporation>("corporationMock2");
                corporationMock2.Setup(x => x.Count()).Returns(5);

                var sut = new Corporation("test");
                sut.Add(corporationMock1.Object);
                sut.Add(corporationMock2.Object);
                Assert.Equal(12, sut.Count());

                // act
                sut.Remove(corporationMock2.Object);
                var result = sut.Count();

                // assert
                Assert.Equal(7, result);
            }
        }

        public class DisplayShould : CorporationTest
        {
            [Fact]
            public void ReturnPrescribedFormattedOutput()
            {
                // arrange
                var corporationMock = new Mock<Corporation>("corporationMock");
                corporationMock.Setup(x => x.Count()).Returns(3);
                string corporationMockDisplay = "<em>corporationMockDisplay</em>";
                corporationMock.Setup(x => x.Display()).Returns(corporationMockDisplay);

                string corporationName = "Borders";
                var sut = new Corporation(corporationName);
                sut.Add(corporationMock.Object);

                var sb = new StringBuilder();
                sb.Append("<section class=\"card\">");

                sb.Append($"<h1 class=\"card-header\">");
                sb.Append(corporationName);
                sb.Append($" - <span class=\"badge badge-secondary float-right\">{corporationMock.Object.Count()} books</span>");
                sb.Append($"</h1>");

                sb.Append($"<ul class=\"list-group list-group-flush\">");
                sb.Append($"<li class=\"list-group-item\">");
                sb.Append(corporationMockDisplay);
                sb.Append("</li>");
                sb.Append("</ul>");

                sb.Append("<div class=\"card-footer text-muted\">");
                sb.Append($"<small class=\"text-muted text-right\">{sut.GetType().Name}</small>");
                sb.Append("</div>");

                sb.Append("</section>");

                var expected = sb.ToString();

                // act
                string result = sut.Display();
                
                // assert
                Assert.Equal(expected, result);
            }
        }
    }
}
