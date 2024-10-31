using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputBPMStart : MonoBehaviour
{
    public TMP_InputField input;
    private Vector3 touchPosition;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;

                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition) && touch.phase.Equals(TouchPhase.Moved))
                {
                    Debug.Log("!");
                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 10));
                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
                    //input.keyboardType = TouchScreenKeyboardType.NumberPad;
                }
            }
        }
    }
}
