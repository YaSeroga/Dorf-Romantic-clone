using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class HexagonSide
{
    [SerializeField] private Biome _biome;
    [SerializeField] private int _quantityObjects;
    [SerializeField] private Biome _allowedBiomes;
    
    private HexagonSide[] _connectedSides; // Composite pattern
    public HexagonSide NeighborSide { get; set; } // Composite pattern

}