namespace FinancialSystemAPI.Models;

public class BoxCash(string cPF, string name, string phone, string email, int employeeCode) : User(cPF, name, phone, email)
{
    public int EmployeeCode { get; set; } = employeeCode;
}
