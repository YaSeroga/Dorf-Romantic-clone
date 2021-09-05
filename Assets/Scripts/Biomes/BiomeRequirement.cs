using UnityEngine;

[System.Serializable]
public abstract class BiomeRequirement
{
    public int Reward;
    public abstract void CheckRequirement(BiomeGroup biomeGroup);
}