using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Dorf Romantic clone/Create hexagone prefab storage")]
public class HexagonPrefabStorage : ScriptableObject
{
    [SerializeField] private HexagonCell _startField;
    [SerializeField] private HexagonEmpty _empty;
    [SerializeField] private HexagonCell[] _other;

    public HexagonCell StartField => _startField;
    public HexagonEmpty Empty => _empty;

    public HexagonCell GetRandomHexagon()
    {
        int randomIndex = Random.Range(0, _other.Length);
        return _other[randomIndex];
    }
}