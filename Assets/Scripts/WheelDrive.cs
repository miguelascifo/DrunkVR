using UnityEngine;
using System;
using System.Collections;

[Serializable]
public enum DriveType
{
	RearWheelDrive,
	FrontWheelDrive,
	AllWheelDrive
}

public class WheelDrive : MonoBehaviour
{
    [Tooltip("Maximum steering angle of the wheels")]
	public float maxAngle = 30f;
	[Tooltip("Maximum torque applied to the driving wheels")]
	public float maxTorque = 800f;
	[Tooltip("Maximum brake torque applied to the driving wheels")]
	public float brakeTorque = 30000f;
	[Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
	public GameObject wheelShape;

	[Tooltip("The vehicle's speed when the physics engine can use different amount of sub-steps (in m/s).")]
	public float criticalSpeed = 5f;
	[Tooltip("Simulation sub-steps when the speed is above critical.")]
	public int stepsBelow = 5;
	[Tooltip("Simulation sub-steps when the speed is below critical.")]
	public int stepsAbove = 1;

	[Tooltip("The vehicle's drive type: rear-wheels drive, front-wheels drive or all-wheels drive.")]
	public DriveType driveType;

    private WheelCollider[] m_Wheels;

	public GameObject controller;

	public AudioSource soundCarStartup;
	public AudioSource soundCarIdle;
	public AudioSource soundCarHighOff;

	float minPitch = 0.9f;
	float maxPitch = 1.5f;

	public float userTorque = 0.0f;

    // Find all the WheelColliders down in the hierarchy.
	void Start()
	{
		m_Wheels = GetComponentsInChildren<WheelCollider>();
		soundCarIdle = GameObject.Find ("IntCarIdle").GetComponent<AudioSource> ();
		soundCarStartup = GameObject.Find ("IntCarStartup").GetComponent<AudioSource> ();
		soundCarHighOff = GameObject.Find ("IntCarHighOff").GetComponent<AudioSource> ();

		soundCarStartup.Play ();

		//controller = GetComponent
		//controller = GameObject.Find ("HandLeft");
		//controller = this.GetComponent<GameObject>();

		for (int i = 0; i < m_Wheels.Length; ++i) 
		{
			var wheel = m_Wheels [i];

			// Create wheel shapes only when needed.
			if (wheelShape != null)
			{
				var ws = Instantiate (wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}
	}

	// This is a really simple approach to updating wheels.
	// We simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero.
	// This helps us to figure our which wheels are front ones and which are rear.
	void Update()
	{
		m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

		// Keyboard control
		// float angle = maxAngle * Input.GetAxis("Horizontal");
		// float torque = maxTorque * Input.GetAxis("Vertical");

		float torque = maxTorque * userTorque;

		float angle = 0;

		if (controller.transform.rotation.eulerAngles.z < 2 || controller.transform.rotation.eulerAngles.z > -2) {
			angle = 0;
			// float torque = controller.transform.rotation.eulerAngles.z;
		}

		if (controller.transform.rotation.eulerAngles.z > 2 || controller.transform.rotation.eulerAngles.z < -2) {
			angle = - controller.transform.rotation.eulerAngles.z;
			// float torque = controller.transform.rotation.eulerAngles.z;
		}

		// Debug.Log (angle);

		// Debug.Log (torque);

		// Debug.Log ("---");

		if (torque <= 0 && !soundCarStartup.isPlaying && !soundCarIdle.isPlaying && !soundCarHighOff.isPlaying) {
			soundCarHighOff.pitch = 0.9f;
			soundCarHighOff.Stop ();
			soundCarIdle.Play ();
		}

		if (torque > 0 && !soundCarStartup.isPlaying && !soundCarHighOff.isPlaying) {
			soundCarIdle.Stop ();
			soundCarHighOff.Play ();
		}

		if (soundCarHighOff.isPlaying && soundCarHighOff.pitch < maxPitch) {
			soundCarHighOff.pitch += Time.deltaTime * minPitch / 5;
		}

		// Debug.Log (Input.GetAxis("Horizontal"));

		float handBrake = Input.GetKey(KeyCode.X) ? brakeTorque : 0;

		foreach (WheelCollider wheel in m_Wheels)
		{
			// A simple car where front wheels steer while rear ones drive.
			if (wheel.transform.localPosition.z > 0)
				wheel.steerAngle = angle;

			if (wheel.transform.localPosition.z < 0)
			{
				wheel.brakeTorque = handBrake;
			}

			if (wheel.transform.localPosition.z < 0 && driveType != DriveType.FrontWheelDrive)
			{
				wheel.motorTorque = torque;
			}

			if (wheel.transform.localPosition.z >= 0 && driveType != DriveType.RearWheelDrive)
			{
				wheel.motorTorque = torque;
			}

			// Update visual wheels if any.
			if (wheelShape) 
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose (out p, out q);

				// Assume that the only child of the wheelcollider is the wheel shape.
				Transform shapeTransform = wheel.transform.GetChild (0);
				shapeTransform.position = p;
				shapeTransform.rotation = q;
			}
		}
	}
}
