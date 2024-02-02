namespace FinancialSystemAPI.Models;

public class User
{
    public User(string cPF, string name, string phone, string email)
    {
        CPF = cPF;
        Name = name;
        Phone = phone;
        Email = email;
    }
    public User()
    { }

    public string CPF { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
