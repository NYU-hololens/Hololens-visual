using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject warning;
    // Use this for initialization  
    void Start()
    {
        warning.SetActive(false);
        GameObject button = GameObject.Find("Button");
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.nextScene(button);
        });
    }

    // Update is called once per frame  
    void Update()
    {
    }

    public void nextScene(GameObject button)
    {
        int count = 0;
        GameObject toggleGroup = GameObject.Find("Canvas/DatasetGroup");

        foreach (Toggle child in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            if (child.isOn == true) count++; 
        }
        if (count >= 2) {
            //change scene
            SceneManager.LoadScene("AppServiceDemo");
        }
        else
        {
            if (warning == null) return;
            warning.SetActive(true);
        }
    }
}