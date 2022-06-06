// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

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
        if (array.GetLength(0) > 0 && array.GetLength(1) > 0) Console.Write($"[{((char)i)}]\t");
    }
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (array.GetLength(0) > 0 && array.GetLength(1) > 0) Console.Write("[" + i + "]\t");

        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MultiplicationOfMatrix(int[,] ArrayA, int[,] ArrayB)
{
    int[,] resultC = new int[ArrayA.GetLength(0), ArrayB.GetLength(1)];
    if (ArrayA.GetLength(1) != ArrayB.GetLength(0))
    {
        Console.WriteLine($"Массивы не согласованны");
        Console.WriteLine($"Кол-во столбцов первого массива [{ArrayA.GetLength(1)}] не равно количеству строк второго массива [{ArrayB.GetLength(0)}]");
        resultC = new int[0, 0];
    }
    else if (ArrayA.GetLength(0) == 0 || ArrayA.GetLength(1) == 0 || ArrayB.GetLength(0) == 0 || ArrayB.GetLength(1) == 0)
    {
        resultC = new int[0, 0];
    }
    else
    {
        for (int AC0 = 0; AC0 < ArrayA.GetLength(0); AC0++)
        {
            for (int CB1 = 0; CB1 < ArrayB.GetLength(1); CB1++)
            {
                int temp = 0;
                for (int A1B0 = 0; A1B0 < ArrayA.GetLength(1); A1B0++)
                {
                    temp = temp + ArrayA[AC0, A1B0] * ArrayB[A1B0, CB1];
                }
                resultC[AC0, CB1] = temp;
            }
        }
    }
    return resultC;
}


int RowLengthA = 2;
int ColLengthA = 3;
int FromDeviation = 1;
int UpToDeviation = 10;
int[,] MyArrayA = FillArray(
    RowLengthA,
    ColLengthA,
    FromDeviation,
    UpToDeviation);
Console.WriteLine("Ваш массив A:");
Console.WriteLine();
Print2dArray(MyArrayA);
int RowLengthB = 3;
int ColLengthB = 3;
int[,] MyArrayB = FillArray(
    RowLengthB,
    ColLengthB,
    FromDeviation,
    UpToDeviation);
Console.WriteLine("Ваш массив B:");
Console.WriteLine();
Print2dArray(MyArrayB);

Console.WriteLine("Произведение матриц MyArrayA и MyArrayB:");
Console.WriteLine();
int[,] result = MultiplicationOfMatrix(MyArrayA, MyArrayB);
Print2dArray(result);