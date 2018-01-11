using System;
using System.ServiceModel;

namespace Step2
{
    // Server
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            // Указание адреса, где ожидать входящие сообщения.
            Uri address = new Uri("http://localhost:4000/IGumballMachineRemote"); // ADDRESS.    (A)

            // Указание привязки, как обмениваться сообщениями.
            BasicHttpBinding binding = new BasicHttpBinding();        // BINDING.    (B)

            // Указание контракта.
            Type contract = typeof(IGumballMachineRemote);            // CONTRACT.   (C) 

            // Создание провайдера Хостинга (Host) с указанием Сервиса (GumballMachine).
            ServiceHost host = new ServiceHost(typeof(GumballMachine));

            // Добавление "Конечной Точки".
            host.AddServiceEndpoint(contract, binding, address);

            // Начало ожидания прихода сообщений.
            // (Открываем двери в Веб сеть (слушаем))
            host.Open();

            Console.WriteLine("Application is waiting for message");
            Console.ReadKey();


            // Завершение ожидания прихода сообщений.
            host.Close();

        }
    }
}
