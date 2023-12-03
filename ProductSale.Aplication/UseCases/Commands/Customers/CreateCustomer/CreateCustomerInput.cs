namespace ProductSale.Aplication.UseCases.Commands.Customers.CreateCustomer
{
    public record CreateCustomerInput
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public CreateCustomerInput(string name, string phone, string register)
        {
            Name = name;
            Phone = phone;
            Register = register;
        }
    }
}