using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookWithIdentity.Data;
using bookWithIdentity.SD;
using Microsoft.AspNetCore.Authorization;

namespace bookWithIdentity.Pages.Booklist
{
    [Authorize(Roles = Role.Role_admin)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public String Msg { get; set; }

        public CreateModel(ApplicationDbContext db) {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {
            if(!ModelState.IsValid)
                return Page();

            _db.Livre.Add(this.Book);
            await _db.SaveChangesAsync();
            Msg = "Book Added !";
            return RedirectToPage("Index");


        }
    }
}