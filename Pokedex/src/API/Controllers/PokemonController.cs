using Common.Collection;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<DataCollection<Pokemon>> GetAll(int page = 1, int take = 10)
        {
            return await _pokemonService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> Get(int id)
        {
            return await _pokemonService.GetAsync(id);
        }
    }
}
