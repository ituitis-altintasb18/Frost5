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
        lights += 3;
        if (OnLightsAdded != null && lights != 9)   //maximum number of lights is 9
            OnLightsAdded(lights);
    }
    internal void RemoveLight()
    {
        lights -= 1;
        if (OnLightRemoved != null && lights != 0)   //maximum number of lights is 9
            OnLightRemoved(lights);
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
