using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyHealth))]
public class EnemyHeli : MonoBehaviour
{
    
    // Start is called before the first frame update
    public MovementType movementType;
    [SerializeField]GameObject soldierPrefab;
    [SerializeField]float movementSpeed;
    
    void Start()
    {
        Invoke("RandomSoldierSpawn",Random.Range(1f,8f));
        Destroy(this.gameObject,10f);
    }
    void Update()
    {

        transform.Translate(movementSpeed*Time.deltaTime,0,0);
        
    }

    // Update is called once per frame
    
    void RandomSoldierSpawn()
    {
        Instantiate(soldierPrefab,transform.position,Quaternion.identity);
        Debug.Log("Working");
    }

}
public enum MovementType
{
    LeftToRight=-1,
    RightToLeft=1
    
}
