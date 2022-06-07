// Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
// Набор данных
// Частотный массив
// { 1, 9, 9, 0, 2, 8, 0, 9 }
// 0 встречается 2 раза
// 1 встречается 1 раз
// 2 встречается 1 раз
// 8 встречается 1 раз
// 9 встречается 3 раза

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

void FrequencyDictionary(int[,] array)
{
    int Index = 0;
    int[] storage = new int[array.GetLength(0) * array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            storage[Index] = array[i, j];
            Index++;
        }
    }
    Console.WriteLine("Частотный массив:");
    Console.Write("[");
    for (int i = 0; i < storage.Length; i++)
    {
        for (int j = i + 1; j < storage.Length; j++)
        {
            if (storage[i] > storage[j])
            {
                int temp = storage[i];
                storage[i] = storage[j];
                storage[j] = temp;
            }
        }
        Console.Write($"{storage[i]}");
        if (i != storage.Length - 1)
        {
            Console.Write(", ");
        }
    }
    Console.Write("]\n");
    Console.WriteLine();
    int count = 0;
    for (int i = 0; i < storage.Length; i+=count)
    {
        count = 0;
        for (int j = 0; j < storage.Length; j++)
        {
            if (storage[i] == storage[j])
            {
                count++;
            }
        }
        if (count % 10 == 2 || count % 10 == 3 || count % 10 == 4)
        {
            Console.WriteLine($"{storage[i]} встречается {count} раза");
        }
        else
        {
            Console.WriteLine($"{storage[i]} встречается {count} раз");
        }

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
FrequencyDictionary(MyArray);

