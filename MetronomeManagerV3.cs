using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeManagerV3 : MonoBehaviour
{
    //Every X minutes, increase the BPM by Y bpm until the bpn reaches Z bpm

    public float startingBPM;
    public float currentBPM;
    public float stopBPM;

    public float secondsUntilIncrease;
    public float amountofBPMIncrease;
    public float stoppingBPM;

    public float metronomeRateTimer;
    public float minutesUntilIncreseTimer;

    AudioSource metronomeTick;

    public GameObject activePanel;
    public Color A;
    public Color B;

    void Start()
    {
        metronomeTick = GetComponent<AudioSource>();
        activePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        if (InputManager.instance.metronomeStart == true)
        {
            activePanel.SetActive(true);
            metronomeRateTimer -= Time.deltaTime;
            InputManager.instance.currentBPM = currentBPM; 
            if (metronomeRateTimer <= 0.0f)
            {
                Debug.Log("BEAT");
                metronomeTick.Play();
                metronomeRateTimer = 60 / currentBPM;
                if (activePanel.GetComponent<SpriteRenderer>().color == A)
                {
                    activePanel.GetComponent<SpriteRenderer>().color = B;
                }
                else
                {
                    activePanel.GetComponent<SpriteRenderer>().color = A;
                }
            }

            //rate increase code
            if (currentBPM < stopBPM)
            {
                minutesUntilIncreseTimer -= Time.deltaTime;
                if (minutesUntilIncreseTimer <= 0.0f)
                {
                    Debug.Log("BEAT INCREASED");
                    currentBPM += amountofBPMIncrease;
                    minutesUntilIncreseTimer = secondsUntilIncrease;
                }
            }
        }
        else
        {
            startingBPM = InputManager.instance.startingBPM; //bpm to start at
            stopBPM = InputManager.instance.stoppingBPM; //bpm to stop at
            amountofBPMIncrease = InputManager.instance.increaseBPMAmount; //amount of bpm to increase by
            secondsUntilIncrease = InputManager.instance.increaseBPMTime; //amount of time before bpm increases
            currentBPM = startingBPM;
            activePanel.SetActive(false);
        }
    }

}
