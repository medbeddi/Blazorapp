using AutoMapper;
using EmployeeManagment.web.Services;
using EmployeeManagment.web.ViewModels;
using Microsoft.AspNetCore.Components;
using Models;


namespace EmployeeManagment.web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();


        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department = Employee.Department;

            Mapper.Map(Employee, EditEmployeeModel);
        }



        public string ErrorMessage { get; set; }

        protected async Task HandleValidSubmit()
        {
            EditEmployeeModel.DepartmentId = int.Parse(DepartmentId);
            Mapper.Map(EditEmployeeModel, Employee);

            try
            {
                var result = await EmployeeService.UpdateEmployee(Employee);
                if (result != null)
                {
                    NavigationManager.NavigateTo("/EmployeeList");
                }
                else
                {
                    ErrorMessage = "La mise à jour a échoué. Veuillez réessayer.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erreur lors de la mise à jour : {ex.Message}";
            }
        }



    }
}
