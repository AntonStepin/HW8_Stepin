// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

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

int[,] RowMinToMax(int[,] array)
{ 
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int min = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            min = array[i, j];
            for (int d = j + 1; d < array.GetLength(1); d++)
            {
                if (array[i, j] > array[i, d])
                {
                    int temp = array[i,j];
                    array[i,j] = array[i,d];
                    array[i,d] = temp;
                }
            }
        }
    }
return array;
}

int RowLength = 2;
int ColLength = 4;
int FromDeviation = 1;
int UpToDeviation = 10;

int[,] MyArray = FillArray(
    RowLength, 
    ColLength, 
    FromDeviation, 
    UpToDeviation);
    
Print2dArray(MyArray);
RowMinToMax(MyArray);
Print2dArray(MyArray);
