using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

/// <summary>
/// Destroys the gameobject when it receives the OnSelect message.
/// </summary>
public class DismissOnSelect : MonoBehaviour
{
    // Use this for initialization  
    public void OnInputClicked(InputClickedEventData eventData)
    {
        gameObject.SetActive(false);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}