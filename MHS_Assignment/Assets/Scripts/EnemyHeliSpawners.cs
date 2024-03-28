using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeliSpawners : Singleton<EnemyHeliSpawners>
{
    // Start is called before the first frame update
    [SerializeField]GameObject enemyHeliPrefab;
    [SerializeField]Transform[] spawnLocations;
    [Range(0,3)]
    [SerializeField]float verticalOffsetRange;
    [SerializeField]int poolLimit=20;
    //List<GameObject> enemyHelis;
    void Start()
    {
        // for(int i=0;i<poolLimit;i++)
        // {
        //     GameObject gameObject=Instantiate(enemyHeliPrefab);
        //     enemyHelis.Add(gameObject);
        //     gameObject.SetActive(false);
        // }
        StartCoroutine("Spawn");
        
    }

    IEnumerator Spawn()
    {
        while(true){
        int randomSpawnLocationIndex=(int)Random.Range(0,spawnLocations.Length);
        Vector3 spawnLocation=spawnLocations[randomSpawnLocationIndex].position+new Vector3(0,Random.Range(-verticalOffsetRange,verticalOffsetRange),0);
        GameObject heli=Instantiate(enemyHeliPrefab, spawnLocation,Quaternion.identity);
        AssignMovement(randomSpawnLocationIndex,heli.GetComponent<EnemyHeli>());
        yield return new WaitForSeconds(2f);
        }
    }
    void AssignMovement(int index,EnemyHeli enemyHeli)
    {
        if(index==0){
        enemyHeli.movementType=MovementType.RightToLeft;
        enemyHeli.gameObject.transform.rotation=Quaternion.Euler(0,0,0);}
        else{
        enemyHeli.movementType=MovementType.LeftToRight;
        enemyHeli.gameObject.transform.rotation=Quaternion.Euler(0,-180,0);
    }}
}
