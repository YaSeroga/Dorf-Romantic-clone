using System;
using UnityEngine;
using Zenject;

[System.Serializable]
public abstract class Hexagon : MonoBehaviour
{

    protected HexagonMap Map;
    
    public static float Length = 1; // Outer circle radius
    public static float Width = 0.866f; // Inner circle radius


    protected int RotationCount;

    protected int RightIndex;
    protected int RightUpIndex;
    protected int RightDownIndex;
    protected int LeftIndex;
    protected int LeftDownIndex;
    protected int LeftUpIndex;

    public Hexagon[] Neighbors { get; protected set; }
    public HexagonSide[] Sides { get; protected set; }
    public HexagonPosition Position { get; protected set; }

    [Inject]
    protected virtual void Construct(HexagonMap map)
    {
        Map = map;
    }
   
    public virtual void Awake()
    {
        Neighbors = new Hexagon[6];
        Sides = new HexagonSide[6];
        RecalculateIndexes();
    }

    public void Place()
    {
        transform.position = Position.WorldPosition;

        GetNeighbors();

        for (int i = 0; i < 6; i++)
        {
            if (Neighbors[i])
                Neighbors[i].GetNeighbors();
        }
    }

    protected abstract void GetNeighbors();

    public void RotateRight()
    {
        RotationCount++;
        RotationCount %= 6;
        RecalculateIndexes();
    }

    public void RotateLeft()
    {
        RotationCount--;
        if (RotationCount == -1)
            RotationCount = 5;

        RecalculateIndexes();
    }

    protected void RecalculateIndexes()
    {
        RightUpIndex = (0 + RotationCount) % 6;
        RightIndex = (1 + RotationCount) % 6;
        RightDownIndex = (2 + RotationCount) % 6;
        LeftDownIndex = (3 + RotationCount) % 6;
        LeftIndex = (4 + RotationCount) % 6;
        LeftUpIndex = (2 + RotationCount) % 6;
    }

    public void SetPosition(HexagonPosition position)
    {
        this.Position = position;
    }
}