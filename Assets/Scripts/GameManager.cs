using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives { get; private set; }
    public event Action<int> OnLivesChanged;
    public event Action<int> OnLightsAdded;
    public event Action<int> OnLightRemoved;


    public int lights { get; private set; }
    private int maxLights = 6;
    //private Shooting shooting;

    private AudioSource mAudioSrc;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
    }
    private void Start()
    {
        lights = 0;
        mAudioSrc = GetComponent<AudioSource>();
        //shooting = GameObject.FindWithTag("Player").GetComponent<Shooting>();
    }

    internal void KillPlayer()
    {
        Lives--;
        if (OnLivesChanged != null)
            OnLivesChanged(Lives);

        if (Lives <= 0)
        {
            RestartGame();
        }
        else
        {
            //SendToCheckpoint();
        }


    }

    /*private void SendToCheckpoint()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();
        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();

        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;
    }*/

    internal void AddLight()
    {
        mAudioSrc.Play();
        
        if(lights <= maxLights)
        {
            lights += 3;
        }
        if (OnLightsAdded != null)   //maximum number of lights is 9 so adding 3 to six is 9 wow
             OnLightsAdded(lights);
    }
    internal void RemoveLight()
    {
        if (lights >= 0)
        {
            lights -= 1;
        }
        
        if (OnLightRemoved != null)   //minimum number of light is 0
            OnLightRemoved(lights);
    }

    internal void BigBoom()
    {
        
            lights -= 5;
            if (OnLightRemoved != null && lights != 0)   //maximum number of lights is 9
                OnLightRemoved(lights);
        
        
    }

    internal void GameWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void RestartGame()
    {
        Lives = 3;
        lights = 0;
        if (OnLightsAdded != null)
            OnLightsAdded(lights);
        SceneManager.LoadScene(0);
    }
}
