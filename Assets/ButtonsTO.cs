using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTO : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;

	WheelDrive userTorque;

	// Use this for initialization
	void Start () {
		GameObject car = GameObject.Find ("SportCar2");
		userTorque = car.GetComponent<WheelDrive> ();
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void FixedUpdate()
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);
	}
	
	// Update is called once per frame
	void Update () {
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
			print("Pressing Touchpad");

			if (touchpad.y > 0.7f)
			{
				if (userTorque.userTorque <= 0.9f) {
					userTorque.userTorque += 0.3f;
				}
			}

			else if (touchpad.y < -0.7f)
			{
				if (userTorque.userTorque >= 0.0f) {
					userTorque.userTorque -= 0.3f;
				}
			}

			/* if (touchpad.x > 0.7f)
			{
				print("Moving Right");

			}
			else if (touchpad.x < -0.7f)
			{
				print("Moving left");
			} */

		}
	}
}
