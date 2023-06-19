using gerdisc.Models.Entities;

namespace gerdisc.Infrastructure.Repositories.ProfessorProject
{
    public interface IProfessorProjectRepository : IBaseRepository<ProfessorProjectEntity>
    {
        Task HandlesByProject(IEnumerable<Guid> newProfessors, ProjectEntity Project);
        Task HandleByProfessor(IEnumerable<Guid> newProjects, ProfessorEntity Professor);
    }
}