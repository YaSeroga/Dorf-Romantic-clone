using UnityEngine;

[System.Serializable]
public class BiomeGroup
{
    [SerializeField] private Biome biome;
    [SerializeField] private BiomeRequirement[] requirements;
}