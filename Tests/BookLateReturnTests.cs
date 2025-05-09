using Labb4_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

	[TestClass]
	public class BookLateReturnTests
	{

		[TestMethod]
		public void ReturnLate_OverDueBook_ShouldReturn_True()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("1984", "George Orwell", "1234", 1949);
			library.AddBook(book);
			library.BorrowBook("1234");
			book.BorrowDate = DateTime.Now.AddDays(-10);

			// Act
			bool result = library.IsBookOverdue("1234", 7);

			// Assert
			Assert.IsTrue(result);
		}
		[TestMethod]
		public void ReturnLate_Book_NotOverDue_ShouldReturn_False()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("1984", "George Orwell", "1234", 1949);
			library.AddBook(book);
			library.BorrowBook("1234");
			book.BorrowDate = DateTime.Now.AddDays(-5);
			// Act
			bool result = library.IsBookOverdue("1234", 7);
			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnLate_BookNotFound_ShouldReturn_False()
		{
			// Arrange
			var library = new LibrarySystem();

			// Act
			bool result = library.IsBookOverdue("nonexistent", 7);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnLate_Book_Calculate_LateFee()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("1984", "George Orwell", "1234", 1949);
			library.AddBook(book);
			library.BorrowBook("1234");
			
			// Assert
			decimal lateFee = library.CalculateLateFee("1234",  10);
			decimal expectedFee = 10 * 0.5m;
			Assert.AreEqual(expectedFee, lateFee);
		}

		[TestMethod]
		public void ReturnLate_Book_Calculate_LateFee_ExtremelyLate()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("1984", "George Orwell", "1234", 1949);
			library.AddBook(book);
			library.BorrowBook("1234");

			// Assert
			decimal lateFee = library.CalculateLateFee("1234", 10000);
			decimal expectedFee = 10000 * 0.5m;
			Assert.AreEqual(expectedFee, lateFee);
		}


		[TestMethod]
		public void ReturnLate_CalculateLateFee_BookNotFound_ShouldReturnZero()
		{
			// Arrange
			var library = new LibrarySystem();

			// Act
			var fee = library.CalculateLateFee("nonexistent", 10);

			// Assert
			Assert.AreEqual(0m, fee);
		}

		[TestMethod]
		public void ReturnLate_NegativeDays_ShouldReturn_Zero()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("Test Book", "Author", "123", 2022);
			library.AddBook(book);
			library.BorrowBook("123");
			book.BorrowDate = DateTime.Now;

			// Act
			var fee = library.CalculateLateFee("123", -5); // -5 days

			// Assert
			Assert.AreEqual(0m, fee);
		}

		[TestMethod]
		public void ReturnLate_OnDueDate_ShouldReturn_False()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("Test Book", "Author", "123", 2022);
			library.AddBook(book);
			library.BorrowBook("123");
			book.BorrowDate = DateTime.Now.AddDays(-7);

			// Act
			bool result = library.IsBookOverdue("123", 7);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnLate_NegativeLoanPeriod_ShouldReturn_False()
		{
			var library = new LibrarySystem();
			var book = new Book("Test Book", "Author", "123", 2022);
			library.AddBook(book);
			library.BorrowBook("123");
			book.BorrowDate = DateTime.Now.AddDays(-3);

			var isOverdue = library.IsBookOverdue("123", -5);
			Assert.IsFalse(isOverdue);
		}


		[TestMethod]
		public void ReturnLate_BookNeverBorrowed_ShouldReturn_False()
		{
			// Arrange
			var library = new LibrarySystem();
			var book = new Book("Unborrowed Book", "Author", "9999", 2021);
			library.AddBook(book);

			// Act
			bool result = library.IsBookOverdue("9999", 7);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnLate_CalculateLateFee_NullISBN_ShouldReturnZero()
		{
			var library = new LibrarySystem();
			var fee = library.CalculateLateFee(null!, 5);
			Assert.AreEqual(0m, fee);
		}

		[TestMethod]
		public void ReturnLate_NullISBN_ShouldReturnFalse()
		{
			var library = new LibrarySystem();
			var isOverdue = library.IsBookOverdue(null!, 5);
			Assert.IsFalse(isOverdue);
		}
	}
}
