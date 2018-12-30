using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroCircus : MonoBehaviour {
	
	public string myName;
	GameObject blueP, whiteP, redP, yellowP;
	GameObject sphere1, sphere2, sphere3;
	GameObject cube1, cube2, cube3, cube4, cube5;
	GameObject circus;

	bool yellow = false;
	bool blue = false;
	bool red = false;
	bool white = false;

	Camera camera; // set this via inspector
	float shake = 0.1f;
	float shakeAmount = 0.05f;
	//float decreaseFactor = 1.0f;

	// Use this for initialization
	void Start () {
		Debug.Log("I am alive! and my creator is " + myName);
		sphere1 = GameObject.Find("Sphere1");
		sphere2 = GameObject.Find("Sphere2");
		sphere3 = GameObject.Find("Sphere3");
		cube1 = GameObject.Find("Cube1");
		cube2 = GameObject.Find("Cube2");
		cube3 = GameObject.Find("Cube3");
		cube4 = GameObject.Find("Cube4");
		cube5 = GameObject.Find("Cube5");

		blueP = GameObject.Find("Plane_Blue");
		whiteP = GameObject.Find("Plane_White");
		redP = GameObject.Find("Plane_Red");
		yellowP = GameObject.Find("Plane_Yellow");

		Debug.Log("Information about the objects");
		Debug.Log("Sphere 1 position is: " + sphere1.transform.position);
		Debug.Log("Sphere 2 position is: " + sphere2.transform.position);
		Debug.Log("Sphere 3 position is: " + sphere3.transform.position);
		Debug.Log("Cube 1 position is: " + cube1.transform.position);
		Debug.Log("Cube 2 position is: " + cube2.transform.position);
		Debug.Log("Cube 3 position is: " + cube3.transform.position);
		Debug.Log("Cube 4 position is: " + cube4.transform.position);
		Debug.Log("Cube 5 position is: " + cube5.transform.position);

		//Panel information
		Debug.Log("Information about the panels");
		Debug.Log("Blue Panel position is: " + blueP.transform.position);
		Debug.Log("White Panel position is: " + whiteP.transform.position);
		Debug.Log("Red Panel position is: " + redP.transform.position);
		Debug.Log("Yellow Panel position is: " + yellowP.transform.position);
	}

	// Update is called once per frame
	void Update () {

		camera = Camera.current;

		// Camera changes
		if (shake > 0.0f) {
			//camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
			//shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0.0f;
		}

		// Yellow zone
		if (!yellow) {
			if ((sphere1.transform.position.x >= (0.1f) && sphere1.transform.position.x <= (0.5f))
			   &&
			   (sphere1.transform.position.z >= (5.1f) && sphere1.transform.position.z <= (5.5f))
			   &&
			   (cube2.transform.position.x >= (0.1f) && cube2.transform.position.x <= (0.5f))
			   &&
			   (cube2.transform.position.z >= (5.1f) && cube2.transform.position.z <= (5.5f))) {
				Debug.Log ("You have completed the yellow zone!");
				yellow = true;
			}
		}

		// Red zone
		if (!red) {
			if ((cube3.transform.position.x >= (0.1f) && cube3.transform.position.x <= (0.5f))
				&&
				(cube3.transform.position.z >= (4.6f) && cube3.transform.position.z <= (5.0f))
				&&
				(cube4.transform.position.x >= (0.1f) && cube4.transform.position.x <= (0.5f))
				&&
				(cube4.transform.position.z >= (4.6f) && cube4.transform.position.z <= (5.0f))) {
				Debug.Log ("You have completed the red zone!");
				red = true;
			}
		}

		// Blue zone
		if (!blue) {
			if ((sphere2.transform.position.x >= (-0.5f) && sphere2.transform.position.x <= (-0.1f))
			   && 
			   (sphere2.transform.position.z >= (5.1f) && sphere2.transform.position.z <= (5.5f))
			   &&
			   (cube1.transform.position.x >= (-0.5f) && cube1.transform.position.x <= (-0.1f))
			   &&
			   (cube1.transform.position.z >= (5.1f) && cube1.transform.position.z <= (5.5f))) {
				Debug.Log ("You have completed the blue zone!");
				blue = true;
			}
		}

		// White zone
		if (!white) {
			if ((sphere3.transform.position.x >= (-0.5f) && sphere3.transform.position.x <= (-0.1f))
				&&
				(sphere3.transform.position.z >= (4.6f) && sphere3.transform.position.z <= (5.0f))
				&&
				(cube5.transform.position.x >= (-0.5f) && cube5.transform.position.x <= (-0.1f))
				&&
				(cube5.transform.position.z >= (4.6f) && cube5.transform.position.z <= (5.0f))) {
				Debug.Log ("You have completed the white zone!");
				white = true;
			}
		}

		// Once I have all zones completed I stop playing the sound
		if (red && yellow && blue && white) {
			// Add sound logic in here
			Debug.Log ("You have completed the game!");

			circus = GameObject.Find ("Circus");
			circus.GetComponent<AudioSource> ().Stop ();

		}
	}
}
