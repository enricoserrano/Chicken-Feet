using EV.Models;
using EV.Dtos;

namespace EV.Data
{
    public interface IEVRepo {
        public IEnumerable<Breed> GetAllBreeds();
        public Breed? GetBreed(string breed_name);
    }
}