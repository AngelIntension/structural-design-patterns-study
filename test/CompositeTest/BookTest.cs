using Composite.Models;
using System;
using Xunit;

namespace CompositeTest
{
    public class BookTest
    {
        public class BookShould : BookTest
        {
            [Fact]
            public void SetGivenTitle()
            {
                // arrange
                const string testTitle = "Test Title";

                // act
                Book sut = new Book(testTitle);
                var result = sut.Title;

                // assert
                Assert.Equal(testTitle, result);
            }

            [Fact]
            public void GuardAgainstNullTitle()
            {
                // act
                var error = Assert.Throws<ArgumentNullException>(() => new Book(null));

                // assert
                Assert.Equal("title", error.ParamName);
            }
        }

        public class TypeShould : BookTest
        {
            [Fact]
            public void ReturnBook()
            {
                // arrange
                var sut = new Book("Test Title");

                // act
                string result = sut.Type;

                // assert
                Assert.Equal("Book", result);
            }
        }

        public class CountShould : BookTest
        {
            [Fact]
            public void ReturnOne()
            {
                // arrange
                var sut = new Book("Test Title");

                // act
                int result = sut.Count();

                // assert
                Assert.Equal(1, result);
            }
        }

        public class DisplayShould : BookTest
        {
            [Fact]
            public void ReturnPrescribedFormattedOutput()
            {
                // arrange
                string testTitle = "Test Title";
                var sut = new Book(testTitle);
                var expected = $"{testTitle} <small class=\"text-muted\">({sut.GetType().Name})</small>";

                // act
                var result = sut.Display();

                // assert
                Assert.Equal(expected, result);
            }
        }

        public class AddShould : BookTest
        {
            [Fact]
            public void ThrowNotSupportedException()
            {
                // arrange
                var sut = new Book("Test Title");

                // act
                var error = Assert.Throws<NotSupportedException>(() => sut.Add(new Book("Some Other Book")));

                // assert
                Assert.Equal("Books cannot contain other IComponents.", error.Message);
            }
        }

        public class RemoveShould : BookTest
        {
            [Fact]
            public void ThrowNotSupportedException()
            {
                // arrange
                var sut = new Book("Test Title");

                // act
                var error = Assert.Throws<NotSupportedException>(() => sut.Remove(new Book("Some Other Book")));

                // assert
                Assert.Equal("Books cannot contain other IComponents.", error.Message);
            }
        }
    }
}
