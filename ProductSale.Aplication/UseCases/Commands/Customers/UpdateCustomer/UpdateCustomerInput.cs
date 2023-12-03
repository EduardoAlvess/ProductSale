namespace ProductSale.Aplication.UseCases.Commands.Customers.UpdateCustomer
{
    public record UpdateCustomerInput
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Register { get; private set; }

        public UpdateCustomerInput(int id, string name, string phone, string register)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Register = register;
        }
    }
}