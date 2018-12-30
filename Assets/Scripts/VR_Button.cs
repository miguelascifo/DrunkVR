using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using VRStandardAssets.Utils;
using UnityEngine.Events;

public class VR_Button : MonoBehaviour {

    public VRInteractiveItem VR_InteractiveItem;
    public Slider slider;

    [Space(20)]
    public float activationTime =2; // in seconds

    private float gazeTimer;
    private bool gazeOver;

    public UnityEvent OnActivateEvent;

    void Update()
    {
        // if we are not looking at this button, reset the gaze timer to zero
        if (!gazeOver)
        {
            // reset timers to zero
            gazeTimer = 0;
        } else
        {
            // as we are looking at the button, let's go ahead and increase gaze timer to time how long the gaze lasts
            gazeTimer += Time.deltaTime;
        }
        
        float theSliderNum = gazeTimer / activationTime;

        slider.value = theSliderNum;
        
        // check to see if we are ready to activate
        if ( gazeTimer >= activationTime )
        {
            // tell the event attached to this button, to go!
            OnActivateEvent.Invoke();
        }
    }

    private void OnEnable()
    {
        // subscribe to hover events from VR_InteractiveItem
        VR_InteractiveItem.OnOver += OnGazeOver;
        VR_InteractiveItem.OnOut += OnGazeLeave;
    }

    private void OnDisable()
    {
        // subscribe to hover events from VR_InteractiveItem
        VR_InteractiveItem.OnOver -= OnGazeOver;
        VR_InteractiveItem.OnOut -= OnGazeLeave;
    }

    void OnGazeOver()
    {
        gazeOver = true;
    }

    void OnGazeLeave()
    {
        gazeOver = false;
    }
}
