using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public enum PaymentMethodType
    {
        BankAccount = 1,
        CreditCard = 2
    }
}