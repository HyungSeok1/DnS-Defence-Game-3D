using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] Enemy = new GameObject[3];
    public int[] stageEnemyCount = new int[3] {15, 35,45};
    void FixedUpdate()
    {   
        if  (!UI_Controller.isInstantiated && !UI_Controller.isGameOver && !UI_Controller.isUpgrade)
        {
            InstantiateEnemy(Enemy[UI_Controller.stage-1]);
            UI_Controller.isInstantiated = true;
        }
    }

    void InstantiateEnemy(GameObject Enemy)
    {
        for (int i = 0; i < stageEnemyCount[UI_Controller.stage-1]; ++i){
            Instantiate(Enemy, new Vector3(Random.Range(-4f, 3f), 0, Random.Range(-6f, 6f)), Quaternion.identity, this.transform);
            UI_Controller.enemies++;
        }
    }
}
