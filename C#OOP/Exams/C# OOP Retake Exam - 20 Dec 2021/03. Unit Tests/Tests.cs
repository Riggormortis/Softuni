namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {

        private const string BookName = "Some Book";
        private const string Author = "Some Author";
        private const int FootnoteNumber = 1;
        private const string FootnoteText = "Some text";

        private Book book;

        [SetUp]
        public void Setup()
        {
            this.book = new Book(BookName, Author);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ThrowsException_WhenBookNameIsNullOrEmpty(string bookName)
        {
            Assert.That(() => new Book(bookName, Author), Throws.ArgumentException);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ThrowsException_WhenAuthorIsNullOrEmpty(string author)
        {
            Assert.That(() => new Book(BookName, author), Throws.ArgumentException);
        }

        [Test]
        public void Ctor_Works_Correctly_When_Data_Is_Valid()
        {
            var book = new Book(BookName, Author);

            Assert.That(book.BookName, Is.EqualTo(BookName));
            Assert.That(book.Author, Is.EqualTo(Author));
            Assert.That(book.FootnoteCount, Is.EqualTo(0));

        }
        [Test]
        public void AddFootNote_Correctly_When_Data_Is_Valid()
        {
            var book = new Book(BookName, Author);
            Assert.That(book.FootnoteCount, Is.EqualTo(0));

            book.AddFootnote(FootnoteNumber, FootnoteText);

            Assert.That(book.FootnoteCount, Is.EqualTo(1));
        }

        [Test]
        public void AddFootNote_Throws_Exception_When_Added_Same_Footnote()
        {
            var book = new Book(BookName, Author);
            
            book.AddFootnote(FootnoteNumber, FootnoteText);

            Assert.That(book.FootnoteCount, Is.EqualTo(1));

            Assert.That(() => book.AddFootnote(FootnoteNumber, FootnoteText), Throws.InvalidOperationException);
        }

        [Test]
        public void FindFootnote_Throws_Exception_When_Footnote_DontExist()
        {
            int nonExistentFootNoteNumber = 3;

            Assert.That(() => book.FindFootnote(nonExistentFootNoteNumber), Throws.InvalidOperationException);

        }

        [Test]
        public void FindFootnote_Correctly_When_Data_Is_Valid()
        {
            var book = new Book(BookName, Author);
            book.AddFootnote(FootnoteNumber, FootnoteText);

            string givenResult = book.FindFootnote(FootnoteNumber);

            string expectedResult = "Footnote #1: Some text";

            Assert.AreEqual(givenResult, expectedResult);
        }
        [Test]
        public void AlterFootnote_Throws_Exception_When_Footnote_DontExist()
        {
            int nonExistentFootNoteNumber = 3;

            string newText = "some new text";

            Assert.That(() => book.AlterFootnote(nonExistentFootNoteNumber, newText), Throws.InvalidOperationException);

        }

        [Test]
        public void AlterFootnote_Correctly_When_Data_Is_Valid()
        {
            var book = new Book(BookName, Author);
            book.AddFootnote(FootnoteNumber, FootnoteText);
            string newText = "some new text";


             book.AlterFootnote(FootnoteNumber, newText);

            string givenResult = book.FindFootnote(FootnoteNumber);

            string expectedResult = "Footnote #1: some new text";

            Assert.AreEqual (givenResult, expectedResult);

        }

    }
}