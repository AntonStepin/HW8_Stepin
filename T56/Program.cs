// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int[,] FillArray(int RowLength, int ColLength, int FromDeviation, int UpToDeviation)
{
    if (FromDeviation > UpToDeviation)
    {
        Console.WriteLine($"Введено неверное значение диапазона массива: FromDeviation [{FromDeviation}] > UpToDeviation [{UpToDeviation}]");
        FromDeviation = UpToDeviation - 1;
        Console.WriteLine($"Изначальное значение FromDeviation [{FromDeviation}] = UpToDeviation [{UpToDeviation}] - 1");
    }

    int[,] result = new int[RowLength, ColLength];
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = new Random().Next(FromDeviation, UpToDeviation + 1);
        }
    }
    return result;
}

void Print2dArray(int[,] array)
{
    Console.Write("[ ]\t");
    const int StartIndex = 65;
    for (int i = StartIndex + 0; i < StartIndex + array.GetLength(1); i++)
    {
        Console.Write($"[{((char)i)}]\t");
    }
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write($"[{i}]\t");

        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void MinSumRow(int[,] array)
{
    int result = 0;
    int FirstRow = 0;
    string row = string.Empty;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int temp = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            temp = temp + array[i, j];
        }
        Console.WriteLine($"Сумма строки {i} = {temp}");
        if (i == 0)
        {
            result = temp;
            FirstRow = temp;
        }
        else if (result > temp)
        {
            result = temp;
            string buf = Convert.ToString(i);
            row = buf;
        }
        else if (result == temp)
        {
            string buf = Convert.ToString(i);
            row = row + " | " + buf;
        }
    }
    if (FirstRow == result)
    {
        row = "0" + row;
    }
    Console.WriteLine();
    if (row.Length > 1)
    {
        Console.WriteLine($"Строки c минимальной суммой: {row}");
    }
    else
    {
        Console.WriteLine($"Строка с минимальной суммой: {row}");
    }
}

int RowLength = 6;
int ColLength = 3;
int FromDeviation = 1;
int UpToDeviation = 10;
int[,] MyArray = FillArray(
    RowLength,
    ColLength,
    FromDeviation,
    UpToDeviation);
Console.WriteLine("Ваш массив:");
Console.WriteLine();
Print2dArray(MyArray);
MinSumRow(MyArray);

