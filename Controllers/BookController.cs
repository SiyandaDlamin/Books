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
        public IHttpActionResult Get()
        {
            return Ok(books);
        }

        // GET: api/Book/5
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}
