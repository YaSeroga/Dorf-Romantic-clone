using UnityEngine;

public class HexagonCell : Hexagon
{

    protected override void GetNeighbors()
    {
        Hexagon[] neighbors = Map.GetNeighbors(Position);
        
        Neighbors[RightUpIndex] = neighbors[0];
        Neighbors[RightIndex] = neighbors[1];
        Neighbors[RightDownIndex] = neighbors[2];

        Neighbors[LeftDownIndex] = neighbors[3];
        Neighbors[LeftIndex] = neighbors[4];
        Neighbors[LeftUpIndex] = neighbors[5];

        
        for (int i = 0; i < 6; i++)
        {
            int revertedIndex = (i + 3) % 6;
            if (Sides[i] != null && Neighbors[i])
                Sides[i].NeighborSide = Neighbors[i].Sides[revertedIndex];
        }
    }
}