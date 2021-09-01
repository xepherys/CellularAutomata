using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for rules.
/// </summary>
public abstract class Rule
{
    #region Fields
    protected string name;
    protected Neighborhood neighborhood;
    protected bool wrap;
    #endregion

    #region Properties
    public string Name => this.name;
    public Neighborhood Neighborhood => this.neighborhood;
    public bool Wrap => wrap;
    #endregion

    #region Constructors / Destructors
    public Rule()
    {
        this.wrap = false;
    }
    #endregion

    #region Methods
    public abstract void Tick(Cell c);

    public void GenerateCells(int size)
    {
        int x = 1;
        int y = 1;
        int z = 1;

        if ((this.neighborhood.Axis & Axes.X) != 0)
            x = size;
        if ((this.neighborhood.Axis & Axes.Y) != 0)
            y = size;
        if ((this.neighborhood.Axis & Axes.Z) != 0)
            z = size;

        for (int xx = 0; xx < x; xx++)
            for (int yy = 0; yy < y; yy++)
                for (int zz = 0; zz < z; zz++)
                {
                    Cell c = new CellCube(new Vector3(xx, yy, zz));
                    c.SetDead();
                    Automata.AddCell(c);
                }
    }
    #endregion

    #region Override Methods
    public override string ToString()
    {
        return $"[Rule] {name}";
    }
    #endregion
}
