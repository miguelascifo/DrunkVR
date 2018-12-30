using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class DoorController : MonoBehaviour {

    private bool isOpen;

    public Vector3 openRotation;
    public Vector3 closedRotation;
    public Transform ObjectToRotate;
  
    public VRInteractiveItem VR_InteractiveItem;

    void Start () {
        // update the current state of door
        UpdateDoorState();
    }
	
    void ToggleDoor()
    {
        // this will just use isOpen to toggle the door open or closed
        if(isOpen)
        {
            CloseDoor();
        } else
        {
            OpenDoor();
        }
    }
    
    void OpenDoor()
    {
        // set isOpen and call to update the actual door in the scene via the UpdateDoorState() function
        isOpen = true;
        UpdateDoorState();
    }

    void CloseDoor()
    {
        // set isOpen and call to update the actual door in the scene via the UpdateDoorState() function
        isOpen = false;
        UpdateDoorState();
    }

    void UpdateDoorState()
    {
        // here we adjust the rotation of the door so that it is physically open or closed
        if(isOpen)
        {
            ObjectToRotate.localEulerAngles = openRotation;
        } else
        {
            ObjectToRotate.localEulerAngles = closedRotation;
        }
    }

    private void OnEnable()
    {
        // subscribe to events from VR_InteractiveItem
        VR_InteractiveItem.OnClick += OnClick;
    }

    private void OnDisable()
    {
        // unsubscribe from events from VR_InteractiveItem
        VR_InteractiveItem.OnClick -= OnClick;
    }

    void OnClick()
    {
        // call to toggle the door open or closed
        ToggleDoor();
    }
}
