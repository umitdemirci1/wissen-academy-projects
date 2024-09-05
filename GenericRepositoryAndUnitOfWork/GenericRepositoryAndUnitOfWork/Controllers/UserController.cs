using GenericRepositoryAndUnitOfWork.Core.IConfiguratin;
using GenericRepositoryAndUnitOfWork.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryAndUnitOfWork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> logger;
        private IUnitOfWork unitOfWork;

        public UserController(ILogger<UserController> _logger, IUnitOfWork _unitOfWork)
        {
            this.logger = _logger;
            this.unitOfWork = _unitOfWork;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var userList = await unitOfWork.Users.GetAllAsync();
            return Ok(userList);
        }

        [HttpGet]
        [Route("GetUser/{userId}")]
        public async Task<IActionResult> GetUserItem(Guid userId)
        {
            var user = await unitOfWork.Users.GetByIDAsync(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
                user.UserId = Guid.NewGuid();

                await unitOfWork.Users.AddAsync(user);
                await unitOfWork.ComplateAsync();

                return CreatedAtAction("GetUserItem", new { user.UserId }, user);
            }
            return new JsonResult("Get An Error Createing New User") { StatusCode = 500 };
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Update(Guid userId,User user)
        {
            if(userId != user.UserId)
                return BadRequest();

            await unitOfWork.Users.UpdateAsync(user);
            await unitOfWork.ComplateAsync();
            //return NoContent();
            //User findUser = (User)await unitOfWork.Users.FindAsync(x => x.UserId == userId);
            IEnumerable<User> list = await unitOfWork.Users.FindAsync(x => x.UserId == userId);
            User findUser = list.FirstOrDefault();
            return Ok(findUser);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            User user = await unitOfWork.Users.GetByIDAsync(userId);

            if (user == null)
                return BadRequest();

            await unitOfWork.Users.DeleteAsync(user.UserId);
            await unitOfWork.ComplateAsync();

            return Ok(user);
        }
    }
}
