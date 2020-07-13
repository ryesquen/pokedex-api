using Common.Collection;
using Common.Paging;
using Models;
using Newtonsoft.Json;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Repository.Json
{
    public class PokemonRepository : IPokemonRepository
    {
        public async Task<DataCollection<Pokemon>> GetAllAsync(int page, int take)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\pokedex.json");
            string json = await File.ReadAllTextAsync(path);
            var listaPokemon = JsonConvert.DeserializeObject(json, typeof(List<Pokemon>));
            List<Pokemon> pokemons = new List<Pokemon>();
            pokemons = (List<Pokemon>)listaPokemon;
            string path2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\thumbnails");
            string[] filePaths = Directory.GetFiles(path2);
            for (int i = 0; i < filePaths.Length; i++)
            {
                var file = await File.ReadAllBytesAsync(filePaths[i]);
                string filestring = Convert.ToBase64String(file);
                pokemons[i].Image = filestring;
            }
            return pokemons.GetPaged(page, take);
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\pokedex.json");
            string json = await File.ReadAllTextAsync(path);
            var _pokemons = JsonConvert.DeserializeObject(json, typeof(List<Pokemon>));
            Pokemon pokemon = new Pokemon();
            foreach (var item in (List<Pokemon>)_pokemons)
            {
                if (item.Id == id)
                {
                    pokemon = item;
                }
            }
            string path2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\thumbnails");
            string[] filePaths = Directory.GetFiles(path2);
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (filePaths[i].Contains(id.ToString("D3")))
                {
                    var file = await File.ReadAllBytesAsync(filePaths[i]);
                    string filestring = Convert.ToBase64String(file);
                    pokemon.Image = filestring;
                }
            }
            return pokemon;
        }
    }
}
