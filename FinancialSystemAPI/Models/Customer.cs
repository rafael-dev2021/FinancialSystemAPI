using FinancialSystemAPI.Models.ObjectValue;

namespace FinancialSystemAPI.Models;

public class Customer : User
{
    public Customer(string cPF, string name, string phone, string email)
        : base(cPF, name, phone, email) { }

    public Customer(string cPF, string name, string phone, string email, AddressObjectValue? addressObjectValue)
       : base(cPF, name, phone, email) => AddressObjectValue = addressObjectValue;
    public Customer() { }

    public AddressObjectValue? AddressObjectValue { get; set; }
    public List<Account>? Accounts { get; set; } 

}
