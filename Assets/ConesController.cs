using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConesController : MonoBehaviour {

    private int counter = 0;

    public Text counter_text;


	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        counter_text.text = "Crashed with: " + counter + " cones";
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cone")
        {
            // Crashed with a cone
            counter = counter + 1;
            Destroy(other.gameObject);

        }

        if (other.gameObject.name == "End")
        {
            // End
            SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
        }
    }
}
