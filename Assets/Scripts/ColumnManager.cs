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
        //get the parent object !! right now just hardcode 
        GameObject parent = GameObject.FindGameObjectWithTag("SphereTable1");

        string tableName = parent.tag;
        string columnName = this.gameObject.transform.Find("ColumnNameText").GetComponent<TextMesh>().text;
        
        

        //dehighlight the object
        if (highlight==true)
        {
            for (int i = 0; i < defaultMaterials.Length; i++)
            {
                defaultMaterials[i].SetFloat("_Highlight", .0f);
            }
            highlight = false;
            //remove the column name to the SelectedColumnInfo
            SelectedColumnInfo.removeColumnName(tableName, columnName);

            Debug.Log(tableName + " " + columnName + " remove " + SelectedColumnInfo.getColumnNameSet(tableName).Count);
            Debug.Log("Column name in set");
            foreach(string cn in SelectedColumnInfo.getColumnNameSet(tableName))
            {
                Debug.Log(cn);
            }
            return;
        }

        //highlight the column
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            defaultMaterials[i].SetFloat("_Highlight", .5f);
        }
        highlight = true;
        //add the column name to the SelectedColumnInfo
		SelectedColumnInfo.setLastColumnName(tableName, columnName);
        SelectedColumnInfo.addColumnName(tableName, columnName);
        Debug.Log(tableName + " " + columnName + " add " + SelectedColumnInfo.getColumnNameSet(tableName).Count);
        Debug.Log("Column name in set");
        foreach (string cn in SelectedColumnInfo.getColumnNameSet(tableName))
        {
            Debug.Log(cn);
        }

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
