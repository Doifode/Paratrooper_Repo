using SP_ProjectCalling.Models.Domain;

namespace SP_ProjectCalling.Interfaces
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployees();
        public List<Supervisor> GetAllSupervisors();

    }
}
