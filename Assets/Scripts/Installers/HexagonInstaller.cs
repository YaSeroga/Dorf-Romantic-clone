using System.ComponentModel;
using UnityEngine;
using Zenject;

public class HexagonInstaller : MonoInstaller
{
    [SerializeField] private HexagonMap _mapPrefab;
    [SerializeField] private HexagonPrefabStorage _storage;
    [SerializeField] private Camera _camera;
    
    public override void InstallBindings()
    {
        Container
            .Bind<Camera>()
            .FromInstance(_camera)
            .AsSingle();
        
        Container
            .Bind<HexagonPrefabStorage>()
            .FromInstance(_storage)
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<IHexagonFactory>()
            .To<HexagonFactory>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        HexagonMap map = 
            Container.InstantiatePrefabForComponent<HexagonMap>(_mapPrefab);
        
        Container
            .Bind<HexagonMap>()
            .FromInstance(map)
            .AsSingle();

    }
}