using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls4 : MonoBehaviour
{
    #region Instance
    private static SwipeControls4 instance;
    public static SwipeControls4 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeControls4>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeControls", typeof(SwipeControls4)).GetComponent<SwipeControls4>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    private float deadzone = 5f;

    public bool swipeleft, swiperight, swipeup, swipedown;
    private Vector2 swipedelta, starttouch;
    private float lasttap;
    private float sqrdeadzone;

    #region public properties
    public Vector2 Swipedelta { get { return swipedelta; } }
    public bool Swipeleft { get { return swipeleft; } }
    public bool Swiperight { get { return swiperight; } }
    public bool Swipeup { get { return swipeup; } }
    public bool Swipedown { get { return swipedown; } }
    #endregion

    private void Start()
    {
        sqrdeadzone = deadzone * deadzone;
    }

    public void LateUpdate()
    {
        swipeleft = swiperight = swipeup = swipedown = false;

        UpdateMobile();
    }

    public void UpdateMobile()
    {
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                starttouch = Input.mousePosition;               
                Debug.Log(Time.time - lasttap);
                lasttap = Time.time;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                starttouch = swipedelta = Vector2.zero;
            }
        }

        swipedelta = Vector2.zero;

        if(starttouch != Vector2.zero && Input.touches.Length != 0)
        {
            swipedelta = Input.touches[0].position - starttouch;
        }

        if(swipedelta.sqrMagnitude > sqrdeadzone)
        {
            float x = swipedelta.x;
            float y = swipedelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeleft = true;
                    Debug.Log("Swipe Left");
                }
                else
                {
                    swiperight = true;
                    Debug.Log("Swipe Right");
                }
            }
            else
            {
                if (y < 0)
                {
                    swipedown = true;
                    Debug.Log("Swipe Down");
                }
                else
                {
                    swipeup = true;
                    Debug.Log("Swipe Up");
                }
            }

            starttouch = swipedelta = Vector2.zero;
        }
    }
}
