using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    void Start()
    {
        Invoke("ResetCountdown" , 2.5f);
       Invoke("DestroyBullet",3.5f);
        gameManager=FindObjectOfType<GameManager>();
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<EnemyHealth>()!=null){
        other.gameObject.GetComponent<EnemyHealth>().OnDeath();
        gameManager.ultCountDown++;
        gameManager.ultimateSlider.value=gameManager.ultCountDown%5;
        gameManager.ultimateText.text="Ultimate : "+gameManager.ultCountDown/5;}
        if(other.gameObject.CompareTag("Parachute"))
        Destroy(other.gameObject);
        Destroy(this.gameObject);

    // Update is called once per frame
   
}
void ResetCountdown()
{
    gameManager.ultCountDown=0;
    gameManager.ultimateSlider.value=gameManager.ultCountDown;
    gameManager.ultimateText.text="Ultimate : "+0;
}
void DestroyBullet()
{
    Destroy(this.gameObject);
    
}
}