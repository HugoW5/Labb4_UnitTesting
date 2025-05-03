using Labb4_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestClass]
	public class BookBorrowTests
	{
		[TestMethod]
		public void BorrowBook_ShouldMarkAsBorrowed()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			// Act
			var borrowed = library.BorrowBook("1234567");
			// Assert
			Assert.IsTrue(book.IsBorrowed);
			Assert.IsTrue(borrowed);
		}

		[TestMethod]
		public void BorrowBook_ShouldNotBorrowAlreadyBorrowedBook()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			library.BorrowBook("1234567");
			// Act
			var borrowed = library.BorrowBook("1234567");
			// Assert
			Assert.IsFalse(borrowed);
		}
		[TestMethod]
		public void BorrowBook_ShouldReturnCorrectDate()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Boken", "hugo", "1234567", 2001);
			library.AddBook(book);
			// Act
			library.BorrowBook("1234567");
			var borrowDate = book.BorrowDate;
			// Assert
			Assert.IsNotNull(borrowDate);
			Assert.AreEqual(DateTime.Now.Date, borrowDate.Value.Date);
		}

		[TestMethod]
		public void BorrowBook_NonExistentISBN_ShouldReturnFalse()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			// Act
			var result = library.BorrowBook("thisbookdontexist");
			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BorrowBook_NullISBN_ShouldReturnFalse()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			// Act
			var result = library.BorrowBook(null!);
			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void BorrowBook_EmptyISBN_ShouldReturnFalse()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			// Act
			var result = library.BorrowBook("");
			// Assert
			Assert.IsFalse(result);
		}


	}
}
