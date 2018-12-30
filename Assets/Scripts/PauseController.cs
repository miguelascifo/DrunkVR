using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
	// Pause Canvas
	public GameObject pausePanel;

	private bool isPaused = false;

	WheelDrive sound;
	
	// Use this for initialization
	void Start ()
	{
		pausePanel.SetActive(isPaused);

		GameObject car = GameObject.Find ("SportCar2");
		sound = car.GetComponent<WheelDrive> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		// Escape has been pressed
		if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.activeInHierarchy)
		{
			// Pausing game
			Debug.Log("Pressed Escape");
			Debug.Log("Pausing");
			Pause();
			return;
		}
		
	
		// Continue Game
		if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeInHierarchy)
		{
			Debug.Log("Pressed Escape");
			Debug.Log("Continue");
			Continue();
		}
		
	}
	
	
	public void RestartGame()
	{
		SceneManager.LoadScene("TestTrack", LoadSceneMode.Single);
	}

    public void RestartConeGame()
    {
        SceneManager.LoadScene("Cones", LoadSceneMode.Single);
    }


    public void MainMenu()
	{
		SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
	}


	//UnPauses the game
	public void Continue()
	{
		//Continuing game
		Time.timeScale = 1;

		sound.soundCarIdle.Play ();
		
		//Updating UI
		isPaused = false;
		pausePanel.SetActive(isPaused);
	}
	
	

	// Pauses the game
	private void Pause()
	{
		//Pausing game
		Time.timeScale = 0;

		sound.soundCarIdle.Stop ();
		sound.soundCarHighOff.Stop ();
		sound.soundCarStartup.Stop ();
		
		//Updating UI
		isPaused = true;
		pausePanel.SetActive(isPaused);
		
	}



}
