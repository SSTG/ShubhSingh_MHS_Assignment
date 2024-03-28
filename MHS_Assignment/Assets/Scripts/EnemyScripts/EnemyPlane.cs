using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyHealth))]
public class EnemyPlane : MonoBehaviour
{
    
    // Start is called before the first frame update
    public MovementType movementType;
    public PlaneType planeType;
    [SerializeField]GameObject droppablePrefab;
    [SerializeField]float movementSpeed;
    
    void Start()
    {
        Invoke("RandomProjectileSpawn",Random.Range(1f,8f));
        Destroy(this.gameObject,10f);
    }
    void Update()
    {

        transform.Translate(movementSpeed*Time.deltaTime,0,0);
        
    }

    // Update is called once per frame
    
    void RandomProjectileSpawn()
    {
        Instantiate(droppablePrefab,transform.position,Quaternion.identity);
        //Debug.Log("Working");
    }

}
public enum MovementType
{
    LeftToRight=-1,
    RightToLeft=1
    
}
public enum PlaneType
{
    Heli, Jet 
}
