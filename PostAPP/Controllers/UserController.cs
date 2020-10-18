using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostAPP.Data;
using PostAPP.Models;

namespace PostAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _appDB;
        public UserController(AppDBContext appDB)
        {
            _appDB = appDB;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _appDB.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var model = await _appDB.User.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            _appDB.User.Add(user);
            await _appDB.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _appDB.Entry(user).State = EntityState.Modified;

            try
            {
                await _appDB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = await _appDB.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _appDB.User.Remove(user);
            await _appDB.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _appDB.User.Any(e => e.Id == id);
        }
    }
}
