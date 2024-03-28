using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    void Start()
    {
        Destroy(this.gameObject,3.5f);
        gameManager=FindObjectOfType<GameManager>();
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        other.gameObject.GetComponent<EnemyHealth>().OnDeath();
        if(other.gameObject.CompareTag("Parachute"))
        Destroy(other.gameObject);
    Destroy(this.gameObject);

    // Update is called once per frame
   
}
}