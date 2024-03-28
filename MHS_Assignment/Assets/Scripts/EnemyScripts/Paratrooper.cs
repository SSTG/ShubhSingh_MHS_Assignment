using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paratrooper : MonoBehaviour
{
    public GameObject parachute;
    public bool isGrounded;
    [SerializeField]float decelerationAmount=9f;
    Rigidbody rb;
    [HideInInspector]public bool isParachuted=true;
    bool deceleratedParachute=false;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        transform.rotation=Quaternion.Euler(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        isParachuted=parachute!=null;
        if(isParachuted)
        ReduceDownAcceleration();
       
        
    }
    void ReduceDownAcceleration()
    {
         rb.AddForce(transform.up*decelerationAmount*Time.deltaTime,ForceMode.Impulse);
         deceleratedParachute=true;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground")){
            if(!isParachuted)
        DeathFunction();
        isGrounded=true;
       
    }
    }
    void DeathFunction()
    {
        GetComponent<EnemyHealth>().OnDeath();
    }
}
