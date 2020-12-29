using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookWithIdentity.Data;
using Microsoft.EntityFrameworkCore;

namespace bookWithIdentity.Pages.Booklist
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> Books { get; set;} 
                                                  
        private readonly ApplicationDbContext _db;

        [TempData]
        public String Msg { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGet()
        {
            Books = await _db.Livre.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Livre.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Livre.Remove(book);
            await _db.SaveChangesAsync();
            Msg = "Book Deleted !!!";
            return RedirectToPage("Index");
        }
       
    }
}