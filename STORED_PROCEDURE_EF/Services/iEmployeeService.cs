using STORED_PROCEDURE_EF.Model;

namespace STORED_PROCEDURE_EF.Services
{
    public interface iEmployeeService
    {
        Task<List<EmployeEntity>> GetAllEmployee();
        Task<EmployeEntity> GetById(int id);
        Task<ResponseDto> UpdateEmployee(UpdateEmpDto empdto,int id);
        Task<ResponseDto> DeleteEmployee(int id);
        Task<ResponseDto> AddEmployee(UpdateEmpDto empdto);
    }
}
