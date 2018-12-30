using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VR_Config_Custom : MonoBehaviour {

	public enum roomTypes {standing, sitting};
	public roomTypes theRoomTypes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake(){
		SetUpVR ();
	}

	void SetUpVR(){
		SetUpRoom ();
	}

	void SetUpRoom(){
		var render = SteamVR_Render.instance;

		if (theRoomTypes == roomTypes.standing) {
			render.trackingSpace = ETrackingUniverseOrigin.TrackingUniverseStanding;
		} else {
			render.trackingSpace = ETrackingUniverseOrigin.TrackingUniverseSeated;
		}

		Recenter ();
	}

	void LateUpdate(){
		// Here we check for a keypress to reset the view
		// Whenever the mode is sitting... Don't forget to set this up in Input Manager
		if(theRoomTypes == roomTypes.sitting){
			if (Input.GetButtonUp ("RecenterView")) {
				Recenter ();
			}
		}
	}

	void Recenter()
	{
		// reset the position
		var system = OpenVR.System;
		if (system != null) {
			system.ResetSeatedZeroPose ();
		}

	}
}
