using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello , how are you";
            IChannel channel = SendNotificationFactory.GetChannel(Channel.Teams);
            channel.sent(message);
        }
    }

    public static class SendNotificationFactory
    {
        public static IChannel GetChannel(Channel channel)
        {
            return channel switch
            {
                Channel.EMail => new EmailChannel(),
                Channel.SMS => new SMSChannel(),
                Channel.Teams => new TeamsChannel(),
                _ => throw new ArgumentException("Unsupported channel")
            };
        }
    }

    public enum Channel
    {
        EMail,
        SMS,
        Teams
    }

    public interface IChannel
    {
        void sent(string message);
    }

    public class EmailChannel : IChannel
    {
        public void sent(string message)
        {
            Console.WriteLine("Sending via Email message {0}",message);
        }
    }
    public class SMSChannel : IChannel
    {
        public void sent(string message)
        {
            Console.WriteLine("Sending via SMS message {0}", message);
        }
    }

    public class TeamsChannel : IChannel
    {
        public void sent(string message)
        {
            Console.WriteLine("Sending via Teams message {0}", message);
        }
    }



}