using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using Academy.HoloToolkit.Unity;
using UnityEngine;

public class ColumnManager : MonoBehaviour, IInputClickHandler
{
    public GameObject Detail;
    private Material[] defaultMaterials;
    private bool highlight;
    // Use this for initialization  
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (highlight==true)
        {
            for (int i = 0; i < defaultMaterials.Length; i++)
            {
                defaultMaterials[i].SetFloat("_Highlight", .0f);
            }
            //existingDetail.SetActive(false);
            highlight = false;
            return;
        }

        
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            defaultMaterials[i].SetFloat("_Highlight", .5f);
        }
        highlight = true;

    }

    // Use this for initialization
    void Start () {
        defaultMaterials = GetComponent<Renderer>().materials;
        Collider collider = GetComponentInChildren<Collider>();
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
        highlight = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
