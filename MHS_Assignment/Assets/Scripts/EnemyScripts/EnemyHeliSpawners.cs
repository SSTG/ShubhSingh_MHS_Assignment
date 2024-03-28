using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeliSpawners : Singleton<EnemyHeliSpawners>
{
    // Start is called before the first frame update
    [SerializeField]GameObject[] enemyPrefabs;
    [SerializeField]Transform[] spawnLocations;
    [Range(0,3)]
    [SerializeField]float verticalOffsetRange;
    // [SerializeField]int poolLimit=20;
    // Queue<GameObject> enemyHelis;
    
    void OnEnable()
    {
        StartCoroutine("Spawn");
        
    }
    void OnDisable()
    {
        StopCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while(true){
        int randomSpawnLocationIndex=(int)Random.Range(0,spawnLocations.Length);
        Vector3 spawnLocation=spawnLocations[randomSpawnLocationIndex].position+new Vector3(0,Random.Range(-verticalOffsetRange,verticalOffsetRange),0);
        GameObject heli=Instantiate(enemyPrefabs[Random.Range(0,2)], spawnLocation,Quaternion.identity);
        AssignMovement(randomSpawnLocationIndex,heli.GetComponent<EnemyPlane>());
        yield return new WaitForSeconds(2f);
        }
    }
    void AssignMovement(int index,EnemyPlane enemyHeli)
    {
        if(index==0){
        enemyHeli.movementType=MovementType.RightToLeft;
        enemyHeli.gameObject.transform.rotation=Quaternion.Euler(0,0,0);}
        else{
        enemyHeli.movementType=MovementType.LeftToRight;
        enemyHeli.gameObject.transform.rotation=Quaternion.Euler(0,-180,0);
    }}
}
