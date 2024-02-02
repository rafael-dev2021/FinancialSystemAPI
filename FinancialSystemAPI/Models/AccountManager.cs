namespace FinancialSystemAPI.Models;

public class AccountManager : User
{
    public AccountManager(string cPF, string name, string phone, string email, int employeeCode)
      : base(cPF, name, phone, email) => EmployeeCode = employeeCode;
    public AccountManager() { }

    public int EmployeeCode { get; set; }
}
