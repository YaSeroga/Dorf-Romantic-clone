using System;
using Zenject;

public class HexagonFactory : IHexagonFactory
{
    private DiContainer _container;
    private HexagonPrefabStorage _storage;

    
    public HexagonFactory(DiContainer container, HexagonPrefabStorage storage)
    {
        _container = container;
        _storage = storage;
    }
    
    public Hexagon Create(HexagonType type)
    {
        Hexagon hexagon = type switch
        {
            HexagonType.Empty => _storage.Empty,
            HexagonType.Start => _storage.StartField,
            HexagonType.Random => _storage.GetRandomHexagon(),
            _ => throw new ArgumentException()
        };

        return _container.InstantiatePrefabForComponent<Hexagon>(hexagon);
    }
}