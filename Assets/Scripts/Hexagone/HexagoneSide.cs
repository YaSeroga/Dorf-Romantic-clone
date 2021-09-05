using UnityEngine;

[System.Serializable]
public class HexagoneSide
{
    [SerializeField] private Biome biome;
    [SerializeField] private int quantityObjects;
    [SerializeField] private Biome allowedBiomes;
    [SerializeField] private HexagoneSide[] connectedSides; // Composite pattern
    public HexagoneSide NeighborSide { get; set; } // Composite pattern

}