using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDataset : MonoBehaviour {

    private Button button;
    private ColorBlock color;
    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        color = GetComponent<Button>().colors;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeColor()
    {
        //color.highlightedColor = Color.gray;
        //color.normalColor = Color.white;
        //color.pressedColor = Color.yellow;
        button.colors = color;
    }
}
