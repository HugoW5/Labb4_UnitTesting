using Labb4_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestClass]
	public class BookReturnTests
	{

		[TestMethod]
		public void ReturnBook_ShouldReset_BorrowDate()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			library.BorrowBook("1234567");
			// Act
			var returned = library.ReturnBook("1234567");
			// Assert
			Assert.IsFalse(book.BorrowDate.HasValue);
		}

		[TestMethod]
		public void ReturnBook_ShouldReset_IsBorrowed()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			library.BorrowBook("1234567");
			// Act
			var returned = library.ReturnBook("1234567");
			// Assert
			Assert.IsFalse(book.IsBorrowed);
			Assert.IsTrue(returned);
		}

		[TestMethod]
		public void ReturnBook_ShouldReturn_FalseIfNotBorrowed()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			// Act
			var returned = library.ReturnBook("1234567");
			// Assert
			Assert.IsFalse(returned);
		}

		[TestMethod]
		public void ReturnBook_NullBook_ShouldReturn_False()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			// Act
			var returned = library.ReturnBook(null!);
			// Assert
			Assert.IsFalse(returned);
		}

		[TestMethod]
		public void ReturnBook_NonexistentISBN_ShouldReturnFalse()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			// Act
			var returned = library.ReturnBook("9999999");
			// Assert
			Assert.IsFalse(returned);
		}

		[TestMethod]
		public void ReturnBook_TwiceInARow_ShouldReturnFalseSecondTime()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			var book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			library.BorrowBook("1234567");
			library.ReturnBook("1234567");
			// Act
			var returnedAgain = library.ReturnBook("1234567");
			// Assert
			Assert.IsFalse(returnedAgain);
		}

	}
}
