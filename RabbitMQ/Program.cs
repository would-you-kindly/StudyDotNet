using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Events;
using System.Threading;

namespace RabbitMQ
{
    class Program
    {
        static string exchangeName = "test";
        static string queueName = "test";
        static string routingKey = "test";

        static IConnection conn;
        static IModel model;

        static void Main(string[] args)
        {
            SendMessage("message 123");
            string message = ReceiveIndividualMessage();
            Console.WriteLine(message);

            SendMessage("message 1");
            SendMessage("message 2");
            SendMessage("message 3");

            Thread thread = new Thread(new ThreadStart(RabbitListener));
            thread.Start();

            Console.ReadKey(true);

            if (thread != null)
            {
                thread.Abort();
            }
            if (model != null)
            {
                model.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        private static IConnection GetRabbitConnection()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                HostName = "localhost"
            };
            IConnection conn = factory.CreateConnection();

            return conn;
        }

        private static IModel GetRabbitChannel(string exchangeName, string queueName, string routingKey)
        {
            conn = GetRabbitConnection();
            IModel model = conn.CreateModel();
            model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            model.QueueDeclare(queueName, false, false, false, null);
            model.QueueBind(queueName, exchangeName, routingKey, null);
            return model;
        }

        private static void SendMessage(string message = "Hello, world!")
        {
            model = GetRabbitChannel(exchangeName, queueName, routingKey);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);
            model.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
        }

        private static string ReceiveIndividualMessage()
        {
            string originalMessage = "";
            model = GetRabbitChannel(exchangeName, queueName, routingKey);
            BasicGetResult result = model.BasicGet(queueName, false);
            if (result == null)
            {
                // В настоящее время нет доступных сообщений.
            }
            else
            {
                byte[] body = result.Body;
                originalMessage = Encoding.UTF8.GetString(body);
            }

            return originalMessage;
        }

        private static void RabbitListener()
        {
            IModel model = GetRabbitChannel(exchangeName, queueName, routingKey);
            var subscription = new Subscription(model, queueName, false);
            while (true)
            {
                BasicDeliverEventArgs basicDeliveryEventArgs = subscription.Next();
                string messageContent = Encoding.UTF8.GetString(basicDeliveryEventArgs.Body);
                //messagesTextBox.Invoke((MethodInvoker)delegate { messagesTextBox.Text += messageContent + "\r\n"; });
                subscription.Ack(basicDeliveryEventArgs);
            }
        }
    }
}
