using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppAPI_Book.Models;

namespace WebAppAPI_Book.Controllers
{
    public class BookController : ApiController
    {
        Book[] books = new Book[]
        {

            new Book(){Id=1,Author="Billy Goat", Price=100,Title="Spider without Duty"},
            new Book(){Id=2,Author="Siyanda Dlamini", Price=200,Title="The Climb"},
            new Book(){Id=3,Author="Bafo Khanyeza", Price=100,Title="Accounting"}
        };
        // GET: api/Book
        //Read the whole list
        public IHttpActionResult Get()
        {
            return Ok(books);
        }

        // GET: api/Book/5
        // Read a specific item from the list
        public IHttpActionResult Get(int id)
        {
            Book book = books.FirstOrDefault<Book>(B => B.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Book
        //Insert an object
        public IHttpActionResult Post([FromBody]Book newBook)
        {
            List<Book> BookList = books.ToList<Book>();
            newBook.Id = BookList.Count + 1;
            BookList.Add(newBook);
            return Ok(BookList.ToList());
        }

        // PUT: api/Book/5
        //Also another Name for Update
        public IHttpActionResult Put(int id, [FromBody]Book updatedBook)
        {
            Book book = books.FirstOrDefault<Book>(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Price = updatedBook.Price;
            book.Author = updatedBook.Author;
            book.Title = updatedBook.Title;
            return Ok(books);
        }

        // DELETE: api/Book/5
        public IHttpActionResult Delete(int id)
        {
            List<Book> BookList = books.ToList<Book>();
            Book bookToRemove = books.FirstOrDefault<Book>(b => b.Id == id);
            if (bookToRemove == null)
            {
                return NotFound();
            }
            BookList.Remove(bookToRemove);
            return Ok(BookList.ToList());
        }
    }
}
