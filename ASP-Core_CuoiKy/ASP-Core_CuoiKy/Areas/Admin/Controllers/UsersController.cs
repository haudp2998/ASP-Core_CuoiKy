using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Core_CuoiKy.Models;
using PagedList;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace ASP_Core_CuoiKy.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class UsersController : Controller
    {
        private readonly OnlineShopContext _context;

        public UsersController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Users
        [HttpGet("/admin/Users")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "UserName")
        {
            var us = _context.User.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                us = us.Where(p => p.UserName.Contains(searchString) || p.Name.Contains(searchString));
            }
            var model = await PagingList.CreateAsync(us,3,page,sortExpression,"Username");
            model.RouteValue = new RouteValueDictionary {
        { "searchString", searchString}
    };
            //ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/Users/Details/5
        [HttpGet("/admin/Users/Details")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Admin/Users/Create
        [HttpGet("/admin/Users/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,GroupId,Name,Address,Email,Phone,ProvinceId,DistrictId,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        [HttpGet("/admin/Users/Edit")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserName,Password,GroupId,Name,Address,Email,Phone,ProvinceId,DistrictId,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        [HttpGet("/admin/Users/Delete")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IEnumerable<User> ListAll(int page, int pageSize)
        {
            return _context.User.OrderBy(p=>p.Id).ToPagedList(page,pageSize);
        }
        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
