using System;

namespace XPTO.Product.Application.Command
{
    public class RegisterProductCommand : Core.Messages.Command
    {
        public RegisterProductCommand(Guid id, int stockBalance, string name, bool active)
        {
            StockBalance = stockBalance;
            Name = name;
            Active = active;
            Id = id;
        }

        public int StockBalance { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public Guid Id { get; set; }
    }
}
