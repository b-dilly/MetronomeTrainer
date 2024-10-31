using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonIncDec : MonoBehaviour
{
    private Vector3 touchPosition;
    public int IncDec;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;

                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition) && touch.phase.Equals(TouchPhase.Began))
                {
                    if (InputManager.instance.metronomeStart == false) //disable buttons if matronome is going
                    {
                        if (this.tag == "bpmStart")
                        {
                            Debug.Log("!");
                            InputManager.instance.startingBPM += IncDec;
                        }
                        if (this.tag == "bpmEnd")
                        {
                            Debug.Log("!!");
                            InputManager.instance.stoppingBPM += IncDec;
                        }
                        if (this.tag == "secondsUntilBPMIncrease")
                        {
                            Debug.Log("!!!");
                            InputManager.instance.increaseBPMTime += IncDec;
                        }
                        if (this.tag == "BPMIncreaseAmount")
                        {
                            Debug.Log("!!!!");
                            InputManager.instance.increaseBPMAmount += IncDec;
                        }
                    }
                    if (this.tag == "startButton")
                    {
                        
                        if (InputManager.instance.metronomeStart == false)
                        {
                            InputManager.instance.metronomeStart = true;
                        }
                        else
                        {
                            SceneManager.LoadScene(0);
                            InputManager.instance.metronomeStart = false;
                        }
                                          
                    }

                }
            }
        }
    }
}
