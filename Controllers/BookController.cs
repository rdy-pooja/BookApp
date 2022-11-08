using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository;
        }
        // GET: api/<BookController>
        [HttpGet]
        //public IEnumerable<string> GetBooks()
        public async Task<IActionResult> GetBooks()
        {
            List<Book> books = _bookRepository.GetBooks();
            if (books == null)
            {
                return BadRequest("No Books Found");
            }
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        //public string GetBookByID(int id)
        public async Task<IActionResult> GetBookByID(string ID)
        {
            Book book = _bookRepository.GetBookByID(ID);
            if (book == null)
            {
                return BadRequest("No Book found by the given ID.");
            }
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            if(_bookRepository.AddBook(book))
            {
                return Ok();
            }
            return NotFound("Not able to add book. Please try again.");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyBookDetails(string ID, [FromBody] Book book)
        {
            if(_bookRepository.ModifyBookDetails(ID, book))
            {
                return Ok("Book Details Modified Successfully.");
            }
            return NotFound("Book not found to modify.");
        }
    }
}
