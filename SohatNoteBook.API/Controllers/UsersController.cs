using Microsoft.AspNetCore.Mvc;
using SohatNoteBook.DataService.Data;
using SohatNoteBook.Entities.DbSet;
using SohatNoteBook.Entities.Dtos.Incoming;

namespace SohatNoteBook.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        // Get
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(Guid id){
            var user=_context.Users.Where(u => u.Id ==id ); 
            return Ok(user);
        }
        // Post
        [HttpPost]
        public IActionResult PostUser(UserDto user){
            var _user = new User();
            _user.LastName = user.LastName;
            _user.FirstName = user.FirstName;
            _user.Email = user.Email;
            _user.DateOfBirth = Convert. ToDateTime (user .DateOfBirth);
            _user.Phone = user.Phone;
            _user.Country=user.Country;
            _user.Status = 1;
            _context.Users.Add(_user);
            _context.SaveChanges();
            return Ok();
        }
        // Get All 
        [HttpGet]
        public IActionResult GetUsers(){
            var users=_context.Users.Where(u => u.Status ==1 ).ToList(); 
            return Ok(users);
        }

    }
}