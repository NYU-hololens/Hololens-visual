using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceCommand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextScene()
    {
        if (Collide.getCollideState())
        {
            SceneManager.LoadScene("AppServiceDemo");
        }
    }

    public void ARtoWelcomeScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
