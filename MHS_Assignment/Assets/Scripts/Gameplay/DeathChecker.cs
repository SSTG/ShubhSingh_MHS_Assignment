using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]Transform[] deathPositions;
   [HideInInspector]public List<GameObject> paratroopersLanded;
   GameManager gameManager;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        List<GameObject> paratroopersLanded=new List<GameObject>();
    }

    // Update is called once per frame
    
    void OnCollisionEnter(Collision other)
    {
        if(paratroopersLanded.Count>4)
        return;
        if(other.gameObject.GetComponent<Paratrooper>()!=null && other.gameObject.GetComponent<Paratrooper>().isParachuted)
        ParaTrooperLanding(other.gameObject);
        
        if(paratroopersLanded.Count==4)
        StartCoroutine("TriggerDeathSequence");
    }
    public void ParaTrooperLanding(GameObject gameObject)
    {
        paratroopersLanded.Add(gameObject);
        Destroy(gameObject.GetComponent<EnemyHealth>());
        gameObject.GetComponent<Paratrooper>().parachute.SetActive(false);
    }
    IEnumerator TriggerDeathSequence()
    {
        //gameManager.DisableSpawners();
        for(int i=0;i<deathPositions.Length-1;i++)
        {
            paratroopersLanded[i].transform.position=deathPositions[i].position;
           
            yield return new WaitForSeconds(1.5f);
        }
        paratroopersLanded[3].transform.position=deathPositions[4].position;
       
        yield return new WaitForSeconds(1f);
        gameManager.DeadFunction();
        yield return new WaitForSeconds(2f);
    }
}
