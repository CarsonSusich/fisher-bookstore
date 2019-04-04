using System;
using Xunit;
using Models.Book;

namespace tests
{
    public class BookTest
    {
        [Fact]
        public void ChangePublicationDate()
        {
        Assert.Equal(DateTime.Now.AddMonths(2), book.PublishDate);
        var book = new Book()
        {
            Id = 1,
            Title = "Domain Driven Design"
            Author = new Author()
            {
                Id = 65,
                Name = "Eric Evans"
            }
            PublishDate = DateTime.Now.AddMonths(-6),
            Publisher = "McGraw-Hill"
        };
        book.ChangePublicationDate(DateTime.Now.AddMonths(2));
        }
    }
}