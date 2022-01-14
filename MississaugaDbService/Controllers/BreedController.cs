using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MississaugaDbService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedController : ControllerBase
    {
        private readonly ILogger<BreedController> _logger;
        private readonly PetLicensingContext _context;

        public BreedController(ILogger<BreedController> logger, PetLicensingContext context)
        {

            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllBreeds()
        {
            Console.WriteLine("Getting all breeds");
            var breeds = _context.Owners;
            return Ok(breeds);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetBreeds(string animal)
        {
            Console.WriteLine("Getting breeds");
            var breeds = _context.Breeds as IEnumerable<Breed>;
            var result = breeds.First(x=>x.AnimalType == animal);
            // TODO
            // do not return empty list
            return Ok(result);
        }

        [HttpGet]
        [Route("seed-breeds")]
        public IActionResult SeedSomeBreeds()
        {
            // Check to see the database is created before running.
            Console.WriteLine($"Database path: {_context.DbPath}.");

            
            //TODO
            // remove the list creation to a listservice.cs
            // fetch the list from the new source
            Console.WriteLine("Inserting a new breed");
            List<Breed> breeds = new List<Breed>() {
                new Breed { Name="BURMESE", AnimalType="CAT" },
                new Breed { Name="CHARTREUX", AnimalType="CAT" },
                new Breed { Name="COLORPOINT", AnimalType="CAT" },
                new Breed { Name="CORNISH REX", AnimalType="CAT" },
                new Breed { Name="CYMRIC", AnimalType="CAT" },
                new Breed { Name="PAPILLON", AnimalType="DOG" },
                new Breed { Name="PEKINGESE", AnimalType="DOG" },
                new Breed { Name="PHARAOH HOUND", AnimalType="DOG" },
                new Breed { Name="PICARDY SHEEPDOG", AnimalType="DOG" },
                new Breed { Name="PIT BULL", AnimalType="DOG" }
            };
            //END of TODO

            _context.AddRange(breeds);
            _context.SaveChanges();
            return Ok(breeds);
        }

    }
}