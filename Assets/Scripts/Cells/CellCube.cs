using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCube : Cell3D
{
    public CellCube(Vector3 position)
    {
        this.name = $"Cell {position}";
        this.gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.gameObject.transform.localPosition = position;
        this.gameObject.name = $"Cell {position}";
        this.state = State.NONE;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
    }
}
