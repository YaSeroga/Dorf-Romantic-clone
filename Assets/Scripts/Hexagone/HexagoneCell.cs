using UnityEngine;

public class HexagoneCell : Hexagone
{

    protected override void GetNeighbors()
    {
        System.Func<HexagonePosition, Hexagone> Get = HexagoneMap.Instance.GetHexagoneOrCreateEmpty;

        Neighbors[rightUpIndex] = Get(position + HexagonePosition.RightUpDelta);
        Neighbors[rightIndex] = Get(position + HexagonePosition.RightDelta);
        Neighbors[rightDownIndex] = Get(position + HexagonePosition.RightDownDelta);

        Neighbors[leftDownIndex] = Get(position + HexagonePosition.LeftDownDelta);
        Neighbors[leftIndex] = Get(position + HexagonePosition.LeftDelta);
        Neighbors[leftUpIndex] = Get(position + HexagonePosition.LeftUpDelta);

        for (int i = 0; i < 6; i++)
        {
            int revertedIndex = (i + 3) % 6;
            if (Sides[i] != null && Neighbors[i])
                Sides[i].NeighborSide = Neighbors[i].Sides[revertedIndex];
        }
    }
}