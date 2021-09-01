using System;

public static class Stringify
{
    public static string Bool3(bool[,,] arr)
    {
        string _ret = String.Empty;

        for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                for (int k = 0; k < arr.GetLength(2); k++)
                    _ret += (arr[i, j, k]) ? "1" : "0";

        return _ret;
    }
}
