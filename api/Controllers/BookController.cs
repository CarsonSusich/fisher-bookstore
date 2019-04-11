using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Api.Data;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fisher.Bookstore.Api.Controllers
{

    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {

            var book = this.db.Books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            if(book == null)
            {
                return BadRequest();
            }
            this.db.Books.Add(book);
            this.db.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if(book == null || book.Id != id)

            {
                return BadRequest();
            }

            var bookToEdit = this.db.Books.FirstOrDefault(b => b.Id == id);
            if(bookToEdit == null)
            {
                return NotFound();
            }

            bookToEdit.Title = book.Title;
            bookToEdit.ISBN = book.ISBN;

            this.db.Books.Update(bookToEdit);
            this.db.SaveChanges();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            var book = this.db.Books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            this.db.Books.Remove(book);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}