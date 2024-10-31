using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayInputText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();

        mText.SetText(InputManager.instance.currentBPM.ToString());
        if (this.tag == "bpmStart")
        {
            mText.SetText(InputManager.instance.startingBPM.ToString());
        }
        if (this.tag == "bpmEnd")
        {
            mText.SetText(InputManager.instance.stoppingBPM.ToString());
        }
        if (this.tag == "secondsUntilBPMIncrease")
        {
            mText.SetText(InputManager.instance.increaseBPMTime.ToString());
        }        
        if (this.tag == "BPMIncreaseAmount")
        {
            mText.SetText(InputManager.instance.increaseBPMAmount.ToString());
        }        
        if (this.tag == "currentBPM")
        {
            mText.SetText(InputManager.instance.currentBPM.ToString());
        }
        

        
    }
}
