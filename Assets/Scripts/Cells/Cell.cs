using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell
{
    #region Fields
    protected string name;
    protected GameObject gameObject;
    protected State state;
    protected State nextState;
    #endregion

    #region Properties
    public string Name => this.name;
    public GameObject GameObject => this.gameObject;
    public Vector3 Position => this.gameObject.transform.position;

    public State CurrentState => this.state;
    public bool Living => this.state == State.LIVING;
    public bool Dead => this.state == State.DEAD;
    public State NextState
    {
        get
        {
            return this.nextState;
        }

        set
        {
            this.nextState = value;
        }
    }
    #endregion

    #region Constructors / Destructors
    public Cell()
    {
    }
    #endregion

    #region Methods
    public void SetAlive()
    {
        this.state = State.LIVING;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void SetDead()
    {
        this.state = State.DEAD;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void Update()
    {
        if (this.nextState != this.state)
        {
            if (this.nextState == State.LIVING)
                this.SetAlive();
            else
                this.SetDead();
        }

        this.nextState = State.NONE;
    }
    #endregion

    #region Override Methods
    public override string ToString()
    {
        return $"[Cell|{this.state}] {name}";
    }
    #endregion
}
