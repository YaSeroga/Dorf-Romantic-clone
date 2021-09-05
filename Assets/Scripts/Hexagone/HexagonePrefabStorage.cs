using UnityEngine;

[CreateAssetMenu(menuName = "Dorf Romantic clone/Create hexagone prefab storage")]
public class HexagonePrefabStorage : ScriptableObject
{
    public HexagoneCell StartField;
    public HexagoneCell[] Other;
    public HexagoneEmpty Empty;

    public HexagoneCell GetRandomHexagone()
    {
        int randomIndex = Random.Range(0, Other.Length);
        return Other[randomIndex];
    }
}