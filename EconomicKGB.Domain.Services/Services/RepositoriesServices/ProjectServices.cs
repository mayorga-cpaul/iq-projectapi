using SmartSolution.Domain.Entities.EntitiesBase;
using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using System.Net.Http.Headers;

namespace SmartSolution.Domain.Services.Services.RepositoriesServices
{
    public class ProjectServices : BaseServices<Project>, IProjectServices
    {
        private readonly IProjectRepository projectRepository;
        public ProjectServices(IProjectRepository projectRepository) : base(projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectEntry>> GetEntriesAsync(int projectId)
        {
            try
            {
                return await projectRepository.GetEntriesAsync(projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Project>> GetProjectsBySolAsync(int solution)
        {
            try
            {

                return await projectRepository.GetProjectsBySolAsync(solution);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetEntriesAsync(IEnumerable<ProjectEntry> ingresoProyectos, int projectId)
        {
            try
            {
                return await projectRepository.SetEntriesAsync(ingresoProyectos, projectId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
