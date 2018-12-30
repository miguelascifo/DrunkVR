using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void LoadTestTrackGame()
    {
        SceneManager.LoadScene("TestTrack", LoadSceneMode.Single);
    }

    public void LoadConesGame()
    {
        SceneManager.LoadScene("Cones", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }

    public void LoadAwareness() {
        SceneManager.LoadScene("AwarenessScene", LoadSceneMode.Single);
    }
}
