using EV.Models;
using EV.Dtos;

namespace EV.Data
{
    public class EVRepo : IEVRepo
    {
        private readonly EVDBContext _dbContext;

        public EVRepo(EVDBContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<Breed> GetAllBreeds() {
            return _dbContext.Breeds.ToList<Breed>();
        }

        public Breed? GetBreed(string breed_name) {
            return _dbContext.Breeds.FirstOrDefault(e => e.breed_name == breed_name);
        }
    }
}