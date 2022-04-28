namespace MyLib
{
    public static class ArraySorter
    {
        public static int[,] SortRows(this int[,] array,
            Func<int, int, bool> orderFunc,
            Func<int, int, int> aggregationFunc)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            var aggregations = new Tuple<int, int>[rows];

            // Для каждой строки массива определяем агрегированное значение.
            for (int i = 0; i < rows; i++)
            {
                var sortValue = columns > 1 ? aggregationFunc(array[i, 0], array[i, 1]) : array[i, 0];
                for (int j = 2; j < columns; j++) 
                {
                    sortValue = aggregationFunc(sortValue, array[i, j]);
                }
                aggregations[i] = new Tuple<int, int>(i, sortValue);
            }

            // Сортировка пузырьком.
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < rows - 1 - i; j++)
                    if (orderFunc(aggregations[j].Item2, aggregations[j + 1].Item2))
                        (aggregations[j], aggregations[j + 1]) = (aggregations[j + 1], aggregations[j]);

            // Создаем новый массив и заполяем его строками в правильном порядке.
            int[,] result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    result[i, j] = array[aggregations[i].Item1, j];

            return result;
        }

        public static void Print(this int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + "\t ");

                Console.WriteLine();
            }
        }
    }
}