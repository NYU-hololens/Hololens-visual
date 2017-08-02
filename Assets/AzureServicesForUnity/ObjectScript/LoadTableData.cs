using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public class LoadTableData : MonoBehaviour
{

    public static bool IsCommonTableEnabled = false;
    public static DataTable Table1;
    public static DataTable Table2;
    public static DataTable MergedTable;


    public const int MAX_NO_OF_ROWS = 10;



    public List<ColumnData> ColumnList;

    public float ObjXcoor;

    public float ObjYcoor;

    public float ObjZcoor;

    public float ObjGap;



    void Start()
    {

        //LoadColumnObjects(ColumnList);
        LoadDataFromAzureTable1();
        LoadDataFromAzureTable2();
        LoadColumnObjects(Table1, "Table1");
        LoadColumnObjects(Table2, "Table2");

    }

    void Update()
    {
        //if (IsCommonTableEnabled)
        //{
        //    Destroy(GameObject.FindWithTag("commonColumnStuff"));
        //}
    }


    public void LoadColumnObjects(DataTable table, string tableName)
    {
        List<ColumnData> ColumnList = table.DataColumnList;
        int noOfRows = MAX_NO_OF_ROWS;
        int noOfColms = ((ColumnList.Count - 1) / noOfRows) + 1;
        GameObject gameObj;
        GameObject parentObj = GameObject.FindGameObjectWithTag("SphereTable1");
        Vector3 sphere1Position = parentObj.transform.position;
        ObjXcoor = sphere1Position.x + 5f;
        ObjYcoor = sphere1Position.y;
        ObjZcoor = 0.1f;//sphere1Position.z;
        ObjGap = ObjYcoor;

        int counter = 0;
        int flag = 1;
        if (tableName == "Table2")
        {
            flag = -1;
        }

        GameObject TextHeadingObject = Instantiate(Resources.Load("TableHeader", typeof(GameObject))) as GameObject;
        TextHeadingObject.transform.position = new Vector3(flag * noOfColms * .5f, noOfRows * 0.3f, ObjZcoor);//add specified distance
        TextHeadingObject.transform.GetComponent<TextMesh>().text = table.TableName;

        for (int i = 0; i < noOfColms; i++)
        {

            for (int j = 0; j < noOfRows; j++)
            {
                if (counter == ColumnList.Count)
                {
                    break;
                }
                switch (ColumnList[counter].ColumnType)
                {
                    //Add more objects for different types of values
                    case "varchar":
                        gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject1", typeof(GameObject))) as GameObject;
                        break;
                    case "DATETIME":
                        gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject2", typeof(GameObject))) as GameObject;
                        break;
                    case "FLOAT":
                        gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject3", typeof(GameObject))) as GameObject;
                        break;
                    case "INTEGER":
                        gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject4", typeof(GameObject))) as GameObject;
                        break;
                    default:
                        gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject4", typeof(GameObject))) as GameObject;
                        break;
                }

                gameObj.transform.position = new Vector3(flag * i * .9f, j * 0.3f, ObjZcoor);//add specified distance
                gameObj.transform.Find("ColumnNameText").GetComponent<TextMesh>().text = ColumnList[counter].ColumnName;
                counter++;

                //Scale down objects
                Vector3 tempSize;
                tempSize = gameObj.transform.localScale;
                tempSize.x = 0.8f;
                tempSize.y = 0.2f;
                tempSize.z = 0.2f;
                gameObj.transform.localScale = tempSize;


                //TODO: Find a more elegant way
                if (tableName == "Table1")
                {
                    gameObj.transform.Translate(2f, 0, 0);
                    TextHeadingObject.transform.Translate(0.1f, 0, 0);
                }
                else if (tableName == "Table2")
                {
                    gameObj.transform.Translate(-2f, 0, 0);
                    TextHeadingObject.transform.Translate(-0.1f, 0, 0);
                }
                else
                    gameObj.transform.Translate(0, 0, 0);

            }
        }




    }


    public void LoadDataFromAzureTable1()
    {
        List<ColumnData> Column1List = new List<ColumnData>();
        Column1List.Add(new ColumnData("policyID", "varchar"));
        Column1List.Add(new ColumnData("CreatedAt", "DATETIME"));
        Column1List.Add(new ColumnData("ValidUntil", "DATETIME"));
        Column1List.Add(new ColumnData("statecode", "varchar"));
        Column1List.Add(new ColumnData("county", "varchar"));
        Column1List.Add(new ColumnData("eq_site_limit", "FLOAT"));
        Column1List.Add(new ColumnData("hu_site_limit", "FLOAT"));
        Column1List.Add(new ColumnData("fl_site_limit", "FLOAT"));
        Column1List.Add(new ColumnData("fr_site_limit", "FLOAT"));
        Column1List.Add(new ColumnData("tiv_2011", "INTEGER"));
        Column1List.Add(new ColumnData("tiv_2012", "FLOAT"));
        Column1List.Add(new ColumnData("eq_site_deductible", "FLOAT"));
        Column1List.Add(new ColumnData("hu_site_deductible", "FLOAT"));
        Column1List.Add(new ColumnData("fl_site_deductible", "FLOAT"));
        Column1List.Add(new ColumnData("fr_site_deductible", "FLOAT"));
        Column1List.Add(new ColumnData("point_latitude", "DECIMAL"));
        Column1List.Add(new ColumnData("point_longitude", "DECIMAL"));
        Column1List.Add(new ColumnData("line", "varchar"));
        Column1List.Add(new ColumnData("construction", "varchar"));
        Column1List.Add(new ColumnData("point_granularity", "INTEGER"));

        Table1 = new DataTable();
        Table1.TableName = "FL_insurance_data_1";
        Table1.DataColumnList.AddRange(Column1List);


    }

    public void LoadDataFromAzureTable2()
    {
        List<ColumnData> Column2List = new List<ColumnData>();
        Column2List.Add(new ColumnData("policyID", "varchar"));
        Column2List.Add(new ColumnData("statecode", "varchar"));
        Column2List.Add(new ColumnData("county", "varchar"));
        Column2List.Add(new ColumnData("tiv_2011", "FLOAT"));
        Column2List.Add(new ColumnData("tiv_2012", "FLOAT"));
        Column2List.Add(new ColumnData("eq_site_deductible", "FLOAT"));
        Column2List.Add(new ColumnData("CreatedAt", "DATETIME"));
        Column2List.Add(new ColumnData("fl_site_deductible", "FLOAT"));
        Column2List.Add(new ColumnData("fr_site_deductible", "FLOAT"));
        Column2List.Add(new ColumnData("point_latitude", "DECIMAL"));
        Column2List.Add(new ColumnData("ValidUntil", "DATETIME"));
        Column2List.Add(new ColumnData("point_longitude", "DECIMAL"));
        Column2List.Add(new ColumnData("construction", "varchar"));
        Column2List.Add(new ColumnData("point_granularity", "INTEGER"));

        Table2 = new DataTable();
        Table2.TableName = "FL_insurance_data_2";
        Table2.DataColumnList.AddRange(Column2List);
    }

    public void LoadMergedTable()
    {
        if (IsCommonTableEnabled)
        {

            return;
        }
        try
        {


            MergedTable = new DataTable();
            MergedTable.TableName = "Common Columns";
            MergedTable.DataColumnList = new List<ColumnData>();
            MergedTable.DataColumnList = Table1.DataColumnList.Where(a => Table2.DataColumnList.Any(x => x.ColumnName == a.ColumnName && x.ColumnType == a.ColumnType)).ToList();

            List<ColumnData> ColumnList = MergedTable.DataColumnList;
            int noOfRows = MAX_NO_OF_ROWS;
            int noOfColms = ((ColumnList.Count - 1) / noOfRows) + 1;
            GameObject gameObj;

            ObjZcoor = 0.1f;

            int counter = 0;
            int flag = 1;

            GameObject TextHeadingObject = Instantiate(Resources.Load("TableHeader", typeof(GameObject))) as GameObject;
            TextHeadingObject.transform.position = new Vector3(-0.04f, noOfRows * 0.3f, ObjZcoor);//add specified distance
            TextHeadingObject.transform.GetComponent<TextMesh>().text = MergedTable.TableName;
            TextHeadingObject.transform.tag = "commonColumnStuff";




            for (int i = 0; i < noOfColms; i++)
            {

                for (int j = 0; j < noOfRows; j++)
                {
                    if (counter == ColumnList.Count)
                    {
                        break;
                    }
                    switch (ColumnList[counter].ColumnType)
                    {
                        //Add more objects for different types of values
                        case "varchar":
                            gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject1", typeof(GameObject))) as GameObject;
                            break;
                        case "DATETIME":
                            gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject2", typeof(GameObject))) as GameObject;
                            break;
                        case "FLOAT":
                            gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject3", typeof(GameObject))) as GameObject;
                            break;
                        case "INTEGER":
                            gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject4", typeof(GameObject))) as GameObject;
                            break;
                        default:
                            gameObj = Instantiate(Resources.Load("ColumnTypeObjs/ColumnObject4", typeof(GameObject))) as GameObject;
                            break;
                    }

                    gameObj.transform.position = new Vector3(flag * i * .9f, j * 0.3f, ObjZcoor);//add specified distance
                    gameObj.transform.Find("ColumnNameText").GetComponent<TextMesh>().text = ColumnList[counter].ColumnName;
                    counter++;

                    //Scale down objects
                    Vector3 tempSize;
                    tempSize = gameObj.transform.localScale;
                    tempSize.x = 0.8f;
                    tempSize.y = 0.2f;
                    tempSize.z = 0.2f;
                    gameObj.transform.localScale = tempSize;

                    //gameObj.transform.parent = parentObj.transform;

                    //TODO: Find a more elegant way
                    gameObj.transform.Translate(0, 0, 0);

                }
            }
            IsCommonTableEnabled = true;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);

        }
    }



}


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

public class DataTable
{
    public string TableName { get; set; }
    public List<ColumnData> DataColumnList { get; set; }
    public DataTable()
    {
        DataColumnList = new List<ColumnData>();
    }

}

