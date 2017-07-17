using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTableData : MonoBehaviour
{

    #region Properties
    /// <summary>
    /// List of Columns
    /// </summary>
    public List<ColumnData> ColumnList;

    /// <summary>
    /// X Coordinate of parent sphere
    /// </summary>
    public float ObjXcoor;

    /// <summary>
    /// Y Coordinate of parent sphere
    /// </summary>
    public float ObjYcoor;

    /// <summary>
    /// Z Coordinate of parent sphere
    /// </summary>
    public float ObjZcoor;

    /// <summary>
    /// Space between each object
    /// </summary>
    public float ObjGap;

    #endregion


    #region Public Methods
    // Use this for initialization
    void Start()
    {
        
        LoadDataFromAzure();
        LoadColumnObjects(ColumnList);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Generates Objects w.r.t. column data
    /// TODO: 1. Position Objects w.r.t. spheres
    /// 2. Display text on each objects
    /// </summary>
    /// <param name="ColumnList"></param>
    public void LoadColumnObjects(List<ColumnData> ColumnList)
    {
        GameObject gameObj;
        GameObject parentObj = GameObject.FindGameObjectWithTag("SphereTable1");
        Vector3 sphere1Position= parentObj.transform.position;
        ObjXcoor = sphere1Position.x;
        ObjYcoor = sphere1Position.y;
        ObjZcoor = sphere1Position.z;
        ObjGap = ObjYcoor;


        foreach (ColumnData item in ColumnList)
        {
            switch (item.ColumnType)
            {
                //Add GameObjects template in Prefab and load from there
                case "String":
                    gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gameObj.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case "DateTime":
                    gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gameObj.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case "Int":
                    gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gameObj.GetComponent<Renderer>().material.color = Color.green;
                    break;

                default:
                    gameObj = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    break;
            }

            gameObj.transform.position = new Vector3(ObjXcoor, ObjYcoor, ObjZcoor);
            ObjYcoor += 0.4f;


            //Scale down objects
            Vector3 tempSize;
            tempSize = gameObj.transform.localScale;
            tempSize.x = 1.5f;
            tempSize.y = 0.2f;
            tempSize.z = 0.2f;
            gameObj.transform.localScale = tempSize;



        }




    }

    /// <summary>
    /// Populates the column list
    /// TODO: Load table description data from azure
    /// Load list of columns from Azure
    /// </summary>
    public void LoadDataFromAzure()
    {
        ColumnList = new List<ColumnData>();
        ColumnList.Add(new ColumnData("ID", "String"));
        ColumnList.Add(new ColumnData("First Name", "String"));
        ColumnList.Add(new ColumnData("Last Name", "String"));
        ColumnList.Add(new ColumnData("Company", "String"));

        ColumnList.Add(new ColumnData("Date", "DateTime"));
        ColumnList.Add(new ColumnData("Units Sold", "Int"));
        ColumnList.Add(new ColumnData("Total Sales", "Int"));
    }
    #endregion

}

/// <summary>
/// Class representing column data
/// TODO: 1. Create Wrapper class for each table, 
/// 2. Include properties for table description data
/// </summary>
public class ColumnData
{
    public string ColumnName { get; set; }
    public string ColumnType { get; set; }
    public ColumnData(string _columnName, string _columnType)
    {
        ColumnName = _columnName;
        ColumnType = _columnType;
    }
}

