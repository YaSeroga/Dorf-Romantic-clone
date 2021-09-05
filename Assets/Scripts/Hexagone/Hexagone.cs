using System;
using UnityEngine;

[System.Serializable]
public abstract class Hexagone : MonoBehaviour
{
    public static float Length = 1; // Outer circle radius
    public static float Width = 0.866f; // Inner circle radius


    protected int rotationCount;

    protected int rightIndex;
    protected int rightUpIndex;
    protected int rightDownIndex;
    protected int leftIndex;
    protected int leftDownIndex;
    protected int leftUpIndex;

    public Hexagone[] Neighbors { get; protected set; }
    public HexagoneSide[] Sides { get; protected set; }
    public HexagonePosition position { get; protected set; }

    public virtual void Init()
    {
        Neighbors = new Hexagone[6];
        Sides = new HexagoneSide[6];
        RecalculateIndexes();
    }

    public void Place()
    {
        transform.position = position.worldPosition;

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
        rotationCount++;
        rotationCount %= 6;
        RecalculateIndexes();
    }

    public void RotateLeft()
    {
        rotationCount--;
        if (rotationCount == -1)
            rotationCount = 5;

        RecalculateIndexes();
    }

    protected void RecalculateIndexes()
    {
        rightUpIndex = (0 + rotationCount) % 6;
        rightIndex = (1 + rotationCount) % 6;
        rightDownIndex = (2 + rotationCount) % 6;
        leftDownIndex = (3 + rotationCount) % 6;
        leftIndex = (4 + rotationCount) % 6;
        leftUpIndex = (2 + rotationCount) % 6;
    }

    public void SetPosition(HexagonePosition position)
    {
        this.position = position;
    }
}