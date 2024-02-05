using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShelterProject.Models;
using ShelterProject.Services;
using System.Security.Claims;

namespace ShelterProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var user = await unitOfWork.ApplicationUserRepository.GetById(id);
            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, ApplicationUser userToUpdate)
        {
            var user = await unitOfWork.ApplicationUserRepository.GetById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    await unitOfWork.ApplicationUserService.Update(userToUpdate);
                    unitOfWork.Save();
                    return Ok();
                }
                else if (User.IsInRole("User"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (id == userId)
                    {
                        await unitOfWork.ApplicationUserService.Update(userToUpdate);
                        unitOfWork.Save();
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized("Unable to update user");
                    }
                }
                else
                {
                    return Unauthorized("Unable to update user");
                }
            }
            else
            {
                return Unauthorized("Please login to access this resource");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> DeleteUser(string id) // GDPR compliance =))
        {
            var user = await unitOfWork.ApplicationUserRepository.GetById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    await unitOfWork.ApplicationUserService.Delete(user);
                    unitOfWork.Save();
                    return Ok();
                }
                else if (User.IsInRole("User"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (userId == id)
                    {
                        await unitOfWork.ApplicationUserService.Delete(user);
                        unitOfWork.Save();
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized("Unable to update user");
                    }
                }
                else
                {
                    return Unauthorized("Unable to update user");
                }
            }
            else
            {
                return Unauthorized("Please login to access this resource");
            }
        }
    }
}
