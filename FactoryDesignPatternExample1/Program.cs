using System;

namespace DesignPatterns
{
    /* Problem Statement: Online Payment Processing System
       You are designing an e-commerce platform that needs to handle multiple types of payment methods:
       Credit Card, PayPal, Google Pay, Apple Pay, Bank Transfer */
    class Program
    {
        static void Main(string[] args)
        {
            PaymentMethods paymentMethods = PaymentMethods.GooglePay;
            int amount = 1000;
            IPaymentProcess paymentFactory = PaymentFactory.GetPaymentProcessor(paymentMethods);
            paymentFactory.Pay(amount);
        }
    }

    public static class PaymentFactory
    {
        public static IPaymentProcess GetPaymentProcessor(PaymentMethods method)
        {
            return method switch
            {
                PaymentMethods.CreditCard => new CreditClassProcess(),
                PaymentMethods.PayPal => new PayPalProcess(),
                PaymentMethods.GooglePay => new GooglePayProcess(),
                PaymentMethods.ApplePay => new ApplePayProcess(),
                PaymentMethods.BankTransfer => new BankTransferProcess(),
                _ => throw new ArgumentException("Unsupported payment method")
            };
        }
    }

    public interface IPaymentProcess
    {
        void Pay(int amount);
    }

    public enum PaymentMethods
    {
        CreditCard,
        PayPal,
        GooglePay,
        ApplePay,
        BankTransfer
    }

    public class CreditClassProcess : IPaymentProcess
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paying through Credit Card amount {0}", amount);
        }
    }

    public class PayPalProcess : IPaymentProcess
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paying through PayPal amount {0}", amount);
        }
    }

    public class GooglePayProcess : IPaymentProcess
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paying through Google Pay {0}", amount);
        }
    }

    public class ApplePayProcess : IPaymentProcess
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paying through Apple Pay {0}", amount);
        }
    }

    public class BankTransferProcess : IPaymentProcess
    {
        public void Pay(int amount)
        {
            Console.WriteLine("Paying through Bank Transfer {0}", amount);
        }
    }

}