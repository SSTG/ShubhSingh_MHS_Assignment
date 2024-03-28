using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    public static onMovement OnMovement;
    public UnityEvent onPausedGame;
    public UnityEvent onUnpausedGame;
    bool isShoot;
    public static bool isPaused=false;
    public static event Action OnShootPress;
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        OnMovement?.Invoke(Input.GetAxis("Horizontal"));
        isShoot=Input.GetKeyDown(KeyCode.Space);
        if(isShoot)
        IsShoot();
        if(Input.GetKeyDown(KeyCode.Escape) && GameManager.inGame)
        {
            if(isPaused){
            onUnpausedGame?.Invoke();
            isPaused=false;}
            else
            {
                onPausedGame?.Invoke();
                isPaused=true;
            }
        }

    }
    void IsShoot()
    {
        OnShootPress?.Invoke();
        Debug.Log("Shooting");
    }
    public delegate void onMovement(float value);
}
