using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class DismissAction : MonoBehaviour , IInputClickHandler
{

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        // AirTap code goes here
        gameObject.SetActive(false);

    }
    /*
    public void Show()
    {
        if (Detail == null) { return; }
        if (Detail.activeSelf == false)
        {
            Detail.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
            Detail.SetActive(true);
        }
    }

    public void Dismiss()
    {
       if( Detail == null) { return; }
        Detail.SetActive(false);
    }

    public void OnSelect()
    {
        Detail.GetComponent<MeshRenderer>().material.color = new
            Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f,
            Random.Range(0, 255) / 255f);
    }
    */
}
