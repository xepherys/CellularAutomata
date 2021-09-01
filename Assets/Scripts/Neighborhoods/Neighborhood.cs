using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for neighborhood types used in rules.
/// </summary>
public abstract class Neighborhood
{
    #region Fields
    protected string name;
    protected Axes axis;
    #endregion

    #region Properties
    public string Name => this.name;
    public Axes Axis => this.axis;
    #endregion

    #region Constructors / Desctructors
    public Neighborhood() { }
    #endregion

    #region Methods
    public abstract IEnumerable<Vector3> FetchNeighbors(Vector3 v);
    #endregion

    #region Override Methods
    public override string ToString()
    {
        return $"[Neighborhood] {name}";
    }
    #endregion
}
