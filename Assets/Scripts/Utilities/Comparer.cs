using System;

public static class Comparer
{
    public static bool Compare<T>(T[,,] arr1, T[,,] arr2) where T : IComparable
    {
        if (arr1.GetLength(0) != arr2.GetLength(0) ||
            arr1.GetLength(1) != arr2.GetLength(1) ||
            arr1.GetLength(2) != arr2.GetLength(2))
                return false;
            
        for (int i = 0; i < arr1.GetLength(0); i++)
            for (int j = 0; j < arr1.GetLength(1); j++)
                for (int k = 0; k < arr1.GetLength(2); k++)
                    if (arr1[i, j, k].CompareTo(arr2[i, j, k]) != 0)
                        return false;

        return true;
    }
}
