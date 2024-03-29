using System;
using BookInfoProvider;
using Xunit;

namespace ISBN {
    public class ISBN10Test {
        [Fact]
        public void ISBN_ShorterThan10Characters_ReturnsInvalidBookInfo() {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(shortISBN);
            
            //Assert
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan10Characters_ReturnsInvalidBookInfo() {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(longISBN);
            
            Assert.Equal("ISBN must be 10 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_BookAvailableFromFinder() {
            String unknownISBN = "0553562614";
            
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);
            
            Assert.Equal("Title not found", actual.Title);
        }

        [Fact]
        public void ISBN_BookFound() {
            string ISBN = "0321146530";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
            Assert.Equal(expected.ToString(), actual.ToString());
        }
        

        [Fact]
        public void ISBN_RemoveDashAndSpaceCheck() {
	        string ISBN = "03-21146 530";

	        ISBNFinder sut = new ISBNFinder();
	        BookInfo actual = sut.lookup(ISBN);

	        BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
	        Assert.Equal(expected.ToString(), actual.ToString());
        }

//        [Fact]
//        public void Break_The_Build() {
//            // this test breaks the build.
//            // delete it and commit the change to fix the broken build
//            throw new Xunit.Sdk.XunitException("xUnit does not have an Assert.'Fail' ");
//        }

        [Fact]
        public void PaulIsTryingToTriggerABuild() {
            Assert.True(true);
        }

                [Fact]
        public void ISBN10_Validate_Check_Sum()
        {
            var isbnNumber10 = "0471958697";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(isbnNumber10);

            Assert.Equal(7, sut.IsValidIsbn10(isbnNumber10));
        }
        
        [Fact]
        public void Retrieve_ISB13()
        {
	        var ISBN = "9780321146533";
	        ISBNFinder sut = new ISBNFinder();
	        BookInfo actual = sut.lookup(ISBN);

	        BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
	        Assert.Equal(expected.ToString(), actual.ToString());	        
	        
        }
        
    }

}