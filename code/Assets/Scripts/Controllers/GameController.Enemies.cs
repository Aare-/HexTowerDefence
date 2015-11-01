using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;
using UnityEngine;

public partial class GameController : Singleton<GameController> {
    float deltaSpawnTime = 0.0f;

    void UpdateEnemies() {        
        deltaSpawnTime -= Time.deltaTime;

        if (deltaSpawnTime < 0.0f) {
            TinyMessengerHub.Instance.Publish<Msg.SpawnBasicEnemy>(new Msg.SpawnBasicEnemy());            
            deltaSpawnTime = GameController.Instance.EnemySpawnDeltaTime;
        }
    }    
}