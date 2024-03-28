using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float scorePoints=10f;
    [SerializeField]ParticleSystem deathEffect;
    [SerializeField]AudioClip deathSound;
    GameManager gameManager;
    AudioManager audioManager;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        audioManager=FindObjectOfType<AudioManager>();
    }
    public void OnDeath()
    {
        Instantiate(deathEffect,transform.position,Quaternion.identity);
        gameManager.Score+=scorePoints;
        audioManager.PlaySFX(deathSound);
        Destroy(this.gameObject);
    }
    
}
