using MyLib;

MainCode();
static void MainCode()
{
    Console.Clear();
    Console.WriteLine("Выберите задание");
    Console.WriteLine("1 - Задание №1 Сортировка матрицы");
    Console.WriteLine("2 - Задание №2 Событие");

    while (true)
    {
        switch (char.ToLower(Console.ReadKey(true).KeyChar))
        {
            case '1':
                task1();
                break;
            case '2':
                task2();
                break;
            default:
                Console.WriteLine("Этого пункта нет в списке");
                break;
        }
    }
}

static void task2()
{
    Console.Clear();
    Console.WriteLine("Задание 2");

    Countdown[] countdowns = { 
        new Countdown("Охота и рыбалка"),
        new Countdown("Карусель"), 
        new Countdown("Новости 24") 
    };
    Subscriber[] subscribers = {
        new Subscriber("Виктор Слотин", new string[]{ "Охота и рыбалка", "Новости 24" }),
        new Subscriber("Анастасия Петрова", new string[]{ "Охота и рыбалка", "Карусель" }),
        new Subscriber("Александр Калиничев", new string[]{ "Карусель", "Новости 24" })
    };

    Countdown ChannelWithNewContent = countdowns[0];

    foreach (Subscriber subs in subscribers)
    {
        subs.NewNotification(ChannelWithNewContent);
    }

    Console.WriteLine("Ожидание...");
    string mess = "На канале " + ChannelWithNewContent.channelName + " вышло новое видео!";
    ChannelWithNewContent.Mailing(1000, mess);
    Console.WriteLine();
    Console.WriteLine("0 - Вернуться в меню");
    while (char.ToLower(Console.ReadKey(true).KeyChar) != '0')
    {
    }
    MainCode();
}

static void task1()
{
    Console.Clear();
    Console.WriteLine("Задание 1");

    var arr = new[,]
    {
    { 1, 1, 4, 9 },
    { 10, 4, 2, 0 },
    { 8, 5, 80, -71 },
    { 8, 5, 8, -3 }
    };
    Console.WriteLine("\nДемонстрационная матрица: ");
    arr.Print();

    Console.WriteLine();
    Console.WriteLine("1 - Сортировка в порядке возрастания сумм элементов строк матрицы");
    Console.WriteLine("2 - Сортировка в порядке убывания сумм элементов строк матрицы");
    Console.WriteLine("3 - Сортировка по возрастанию максимального элемента в строке матрицы");
    Console.WriteLine("4 - Сортировка по убыванию максимального элемента в строке матрицы");
    Console.WriteLine("5 - Сортировка в порядке возрастания минимального элемента в строке матрицы");
    Console.WriteLine("6 - Сортировка в порядке убывания минимального элемента в строке матрицы");
    Console.WriteLine("0 - Вернуться в меню");

    var res = arr;
    while (true)
    {
        switch (char.ToLower(Console.ReadKey(true).KeyChar))
        {
            case '1':
                res = arr.SortRows((x, y) => x > y, (x, y) => x + y);
                break;
            case '2':
                res = arr.SortRows((x, y) => x < y, (x, y) => x + y);
                break;
            case '3':
                res = arr.SortRows((x, y) => x > y, (x, y) => x > y ? x : y);
                break;
            case '4':
                res = arr.SortRows((x, y) => x < y, (x, y) => x > y ? x : y);
                break;
            case '5':
                res = arr.SortRows((x, y) => x > y, (x, y) => x < y ? x : y);
                break;
            case '6':
                res = arr.SortRows((x, y) => x < y, (x, y) => x < y ? x : y);
                break;
            case '0':
                MainCode();
                break;
            default:
                Console.WriteLine("Этого пункта нет в списке");
                break;
        }
        Console.WriteLine("\nМассив после сортировки: ");
        res.Print();
        Console.WriteLine();
    }
}


