using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            global::System.Object p = Application.Run(new Form1());
        }
    }

    public class ThreadClass
    {
        public String fileName;
        NetworkStream ns;
        public int fileCount;
        Socket socket;
        UTF8Encoding utf8;
        TcpListener listener;
        public ThreadClass()
        {
            this.fileName = "C:\\Users\\Илья\\source\\repos\\Lab7\\Computers.txt";
            this.fileCount = 0;
            //Создание объекта класса TcpListener 
            this.listener = null;
            //Создание объекта класса Socket 
            this.socket = null;
            //Создание объекта класса NetworkStream 
            this.ns = null;
            //Создание объекта класса кодировки ASCIIEncoding 
            this.utf8 = null;
        }

        Form1 form = null;

        public Thread Start(NetworkStream ns, String fileName, int fileCount, Form1 form)
        {
            this.ns = ns;
            utf8 = new UTF8Encoding();
            this.fileName = fileName;
            this.fileCount = fileCount;
            this.form = form;
            //Создание нового экземпляра класса Thread
            Thread thread = new Thread(new ThreadStart(ThreadOperations));
            //Запуск потока
            thread.Start();
            return thread;
        }

        public async void ThreadOperations()
        {
            try
            {
                while (true)
                {
                    byte[] received = new byte[256];
                    int bytesRead = await ns.ReadAsync(received, 0, received.Length);
                    String s1 = utf8.GetString(received, 0, bytesRead);
                    int i = s1.IndexOf("|", 0);
                    String cmd = s1.Substring(0, i);

                    if (cmd.CompareTo("view") == 0)
                    {
                        // Создаем переменную типа byte[] для отправки ответа клиенту 
                        byte[] sent = new byte[256];
                        //Создаем объект класса FileStream для последующего чтения информации из файла
                        FileStream fstr = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fstr);
                        //Запись в переменную sent содержания прочитанного файла 
                        sent = utf8.GetBytes(sr.ReadToEnd());
                        sr.Close();
                        fstr.Close();
                        //Отправка информации клиенту 
                        ns.WriteAsync(sent, 0, sent.Length);
                    }
                    if (cmd.CompareTo("add") == 0)
                    {
                        // Получите данные от клиента, например, имя, количество и цену
                        string[] addParts = s1.Split('|');


                        if (addParts.Length == 4)
                        {
                            string name = addParts[1];
                            int quantity = int.Parse(addParts[2]);
                            double price = double.Parse(addParts[3]);

                            // Добавление компьютера в список
                            AddComputer(name, quantity, price);

                            // Сохраните данные в файл
                            string confirmationMessage = "Added: " + name;
                            byte[] sent = utf8.GetBytes(confirmationMessage);
                            await ns.WriteAsync(sent, 0, sent.Length);
                        }

                    }
                    if (cmd.CompareTo("delete") == 0)
                    {
                        // Получите данные от клиента, например, имя, количество и цену
                        string[] addParts = s1.Split(' ');

                        if (addParts.Length == 2)
                        {
                            string name = addParts[1];


                            DeleteComputer(name);
                            string confirmationMessage = "Deleted: " + name;
                            byte[] sent = utf8.GetBytes(confirmationMessage);
                        }
                    }
                    if (cmd.CompareTo("edit") == 0)
                    {
                        // Получите данные от клиента, например, имя, количество и цену
                        string[] addParts = s1.Split(' ');


                        if (addParts.Length == 4)
                        {
                            string name = addParts[1];
                            int quantity = int.Parse(addParts[2]);
                            double price = double.Parse(addParts[3]);

                            // Добавьте овощ в список
                            EditComputer(name, quantity, price);

                            // Сохраните данные в файл
                            string confirmationMessage = "Changed: " + name;
                            byte[] sent = utf8.GetBytes(confirmationMessage);
                            await ns.WriteAsync(sent, 0, sent.Length);


                            // Отправьте подтверждение клиенту
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private List<Computer> vegetables = new List<Computer>();
        private string filePath = "C:\\Users\\denis\\source\\repos\\Lab7\\vegetables.txt";

        public void AddComputer(string name, int quantity, double price)
        {
            List<Computer> existingComputers = new List<Computer>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        string existingName = parts[0];
                        int existingQuantity = int.Parse(parts[1]);
                        double existingPrice = double.Parse(parts[2]);
                        existingComputers.Add(new Computer(existingName, existingQuantity, existingPrice));
                    }
                }
            }
            
            var existingComputer = existingComputers.Find(v => v.name == name);

            if (existingComputer != null)
            {
                existingComputer.quantity += quantity;
            }
            else
            {
                var newComputer = new Computer(name, quantity, price);
                existingComputers.Add(newComputer);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var computer in existingComputers)
                {
                    writer.WriteLine($"{computer.name};{computer.quantity};{computer.price}");
                }
            }
        }

        public void DeleteComputer(string name)
        {
            List<Computer> existingComputer = new List<Computer>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        string existingName = parts[0];
                        int existingQuantity = int.Parse(parts[1]);
                        double existingPrice = double.Parse(parts[2]);
                        existingComputer.Add(new Computer(existingName, existingQuantity, existingPrice));
                    }
                }
            }

            var computerToRemove = existingComputer.Find(v => v.name == name);

            if (computerToRemove != null)
            {
                existingComputer.Remove(computerToRemove);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var vegetable in existingComputer)
                {
                    writer.WriteLine($"{vegetable.name}; {vegetable.quantity} ;{vegetable.pricePerUnit}");
                }
            }
        }
        public void EditComputer(string name, int quantity, double pricePerUnit)
        {
            List<Computer> existingComputer = new List<Computer>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        string existingName = parts[0];
                        int existingQuantity = int.Parse(parts[1]);
                        double existingPrice = double.Parse(parts[2]);
                        existingComputer.Add(new Computer(existingName, existingQuantity, existingPrice));
                    }
                }
            }

            var existingVegetable = existingComputer.Find(v => v.name == name);

            if (existingVegetable != null)
            {
                existingVegetable.quantity = quantity;
                existingVegetable.pricePerUnit = pricePerUnit;
            }
            else
            {
                var newVegetable = new Computer(name, quantity, pricePerUnit);
                existingComputer.Add(newVegetable);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var computer in existingComputer)
                {
                    writer.WriteLine($"{computer.name};{computer.quantity};{computer.Price}");
                }
            }
        }
    }

    class Computer
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public Computer(string name, int quantity, double price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }

}