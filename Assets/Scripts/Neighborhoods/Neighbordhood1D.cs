using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cellular automata neighborhood which includes neighbors in a linear direction (default: X)
/// </summary>
public class Neighborhood1D : Neighborhood
{
    #region Fields

    #endregion

    #region Constructors
    public Neighborhood1D()
    {
        this.name = "1D Neighborhood";
        this.axis = Axes.X;
    }

    public Neighborhood1D(Axes ax)
    {
        if (ax == Axes.X || ax == Axes.Y || ax == Axes.Z)
        {
            this.name = "1D Neighborhood";
            this.axis = ax;
        }

        else
        {
            Debug.Log("Valid axes for 1D neighborhoods are: X, Y, or Z only.");
            throw new ArgumentException("Valid axes for 1D neighborhoods are: X, Y, or Z only.");
        }
    }
    #endregion

    #region Methods
    public override IEnumerable<Vector3> FetchNeighbors(Vector3 p)
    {
        // Linear
        if ((this.axis & Axes.X) != 0)
        {
            yield return new Vector3(p.x - 1f, p.y, p.z);
            yield return new Vector3(p.x + 1f, p.y, p.z);
            yield break;  // Will break early since X precludes Y/Z
        }

        if ((this.axis & Axes.Y) != 0)
        {
            yield return new Vector3(p.x, p.y - 1f, p.z);
            yield return new Vector3(p.x, p.y + 1f, p.z);
            yield break;  // Will break early since Y precludes Z
        }

        if ((this.axis & Axes.Z) != 0)
        {
            yield return new Vector3(p.x, p.y, p.z - 1f);
            yield return new Vector3(p.x, p.y, p.z + 1f);
        }
    }
    #endregion
}
