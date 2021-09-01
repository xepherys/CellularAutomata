using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Automata : MonoBehaviour
{
    #region Fields
    public int fieldSize = 10;
    public static int FieldSize;
    private static bool[,,] map;
    private static bool[,,] newMap;

    private static int x;
    private static int y;
    private static int z;

    public Rules Rules;
    private static Rule Rule;

    public bool wrap;

    private static List<Cell> cells;
    private static GameObject cellHolder;

    public int RandomSeed;
    private static System.Random rnd;

    public int ticks = 0;
    [Range(1.0f, 100.0f)]
    public float speed = 2.0f;
    #endregion

    #region Properties
    public static List<Cell> Cells => Automata.cells;
    public static System.Random Random => Automata.rnd;
    #endregion

    #region Monobehaviour Methods
    private void Awake()
    {
        rnd = new System.Random(this.RandomSeed);

        cellHolder = new GameObject("Cells");
        cells = new List<Cell>();

        Automata.FieldSize = this.fieldSize;

        switch (this.Rules)
        {
            case Rules.Conway:
                Automata.Rule = new Conway(wrap);
                break;
        }

        x = 1;
        y = 1;
        z = 1;

        if ((Automata.Rule.Neighborhood.Axis & Axes.X) != 0)
            x = Automata.FieldSize;

        if ((Automata.Rule.Neighborhood.Axis & Axes.Y) != 0)
            y = Automata.FieldSize;

        if ((Automata.Rule.Neighborhood.Axis & Axes.Z) != 0)
            z = Automata.FieldSize;

        map = new bool[x, y, z];
        newMap = new bool[x, y, z];

        cellHolder.transform.localPosition = Vector3.zero;
        ConstructGameArea();
    }

    private void Start()
    {
        SetRandomCellsLiving();

        StartCoroutine(Tick());
    }

    private void Update()
    {
        
    }
    #endregion

    #region Methods
    private void ConstructGameArea()
    {
        Rule.GenerateCells(FieldSize);
    }

    public static void AddCell(Cell c)
    {
        cells.Add(c);
        c.GameObject.transform.parent = cellHolder.transform;
    }

    public void SetRandomCellsLiving()
    {
        int livingCells = 0;

        while (livingCells < this.fieldSize)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (livingCells >= this.fieldSize)
                    break;

                if (rnd.Next(0, 100) > 80)
                {
                    if (cells[i].Dead)
                    {
                        cells[i].SetAlive();
                        map[(int)cells[i].Position.x, (int)cells[i].Position.y, (int)cells[i].Position.z] = true;
                        livingCells++;
                    }
                }
            }
        }
    }

    private bool NewMapSameAsOld()
    {
        if (Comparer.Compare<bool>(map, newMap))
            return true;

        return false;
    }

    public IEnumerator Tick()
    {
        while (ticks < 1000)
        {
            newMap = new bool[x, y, z];

            foreach (Cell c in cells)
                Rule.Tick(c);

            foreach (Cell c in cells)
                c.Update();

            foreach (Cell c in cells)
                newMap[(int)c.Position.x, (int)c.Position.y, (int)c.Position.z] = c.Living;

            if (NewMapSameAsOld())
            {
                Debug.Log($"Repeat at turn {ticks}.");
                break;
            }

            map = newMap;

            ticks++;

            yield return new WaitForSeconds(1f / speed);
        }
    }
    #endregion
}
