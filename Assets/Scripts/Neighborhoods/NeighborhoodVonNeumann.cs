using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cellular automata neighborhood which includes neighbors in cardinal directions (default: XZ)
/// </summary>
public class NeighborhoodVonNeumann : Neighborhood
{
    #region Fields

    #endregion

    #region Constructors
    public NeighborhoodVonNeumann()
    {
        this.name = "von Neumann Neighborhood";
        this.axis = Axes.XZ;
    }

    public NeighborhoodVonNeumann(Axes ax)
    {
        if (ax == Axes.XY || ax == Axes.XZ || ax == Axes.YZ)
        {
            this.name = "von Neumann Neighborhood";
            this.axis = ax;
        }

        else
        {
            Debug.Log("Valid axes for von Neumann neighborhoods are: XY, XZ, or YZ only.");
            throw new ArgumentException("Valid axes for von Neumann neighborhoods are: XY, XZ, or YZ only.");
        }
    }
    #endregion

    #region Methods
    public override IEnumerable<Vector3> FetchNeighbors(Vector3 p)
    {
        // Cardinals
        // No early `yield break` statements since no earlier option necessarily precludes others.
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
    }
    #endregion
}
