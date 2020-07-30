using System;
using XPTO.Core.Domain;

namespace XPTO.Product.Domain
{
    public class Product : Entity, IAggreateRoot
    {
        public int StockBalance { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public Product(Guid id, string name, int stockBalance)
        {
            Id = id;
            Name = name;
            StockBalance = stockBalance;
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            Name = name;
        }

        public void RestoreStock(int quantity) => StockBalance += quantity;

        public bool IsStock(int quantity) => StockBalance >= quantity;

        public void DebitarEstoque(int quantity)
        {
            ValidateIfMinor(quantity, StockBalance, "Insufficient stock");

            if (!Valid)
                return;

            StockBalance -= quantity;
        }

        public override bool IsValidate()
        {
            IsEmpty(Name, "The property Name cannot be empty");

            return Valid;
        }
    }
}