using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Serialization;
using Zenject;

public class HexagonMap : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    private Dictionary<HexagonPosition, Hexagon> _map;
    private Dictionary<HexagonPosition, HexagonEmpty> _emptyHexagones;
    private Camera _camera;
    private IHexagonFactory _factory;

    [Inject]
    private void Construct(IHexagonFactory factory, Camera cam)
    {
        _factory = factory;
        _camera = cam;
    }
    
    // Init the variables
    void Awake()
    {
        _map = new Dictionary<HexagonPosition, Hexagon>();
        _emptyHexagones = new Dictionary<HexagonPosition, HexagonEmpty>();
    }

    private void Start()
    {
        CreateStartMap();
    }


    // TODO: Make placing service using state pattern 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, _layerMask))
            {
                if (hit.collider.TryGetComponent(out HexagonEmpty hexagon))
                {
                    Hexagon cell = _factory.Create(HexagonType.Random);
                    cell.SetPosition(hexagon.Position);
                    PlaceHexagon(cell, hexagon.Position);
                }
            }
        }
    }

    private void CreateStartMap()
    {
        Hexagon startHexagon = _factory.Create(HexagonType.Start);

        HexagonPosition position = new HexagonPosition(0, 0);
        startHexagon.SetPosition(position);
        
        PlaceHexagon(startHexagon, position);
    }
    private void PlaceHexagon(Hexagon cell, HexagonPosition position)
    {
        if (_map.ContainsKey(position))
        {
            _emptyHexagones.Remove(position);

            Destroy(_map[position].gameObject);
            _map[position] = cell;
        }
        else
        {
            _map.Add(position, cell);
        }

        cell.Place();
    }
    private bool CellExists(HexagonPosition position)
    {
        return _map.ContainsKey(position);
    }

    public Hexagon[] GetNeighbors(HexagonPosition position)
    {
        Hexagon[] result =new Hexagon[6];
        
        Func<HexagonPosition, Hexagon> get = GetHexagonOrCreateEmpty;
        
        result[0] = get(position + HexagonPosition.RightUpDelta);
        result[1] = get(position + HexagonPosition.RightDelta);
        result[2] = get(position + HexagonPosition.RightDownDelta);

        result[3] = get(position + HexagonPosition.LeftDownDelta);
        result[4] = get(position + HexagonPosition.LeftDelta);
        result[5] = get(position + HexagonPosition.LeftUpDelta);
        
        return result;
    }

    private Hexagon GetHexagonOrCreateEmpty(HexagonPosition position)
    {
        if (TryGetHexagonByPosition(position, out Hexagon hexagon))
            return hexagon;

        hexagon = _factory.Create(HexagonType.Empty);
        hexagon.SetPosition(position);
        PlaceHexagon(hexagon, position);

        _emptyHexagones.Add(position, (HexagonEmpty) hexagon);
        
        return hexagon;
    }
    private bool TryGetHexagonByPosition(HexagonPosition position, out Hexagon hexagon)
    {
        if (CellExists(position))
        {
            hexagon = _map[position];
            return true;
        }

        hexagon = null;
        return false;
    }
}