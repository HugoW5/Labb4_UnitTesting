using Labb4_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestClass]
	public class BookSearchTests
	{

		#region Search By Title

		[TestMethod]
		public void Search_BooksByTitle_Partial_Matches_Should_ReturnMatchingBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("1234567 89", "F. Scott Fitzgerald", "1234567890", 1925));
			library.AddBook(new Book("1234567 1723", "John Doe", "0987654321", 2020));
			// Act
			var result = library.SearchByTitle("1234567");
			// Assert
			Assert.AreEqual(2, result.Count);
		}
		[TestMethod]
		public void Search_BooksByTitle_Exact_Matches_Should_ReturnMatchingBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("1234567", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByTitle("1234567");
			// Assert
			Assert.AreEqual(1, result.Count);
		}
		[TestMethod]
		public void SearchByTitle_CaseInsensitive_Should_ReturnMatchingBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			library.AddBook(new Book("ABcDeFg", "John Doe", "0987654321", 2020));
			// Act
			var result = library.SearchByTitle("abcdefg");
			// Assert
			Assert.AreEqual(2, result.Count);
		}

		[TestMethod]
		public void SearchByTitle_EmptyString_Should_ReturnNoBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByTitle("");
			// Assert
			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void SearchByTitle_NonExistentTitle_Should_ReturnNoBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByTitle("nonexistent");
			// Assert
			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void SearchByTitle_NullString_Should_ReturnNoBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByTitle(null);
			// Assert
			Assert.AreEqual(0, result.Count);
		}

		#endregion

		#region Search By Author

		[TestMethod]
		public void Search_BooksByAuthor_Partial_Matches_Should_ReturnMatchingBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("1234567 1723", "John Doe", "0987654321", 2020));
			// Act
			var result = library.SearchByAuthor("John D");
			// Assert
			Assert.AreEqual(1, result.Count);
		}
		[TestMethod]
		public void Search_BooksByAuthor_Exact_Matches_Should_ReturnMatchingBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("1234567", "hugo wakt", "1234567890", 1925));
			// Act
			var result = library.SearchByAuthor("hugo wakt");
			// Assert
			Assert.AreEqual(1, result.Count);
		}
		[TestMethod]
		public void Search_BooksByAuthor_CaseInsensitive_Should_ReturnMatchingBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdef", "John Doe", "0987654321", 2020));
			// Act
			var result = library.SearchByAuthor("john doe");
			// Assert
			Assert.AreEqual(1, result.Count);
		}

		[TestMethod]
		public void Search_ByAuthor_EmptyString_Should_ReturnNoBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByAuthor("");
			// Assert
			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void Search_ByAuthor_NonExistentTitle_Should_ReturnNoBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByAuthor("nonexistent");
			// Assert
			Assert.AreEqual(0, result.Count);
		}

		[TestMethod]
		public void Search_ByAuthor_NullString_Should_ReturnNoBooks()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByAuthor(null);
			// Assert
			Assert.AreEqual(0, result.Count);
		}

		#endregion

		#region Search by ISBN
		[TestMethod]
		public void Search_BooksByISBN_Partial_Matches_Should_ReturnMatchingBook()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			var book = new Book("1234567 1723", "John Doe", "0987654321", 2020);
			library.AddBook(book);
			// Act
			var result = library.SearchByISBN("0987654");
			// Assert
			Assert.AreEqual(book, result);
		}


		[TestMethod]
		public void Search_BooksByISBN_EmptyString_Should_ReturnNoBook()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByISBN("");
			// Assert
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Search_BooksByISBN_NonExistentISBN_Should_ReturnNoBook()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByISBN("489759343784658932476538927453534____");
			// Assert
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Search_BooksByISBN_NullString_Should_ReturnNoBook()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			library.AddBook(new Book("abcdefg", "F. Scott Fitzgerald", "1234567890", 1925));
			// Act
			var result = library.SearchByISBN(null);
			// Assert
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void Search_BooksByISBN_ExactMatch_Should_ReturnCorrectBook()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			var book = new Book("Title", "Author", "937472386356324534", 2020);
			library.AddBook(book);

			// Act
			var result = library.SearchByISBN("937472386356324534");

			// Assert
			Assert.AreEqual(book, result);
		}

		#endregion
	}
}
