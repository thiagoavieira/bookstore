using bookstoreAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookstoreController : ControllerBase
    {
        private readonly ToDoContext _context;
    
        public bookstoreController(ToDoContext context){
            _context = context;

            _context.toDoBooks.Add(new Book { ID = "1", Name = "Clean Code", Price = 55.0, Quant = 1, Category = "Programming", Image = "img1" });
            _context.toDoBooks.Add(new Book { ID = "2", Name = "Head First: C#", Price = 75.0, Quant = 2, Category = "Programming1", Image = "img2" });
            _context.toDoBooks.Add(new Book { ID = "3", Name = "Head First: Java", Price = 39.9, Quant = 3, Category = "Programming2", Image = "img3" });
            _context.toDoBooks.Add(new Book { ID = "4", Name = "Honjok", Price = 42.4, Quant = 4, Category = "Social", Image = "img4" });
            _context.toDoBooks.Add(new Book { ID = "5", Name = "The Power of Habit", Price = 54.0, Quant = 8, Category = "Psicology", Image = "img5" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.toDoBooks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetItem(int id)
        {
            var item = await _context.toDoBooks.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
    }
}