using Labb4_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestClass]
	public class BookManagementTests
	{
		#region Add Book

		[TestMethod]
		public void AddBook_WithUniqueISBN_ShouldAddSuccessfully()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book newBook = new Book("New Book", "New Author", "1234567890", 2023);
			// Act
			int booksCount = library.GetAllBooks().Count;

			bool result = library.AddBook(newBook);
			// Assert
			Assert.IsTrue(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount + 1);
		}

		[TestMethod]
		public void AddBook_WithoutISBN_ShouldNotAdd()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book newBook = new Book("New Book", "New Author", "", 2000);
			// Act
			int booksCount = library.GetAllBooks().Count;
			bool result = library.AddBook(newBook);
			// Assert
			Assert.IsFalse(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount);
		}

		[TestMethod]
		public void AddBook_WithNullISBN_ShouldNotAdd()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book newBook = new Book("New Book", "New Author", null, 2025);
			// Act
			int booksCount = library.GetAllBooks().Count;
			bool result = library.AddBook(newBook);
			// Assert
			Assert.IsFalse(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount);
		}

		[TestMethod]
		public void AddBook_WithExistingISBN_ShouldNotAdd()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book existingBook = new Book("Existing Book", "Existing Author", "123", 2025);
			library.AddBook(existingBook);
			Book newBook = new Book("New Book", "New Author", "123", 2023);
			int booksCount = library.GetAllBooks().Count;

			// Act
			bool result = library.AddBook(newBook);
			// Assert
			Assert.IsFalse(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount); // make sure its the same count
		}
		#endregion

		#region Remove Book	
		[TestMethod]
		public void RemoveBook_ShouldRemoveSuccessfully()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			Book book = new Book("Title", "Author", "999", 2023);
			library.AddBook(book);

			int booksCount = library.GetAllBooks().Count;

			//Act
			bool result = library.RemoveBook("999");

			// Assert
			Assert.IsTrue(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount - 1); // check if its one less than before
		}

		[TestMethod]
		public void RemoveBook_BorrowedBook_ShouldNotRemove()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();

			Book book = new Book("Title", "Author", "999", 2023);
			library.AddBook(book);
			library.BorrowBook("999");
			int booksCount = library.GetAllBooks().Count;
			bool result = library.RemoveBook("999");

			// Assert
			Assert.IsFalse(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount); // check if its the same count
		}

		[TestMethod]
		public void RemoveBook_NonExistentISBN_ShouldNotRemove()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			int booksCount = library.GetAllBooks().Count;
			bool result = library.RemoveBook("00000000");
			// Assert
			Assert.IsFalse(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount); // check if its the same count
		}

		[TestMethod]
		public void RemoveBook_NullISBN_ShouldNotRemove()
		{
			// Arrange
			LibrarySystem library = new LibrarySystem();
			int booksCount = library.GetAllBooks().Count;
			bool result = library.RemoveBook(null);
			// Assert
			Assert.IsFalse(result);
			Assert.IsTrue(library.GetAllBooks().Count == booksCount); // check if its the same count
		}

		#endregion
	}
}
