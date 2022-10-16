// Задача со звёздочкой 2: Напишите программу, которая заполнит спирально массив 4 на 4.

Console.Clear();
Console.WriteLine("Программа заполняет спирально массив");

int size = AskForInput("строк и столбцов");
int[,] filledArray = new int[size, size];
int count = 11;
int maxRow = size;
int minRow = 0;
int maxColumn = size;
int minColumn = 0;
int r = 0;
int c = 0;

Console.Write("\nCгенерированный массив: \n");
FillArray();
PrintArray(filledArray);

//////////////////////////// функции ////////////////////////////////////////////////////

void FillArray()
{
    if(count - size * size >= 11) return;
    if(r == minRow && c == minColumn)
    {
        while(c < maxColumn)
        {
            FillArrayElement();
            c++;
        }
        c--;
        maxColumn--; 
    }
    else if(r == minRow && c == maxColumn)
    {
        r++;
        while(r < maxRow)
        {
            FillArrayElement();
            r++;
        }
        r--;
        maxRow--;
    }
    else if(r == maxRow && c == maxColumn)
    {
        c--;
        while(c >= minColumn)
        {
            FillArrayElement();
            c--;
        }
        c++;
    }
    else if(r == maxRow && c == minColumn)
    {
        r--;
        minColumn++;
        while(r > minRow)
        {
            FillArrayElement();
            r--;
        }
        r++;
        minRow++;
        c++;
    }
    FillArray();
}

int AskForInput(string str)
{
    while (true)
    {
        Console.Write($"\nНапишите - из скольки {str} должен состоять массив? :");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number > 0) 
            {
                return number;
                break;
            }
            else Console.WriteLine($"Некорректно указано количество {str} массива!\n");
        }
        else Console.WriteLine($"Некорректно указано количество {str} массива!\n");
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + " ");
        }
    Console.WriteLine();
    }   
}

void FillArrayElement()
{
    filledArray[r,c] = count;
    count++;
}
