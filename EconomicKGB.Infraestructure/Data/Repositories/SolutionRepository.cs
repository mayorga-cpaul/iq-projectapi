using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class SolutionRepository : BaseRepository<Solution>, ISolutionRepository
    {
        private readonly EconomicKGBContext repository;
        public SolutionRepository(EconomicKGBContext repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(Int32 solution)
        {
            try
            {
                return await Task.FromResult(repository.Projects.Where(p => p.SolutionId == solution));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Solution>> GetByUserAsync(Int32 usuario)
        {
            try
            {
                return await Task.FromResult(repository.Solutions.Where(e => e.UserId == usuario));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Solution>> GetByUserEmailAsync(string email)
        {
            try
            {
                if (email is null)
                {
                    throw new ArgumentNullException("El email no puede ser null");
                }
                var user = await repository.Usuarios.
                    Where(u => u.Email == email).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new ArgumentException("No existe un usuario con este email");
                }

                return await Task.FromResult(repository.Solutions.Where(s => s.UserId == user.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Solution> GetSolutionByIdAsync(Int32 id)
        {
            try
            {
                if (id < 0)
                {
                    throw new Exception("null");
                }

                var data = repository.Solutions.Find(id);
                if (data is null)
                {
                    throw new Exception("null");
                }

                return await Task.FromResult(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Boolean> SetOneProjectToSolutionAsync(Int32 project, Int32 solution)
        {
            try
            {
                //TODO: Revision de metodo set y cambio 
                //Este codigo verifica si el id del proyecto que se le pasa esta en el repositorio
                //y si es asi porque lo vuelve a agregar?
                //var data = await repository.Projects.FirstOrDefaultAsync(e => e.Id == project);
                //if (data is null)
                //{
                //    throw new Exception("EL proyecto no fue encontrado");
                //}
                //repository.Projects.Add(data);

                //TODO: posibles cambios en el metodo de setOneProject
                var proj = await repository.Projects.FirstOrDefaultAsync(e => e.Id == project);
                if(proj is null)
                {
                    throw new Exception("El proyecto que esta tratando de asignar no existe");
                }
                if(proj.SolutionId == solution)
                {
                    throw new Exception("El proyecto ya esta asignado a esa solucion");
                }
                proj.SolutionId = solution;
                repository.Projects.Update(proj);

                return await Task.FromResult((repository.SaveChanges() > 0) ? true : false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetProjectToSolutionAsync(IEnumerable<Project> projects, Int32 solution)
        {
            if(projects is null)
            {
                throw new Exception("No se seleccionaron proyectos para asignar");
            }
            foreach (var item in projects)
            {
                if (item.Solution.Id != solution)
                {
                    throw new Exception("Error al asignar proyecto a solution");
                }
                repository.Projects.Add(item);
            }
            //TODO: Este metodo da error al probarlo desde swagger
            return await Task.FromResult((repository.SaveChanges() > 0) ? true : false);
        }
    }
}
