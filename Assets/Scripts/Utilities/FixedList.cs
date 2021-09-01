using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedSizeList<T>
{
    #region Fields
    private List<T> list;
    private int size;
    #endregion

    #region Properties
    public List<T> List => this.list;
    public int Size => this.size;
    #endregion

    #region Constructors / Destructors
    public FixedSizeList()
    {
        this.size = 100;
        this.list = new List<T>(this.size);
    }

    public FixedSizeList(int size)
    {
        this.size = size;
        this.list = new List<T>(this.size);
    }
    #endregion

    #region Methods
    public void Add(T t)
    {
        if (this.list.Count < this.size)
            this.list.Add(t);
        else
        {
            this.list.RemoveAt(0);
            this.list.Add(t);
        }
    }

    /*
    public bool Pattern(int maxLookback = 10)
    {
        for (int i = maxLookback; i > 3; i--)
            for (int j = 0; j <= 3; j++)
            {

            }
    }
    */
    #endregion
}
