using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public static float score=0;
    public static float highScore;
    public static bool inGame=false;
    public UnityEvent OnDeath;
    [SerializeField]Text scoreText;
    [SerializeField]ParticleSystem deathVFX;
    [SerializeField]Text highScoreText;
    [SerializeField]GameObject[] spawners;
    EnemyHeliSpawners enemyHeliSpawners;
    GameObject player;
    InputManager inputManager;
    public float Score{ get{ return score;} set{ score=value;}}
    void Awake()
    {
        inputManager=FindObjectOfType<InputManager>();
        score=0;
        DontDestroyOnLoad(this.gameObject);
        player=GameObject.FindWithTag("Player");
        PauseGame();
        enemyHeliSpawners=FindObjectOfType<EnemyHeliSpawners>();
        if(PlayerPrefs.HasKey("HighScore"))
        highScore=PlayerPrefs.GetFloat("HighScore");
    }
    public void DeadFunction()
    {
        if((PlayerPrefs.HasKey("HighScore") && PlayerPrefs.GetFloat("HighScore")<=score) || !PlayerPrefs.HasKey("HighScore"))
        PlayerPrefs.SetFloat("HighScore",score);
        Instantiate(deathVFX,player.transform.position,Quaternion.identity);
        Destroy(player);
        //Destroy(this.gameObject);
        Destroy(inputManager.gameObject);
       OnDeath?.Invoke();
    }
    public void DestroySpawners()
    {
        foreach (GameObject go in spawners)
        Destroy(go);
        Destroy(enemyHeliSpawners.gameObject);
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void AppearWindow(GameObject window)
    {
        window.SetActive(true);
    }
    public void DisappearWindow(GameObject window)
    {
        window.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale=0;
    }
    public void UnpauseGame()
    {
        Time.timeScale=1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("StartMenu")==null)
        inGame=true;
        scoreText.text="Score : "+score;
        highScoreText.text="High Score : "+highScore;
    }
}
