using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cellular automata neighborhood which includes neighbors in cardinal and ordinal directions (default: XZ)
/// </summary>
public class NeighborhoodMoore : Neighborhood
{
    #region Fields

    #endregion

    #region Constructors
    public NeighborhoodMoore()
    {
        this.name = "Moore Neighborhood";
        this.axis = Axes.XZ;
    }

    public NeighborhoodMoore(Axes ax)
    {
        if (ax == Axes.XY || ax == Axes.XZ || ax == Axes.YZ)
        {
            this.name = "Moore Neighborhood";
            this.axis = ax;
        }

        else
        {
            Debug.Log("Valid axes for Moore neighborhoods are: XY, XZ, or YZ only.");
            throw new ArgumentException("Valid axes for Moore neighborhoods are: XY, XZ, or YZ only.");
        }
    }
    #endregion

    #region Methods
    public override IEnumerable<Vector3> FetchNeighbors(Vector3 p)
    {
        // Cardinals
        if ((this.axis & Axes.X) != 0)
        {
            yield return new Vector3(p.x - 1f, p.y, p.z);
            yield return new Vector3(p.x + 1f, p.y, p.z);
        }

        if ((this.axis & Axes.Y) != 0)
        {
            yield return new Vector3(p.x, p.y - 1f, p.z);
            yield return new Vector3(p.x, p.y + 1f, p.z);
        }

        if ((this.axis & Axes.Z) != 0)
        {
            yield return new Vector3(p.x, p.y, p.z - 1f);
            yield return new Vector3(p.x, p.y, p.z + 1f);
        }

        // Ordinals
        if (this.axis == Axes.XY)
        {
            yield return new Vector3(p.x - 1f, p.y - 1f, p.z);
            yield return new Vector3(p.x - 1f, p.y + 1f, p.z);
            yield return new Vector3(p.x + 1f, p.y - 1f, p.z);
            yield return new Vector3(p.x + 1f, p.y + 1f, p.z);
            yield break;  // Will break early since XY precludes ZY/YZ
        }

        if (this.axis == Axes.XZ)
        {
            yield return new Vector3(p.x - 1f, p.y, p.z - 1f);
            yield return new Vector3(p.x - 1f, p.y, p.z + 1f);
            yield return new Vector3(p.x + 1f, p.y, p.z - 1f);
            yield return new Vector3(p.x + 1f, p.y, p.z + 1f);
            yield break;  // Will break early since XZ precludes YZ
        }

        if (this.axis == Axes.YZ)
        {
            yield return new Vector3(p.x, p.y - 1f, p.z - 1f);
            yield return new Vector3(p.x, p.y - 1f, p.z + 1f);
            yield return new Vector3(p.x, p.y + 1f, p.z - 1f);
            yield return new Vector3(p.x, p.y + 1f, p.z + 1f);
        }
    }
    #endregion
}
