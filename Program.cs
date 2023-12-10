class IceCream
{
    public string name { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }

    public IceCream(string name, int price, int quantity)
    {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }
}
class Shop
{
    public Shop()
    {
        LoadDataFromFile();

    }
    private List<IceCream> ic = new List<IceCream>();
    private string filePath = "..\\..\\..\\..\\Smth.txt";

    public void AddItem(string name, int price, int quantity)
    {
        var tele = ic.Find(v => v.name == name);
        if (tele != null)
        {
            tele.quantity += quantity;
        }
        else
        {
            var item = new IceCream(name, price, quantity);
            ic.Add(item);
        }
        SaveDataToFile();
    }

    public void DeleteItem(string name)
    {
        var tele = ic.Find(v => v.name == name);
        if (tele != null)
        {
            ic.Remove(tele);
            Console.WriteLine($"{name} Удален");
            SaveDataToFile();
        }
        else
        {
            Console.WriteLine($"{name} Не найден");
        }
    }
    public void Display()
    {
        Console.WriteLine("Телевзоры в наличии:");
        foreach (var item in ic.OrderBy(v => v.name))
        {
            Console.WriteLine($"{item.name}: {item.quantity} шт. Цена за шт: {item.price} руб");
        }
    }
    private void LoadDataFromFile()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        int quantity = int.Parse(parts[1]);
                        int price = int.Parse(parts[1]);
                        ic.Add(new IceCream(name, quantity, price));
                    }
                }
            }
        }

    }
    private void SaveDataToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var tele in ic)
            {
                writer.WriteLine($"{tele.name},{tele.quantity},{tele.price}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Shop tele = new Shop();

        while (true)
        {
            Console.WriteLine("1. Добавить");
            Console.WriteLine("2. Есть в наличии");
            Console.WriteLine("3. Выход");
            Console.WriteLine("4. Удалить");
            Console.Write("Выберите: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите наименование телевизора: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите цену: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Введите количество: ");
                    int price = int.Parse(Console.ReadLine());
                    tele.AddItem(name, quantity, price);
                    break;
                case 2:
                    tele.Display();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                case 4:
                    Console.Write("Введите название товара для удаления: ");
                    string removeName = Console.ReadLine();
                    tele.DeleteItem(removeName);
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
    }
}