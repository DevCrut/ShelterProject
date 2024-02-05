using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShelterProject.Models;
using ShelterProject.Services;
using System.Security.Claims;

namespace ShelterProject.Controllers
{
    public class ShelterController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ShelterController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelter>>> GetShelter()
        {
            return await unitOfWork.ShelterRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shelter>> GetShelter(Guid id)
        {
            var shelter = await unitOfWork.ShelterRepository.GetById(id);
            return shelter;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelter(Guid id, Shelter shelterToUpdate)
        {
            var shelter = await unitOfWork.ShelterRepository.GetById(id);
            if (shelter == null)
            {
                return NotFound("Shelter not found");
            }
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    await unitOfWork.ShelterService.Update(shelterToUpdate);
                    unitOfWork.Save();
                    return Ok();
                }
                else if (User.IsInRole("User"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (await unitOfWork.ShelterRepository.DoesShelterHaveOwner(id, userId) == true)
                    {
                        await unitOfWork.ShelterService.Update(shelterToUpdate);
                        unitOfWork.Save();
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized("Unable to update shelter");
                    }
                }
                else
                {
                    return Unauthorized("Unable to update shelter");
                }
            }
            else
            {
                return Unauthorized("Please login to access this resource");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Shelter>> PostShelter(Shelter shelterToCreate)

        {
            await unitOfWork.ShelterService.Create(shelterToCreate);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> DeleteShelter(Guid id)
        {
            var shelter = await unitOfWork.ShelterRepository.GetById(id);
            if (shelter == null)
            {
                return NotFound("Shelter not found");
            }
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    await unitOfWork.ShelterService.Delete(shelter);
                    unitOfWork.Save();
                    return Ok();
                }
                else if (User.IsInRole("User"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (await unitOfWork.ShelterRepository.DoesShelterHaveOwner(id, userId) == true)
                    {
                        await unitOfWork.ShelterService.Delete(shelter);
                        unitOfWork.Save();
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized("Unable to update shelter");
                    }
                }
                else
                {
                    return Unauthorized("Unable to update shelter");
                }
            }
            else
            {
                return Unauthorized("Please login to access this resource");
            }
        }
    }
}
