using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShelterProject.Models;
using ShelterProject.Services;
using System.Security.Claims;

namespace ShelterProject.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AnimalController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return await unitOfWork.AnimalsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(Guid id)
        {
            var animal = await unitOfWork.AnimalsRepository.GetById(id);
            return animal;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(Guid id, Animal animlToUpdate)
        {
            var animal = await unitOfWork.AnimalsRepository.GetById(id);
            if (animal == null)
            {
                return NotFound("Animal not found");
            }
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    await unitOfWork.AnimalsService.Update(animlToUpdate);
                    unitOfWork.Save();
                    return Ok();
                }
                else if (User.IsInRole("User"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (await unitOfWork.AnimalsRepository.DoesAnimalHaveOwner(id, userId) == true)
                    {
                        await unitOfWork.AnimalsService.Update(animlToUpdate);
                        unitOfWork.Save();
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized("Unable to update animal");
                    }
                }
                else
                {
                    return Unauthorized("Unable to update animal");
                }
            }
            else
            {
                return Unauthorized("Please login to access this resource");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animalToCreate)

        {
            await unitOfWork.AnimalsRepository.Create(animalToCreate);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> DeleteAnimal(Guid id)
        {
            var animal = await unitOfWork.AnimalsRepository.GetById(id);
            if (animal == null)
            {
                return NotFound("Animal not found");
            }
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    await unitOfWork.AnimalsService.Delete(animal);
                    unitOfWork.Save();
                    return Ok();
                }
                else if (User.IsInRole("User"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (await unitOfWork.AnimalsRepository.DoesAnimalHaveOwner(id, userId) == true)
                    {
                        await unitOfWork.AnimalsService.Delete(animal);
                        unitOfWork.Save();
                        return Ok();
                    }
                    else
                    {
                        return Unauthorized("Unable to update animal");
                    }
                }
                else
                {
                    return Unauthorized("Unable to update animal");
                }
            }
            else
            {
                return Unauthorized("Please login to access this resource");
            }
        }
    }
}
