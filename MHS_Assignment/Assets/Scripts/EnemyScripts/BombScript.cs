using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody rb;
    [SerializeField]float dropForce;
    GameManager gameManager;
    void Awake()
    {
        player=GameObject.FindWithTag("Player");
        rb=GetComponent<Rigidbody>();
        gameManager=FindObjectOfType<GameManager>();
    }
    void Start()
    {
        
        Vector3 direction=(player.transform.position-transform.position).normalized;
        rb.AddForce(dropForce*direction, ForceMode.Impulse);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        StartCoroutine("Death");
        Destroy(this.gameObject);
    }
    IEnumerator Death()
    {
        gameManager.DeadFunction();
        yield return new WaitForSeconds(2f);
    }
}
