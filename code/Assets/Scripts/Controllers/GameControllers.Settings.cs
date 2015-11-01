using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public partial class GameController : Singleton<GameController> {
    [Header("Tiles")]    
    public float ElevationLevelUnit = 1.0f;
    public float TileSize = 10.0f;    

    [Header("Resources")]
    public string ResourcesEnemiesPrefix = "enemies";
    public string ResourcesTilessPrefix = "tiles";
    public string ResourcesTurretsPrefix = "turrets";

    [Header("Map")]
    public int MapRadius = 4;

    [Header("Enemies")]
    public float EnemySpawnDeltaTime = 1.0f;
    public float EnemySpawnRadius = 8.0f;
    public float EnemySpawnY = 2.0f;
    public float EnemyVelocity = 0.6f;
}

