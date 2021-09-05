using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;

public class HexagoneMap : MonoBehaviour
{
    public static HexagoneMap Instance { get; private set; }

    [SerializeField] private HexagonePrefabStorage hexagonePrefabStorage;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera cam;


    private Dictionary<HexagonePosition, Hexagone> map;
    private Dictionary<HexagonePosition, HexagoneEmpty> EmptyHexagons;

    // Init the variables
    void Awake()
    {
        Instance = this;
        map = new Dictionary<HexagonePosition, Hexagone>();
        EmptyHexagons = new Dictionary<HexagonePosition, HexagoneEmpty>();
    }

    private void Start()
    {
        CreateStartMap();
    }


    // TODO: Make placing servise using state pattern 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
            {
                if (hit.collider.TryGetComponent(out HexagoneEmpty hexagone))
                {
                    HexagoneCell cell = Instantiate(hexagonePrefabStorage.GetRandomHexagone());
                    cell.Init();
                    cell.SetPosition(hexagone.position);
                    PlaceHexagone(cell, hexagone.position);
                }
            }
        }
    }

    private void CreateStartMap()
    {
        HexagonePosition position = new HexagonePosition(0, 0);
        HexagoneCell startHexagone = Instantiate(hexagonePrefabStorage.StartField);
        startHexagone.Init();
        startHexagone.SetPosition(position);

        PlaceHexagone(startHexagone, position);
    }

    public void PlaceHexagone(Hexagone cell, HexagonePosition position)
    {
        if (map.ContainsKey(position))
        {
            EmptyHexagons.Remove(position);

            Destroy(map[position].gameObject);
            map[position] = cell;
        }
        else
        {
            map.Add(position, cell);
        }

        cell.Place();
    }

    public bool CellExists(HexagonePosition position)
    {
        return map.ContainsKey(position);
    }

    public Hexagone GetHexagoneOrCreateEmpty(HexagonePosition position)
    {
        if (TryGetHexagoneByPosition(position, out Hexagone hexagone))
            return hexagone;

        hexagone = Instantiate(hexagonePrefabStorage.Empty);
        hexagone.Init();
        hexagone.SetPosition(position);

        EmptyHexagons.Add(position, hexagone as HexagoneEmpty);

        PlaceHexagone(hexagone, position);

        return hexagone;
    }
    public bool TryGetHexagoneByPosition(HexagonePosition position, out Hexagone hexagone)
    {
        if (CellExists(position))
        {
            hexagone = map[position];
            return true;
        }

        hexagone = null;
        return false;
    }
}