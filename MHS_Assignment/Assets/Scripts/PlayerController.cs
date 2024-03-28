using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Transform turretHead;
    [SerializeField]GameObject bulletPrefab;
    [SerializeField]float rotationAmount=1f;
    [SerializeField]float bulletForce=10f;
    GameManager gameManager;
    void Awake()
    {
        InputManager.OnMovement+=Movement;
        InputManager.OnShootPress+=Shoot;
        gameManager=FindObjectOfType<GameManager>();
        //turretHead=transform.Find("PivotTurret");
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Movement(float horizontal)
    {
        
        turretHead.Rotate(0,0,-horizontal*rotationAmount);
        LimitRotation(turretHead.rotation);
        
    }
    void LimitRotation(Quaternion rotation)
    {
        Vector3 eulerAngles=rotation.eulerAngles;
        eulerAngles.z=eulerAngles.z>180f ? eulerAngles.z-360 : eulerAngles.z;
        //eulerAngles.z=eulerAngles.z<=-55f ? -55f : eulerAngles.z;
        eulerAngles.z=Mathf.Clamp(eulerAngles.z,-55f,55f);
        turretHead.rotation=Quaternion.Euler(eulerAngles);

    }
    void Shoot()
    {
        GameObject bullet=Instantiate(bulletPrefab,turretHead.transform.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(turretHead.up*bulletForce,ForceMode.Impulse);
        gameManager.Score--;

    }
}
