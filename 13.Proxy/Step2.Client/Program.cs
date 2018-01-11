using System;
using System.ServiceModel;

namespace Step2.Client
{
    // Client
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            //Для того, чтобы связаться с GumballMachine создаем абстрактный канал сообщений

            // Указание, где ожидать входящие сообщения.
            Uri address = new Uri("http://localhost:4000/IGumballMachineRemote");  // ADDRESS.   (A)

            // Указание, как обмениваться сообщениями.
            BasicHttpBinding binding = new BasicHttpBinding();         // BINDING.   (B)

            // Создание Конечной Точки.
            EndpointAddress endpoint = new EndpointAddress(address);

            // Создание фабрики каналов. (фабрики, которая будет строить канал)
            ChannelFactory<IGumballMachineRemote> factory = new ChannelFactory<IGumballMachineRemote>(binding, endpoint);  // CONTRACT.  (C)

            // Использование factory для создания канала (прокси).
            // Создается иллюзия, что мы работаем непосредственно с GumballMachine. Как будто в проекте Step2.Client есть класс GumballMachine
            IGumballMachineRemote channel = factory.CreateChannel(); // Proxy

            GumballMonitor gumballMonitor = new GumballMonitor(channel);
            gumballMonitor.Report();

            Console.ReadKey();
        }
    }
}
