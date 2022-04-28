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

    Countdown channel1 = new Countdown("Охота и рыбалка");
    Countdown channel2 = new Countdown("Карусель");
    Countdown channel3 = new Countdown("Новости 24");

    var subs1 = new Subscriber(timer, "Виктор Слотин");
    var subs2 = new Subscriber(timer, "Анастасия Петрова");
    var subs3 = new Subscriber(timer, "Александр Калиничев");

    Console.WriteLine("Ожидание...");
    string mess = "На канале " + channel1.channelName + " вышло новое видео!";
    channel1.Mailing(1000, mess);
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


