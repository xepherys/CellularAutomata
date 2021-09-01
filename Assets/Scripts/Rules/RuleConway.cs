using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Conway : Rule
{
    #region Constructors / Deconstructors
    public Conway(bool wrap = false)
    {
        this.name = "Conway's";
        this.neighborhood = new NeighborhoodMoore();
        this.wrap = wrap;
    }
    #endregion

    #region Methods
    public override void Tick(Cell c)
    {
        List<Cell> test = new List<Cell>();
        int living = 0;
        int dead = 0;

        foreach (Vector3 v in this.neighborhood.FetchNeighbors(c.Position))
        {
            Vector3 build = v;

            if ((this.neighborhood.Axis | Axes.X) != 0)
            {
                if (v.x < 0)
                {
                    if (this.wrap)
                        build.x = (float)Automata.FieldSize + v.x;
                    else
                        continue;
                }

                if (v.x > Automata.FieldSize - 1)
                {
                    if (this.wrap)
                    {
                        build.x = (float)Automata.FieldSize - v.x;
                        //Debug.Log($"Was {v.x}, setting to {build.x}.");
                    }
                    else
                        continue;
                }
            }

            if ((this.neighborhood.Axis | Axes.Y) != 0)
            {
                if (v.y < 0)
                {
                    if (this.wrap)
                        build.y = (float)Automata.FieldSize + v.y;
                    else
                        continue;
                }

                if (v.y > Automata.FieldSize - 1)
                {
                    if (this.wrap)
                    {
                        build.y = (float)Automata.FieldSize - v.y;
                        //Debug.Log($"Was {v.y}, setting to {build.y}.");
                    }
                    else
                        continue;
                }
            }

            if ((this.neighborhood.Axis | Axes.Z) != 0)
            {
                if (v.z < 0)
                {
                    if (this.wrap)
                    {
                        build.z = (float)Automata.FieldSize + v.z;
                        //Debug.Log($"Was {v.z}, setting to {build.z}.");
                    }
                    else
                        continue;
                }

                if (v.z > Automata.FieldSize - 1)
                {
                    if (this.wrap)
                        build.z = (float)Automata.FieldSize - v.z;
                    else
                        continue;
                }
            }

            try
            {
                test.Add(Automata.Cells.Single(s => s.Position == build));
            }

            catch
            {
                Debug.Log($"Issue in Conway's - looking for cell at {build}.");
            }
        }

        foreach (Cell cc in test)
        {
            if (cc.Living)
                living++;
            else if (cc.Dead)
                dead++;
            else
            {
                Debug.Log("Invalid state for cell in Conway's Rules.");
                throw new ArgumentNullException("Invalid state for cell in Conway's Rules.");
            }
        }

        switch (c.CurrentState)
        {
            case State.LIVING:
                if (living < 2 || living > 3)
                    c.NextState = State.DEAD;
                else
                    c.NextState = State.LIVING;
                break;
            case State.DEAD:
                if (living == 3)
                    c.NextState = State.LIVING;
                else
                    c.NextState = State.DEAD;
                break;
        }
    }
    #endregion
}
