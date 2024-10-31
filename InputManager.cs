using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Every X minutes, increase the BPM by Y bpm until the bpn reaches Z bpm

    public static InputManager instance;

    public float startingBPM; //bpm to start at
    public float stoppingBPM; //bpm to stop at
    public float increaseBPMAmount; //amount of bpm to increase by
    public float increaseBPMTime; //amount of time before bpm increases
    public float currentBPM; //currentBPM increases

    public bool metronomeStart;

    void Awake()
    {
        metronomeStart = false;

        startingBPM = 100;
        stoppingBPM = 120;
        increaseBPMAmount = 1;
        increaseBPMTime = 60;



        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
