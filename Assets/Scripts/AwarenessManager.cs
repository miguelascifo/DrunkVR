using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AwarenessManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
	}

	public void PlayAlcoholVideo()
	{
	}

	public void PlayLSDVideo()
	{
	}

	public void PlayCocaineVideo()
	{
	}
}
