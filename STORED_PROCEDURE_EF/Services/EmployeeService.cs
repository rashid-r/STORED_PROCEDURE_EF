

namespace STORED_PROCEDURE_EF.Services
{
    public class EmployeeService : iEmployeeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeEntity>> GetAllEmployee()
        {
            try
            {
                var emp = await _dbContext.Employee.FromSqlRaw("EXEC GETALLEMPLOYEES").ToListAsync();
                return emp;
            }
            catch (Exception ex)
            {
                throw new Exception("no details available");
            }
        }
        public async Task<EmployeEntity> GetById(int id)
        {
            try
            {

                var result = await _dbContext.Employee
                    .FromSqlRaw($"EXEC GETBYIDEMP @ID = {id}")
                    .ToListAsync();

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employee by ID", ex);
            }
        }
        public async Task<ResponseDto> UpdateEmployee(UpdateEmpDto empdto,int id)
        {
            try
            {
                var emp = await _dbContext.Employee.FirstOrDefaultAsync(x => x.Id == id);
                if (emp != null)
                {
                    await _dbContext.Database.ExecuteSqlAsync(
                        $"EXEC UPDATEEMPLOYEE @ID={id}, @NAME={empdto.Name}, @AGE={empdto.Age}, @DEPARTMENT={empdto.Department}, @SALARY={empdto.Salary}");

                    return new ResponseDto { Message = "Updated Successfully" };
                }
                return new ResponseDto { Message = "Pls Enter A valid Id" };
            }
            catch (Exception ex)
            {
                throw new Exception("Updation Failed", ex);
            }
        }
        public async Task<ResponseDto> DeleteEmployee(int id)
        {
            try
            {
                var del = await _dbContext.Database.ExecuteSqlAsync($"EXEC DELETEEMP @ID = {id}");
                return new ResponseDto { Message = "Deleted Successfully" };
            }
            catch (Exception ex) 
            {
                throw new Exception("Updation Failed", ex);
            }
            
        }
        public async Task<ResponseDto> AddEmployee(UpdateEmpDto empdto)
        {
            try
            {
                var add = await _dbContext.Database.ExecuteSqlAsync($"EXEC ADDEMPLOYEE @NAME={empdto.Name}, @AGE={empdto.Age}, @DEPARTMENT={empdto.Department}, @SALARY={empdto.Salary}");
                return new ResponseDto { Message = "Employee Added Successfully" };
            }
            catch (Exception ex)
            {
                throw new Exception("Updation Failed", ex);
            }
        }

    }
}
