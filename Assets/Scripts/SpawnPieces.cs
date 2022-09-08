using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPieces : MonoBehaviour
{
    public Transform spawnPoint;
    public Pieces pieces;
    public GameObject[] piecesPrefabs;
    public static SpawnPieces instance;
    public Transform[] table;

    public bool canSpawn = false;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        GetPiece();
    }
    private void Update()
    {
        Spawner();
    }

    private void Spawner()
    {
        if (canSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        foreach (var p in piecesPrefabs)
        {
            if (p.tag==pieces.ToString())
            {
                Instantiate(p,new Vector3(spawnPoint.position.x,spawnPoint.position.y,
                    -1.24969f),spawnPoint.rotation);
                canSpawn = false;
            }
        }
    }

    private void GetPiece()
    {
        var piece = UnityEngine.Random.Range(0,4);
        switch (piece)
        {
            case 0:
                pieces = Pieces.Cubo; 
                break;
            case 1:
                pieces = Pieces.L;
                break;
            case 2:
                pieces = Pieces.Palito;
                break;
            case 3:
                pieces = Pieces.W;
                break;
            default:
                pieces = Pieces.Cubo;
                break;
        }
    }
}
