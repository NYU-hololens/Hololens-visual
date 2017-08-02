using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using Academy.HoloToolkit.Unity;
using System.Linq;

public class ChartManager : MonoBehaviour
{
    // public GameObject Detail;
	private string charTag;
    // Use this for initialization

	// TODO: Remove this once we have a DB working
	private string[] string_col = new string[]{
		"policyID","statecode","county","line","construction"
	};

	private string[] datetime_col = new string[]{
		"ValidUntil", "CreatedAt"
	};

	private string[] num_col = new string[]{
		"eq_site_limit","hu_site_limit","fl_site_limit","fr_site_limit","tiv_2011","tiv_2012","eq_site_deductible","hu_site_deductible","fl_site_deductible", "fr_site_deductible","point_latitude","point_longitude","point_granularity"
	};
	
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show()
    {
		/*
        if (Detail == null)
        {
            return;
        }
        */


		GameObject parent = GameObject.FindGameObjectWithTag("SphereTable1");
		string tableName = parent.tag;
		// Debug.Log("last highlighted column: " + SelectedColumnInfo.getLastColumnName());
		/*
		foreach(string cn in SelectedColumnInfo.getColumnNameSet(tableName))
		{
			 Debug.Log("here " + cn);
		}
		*/
		string lastHighlightedColumn = SelectedColumnInfo.getLastColumnName ();
		if (string_col.Contains (lastHighlightedColumn)) {
			charTag = "BarChart";
			var chartToShow = GameObject.FindObjectOfType (typeof(BarChartManage)) as BarChartManage;
			chartToShow.Show ();
		} else if (datetime_col.Contains (lastHighlightedColumn)) {
			charTag = "GraphChart";
			Debug.Log ("Show a graph chart");
			var chartToShow = GameObject.FindObjectOfType (typeof(GraphChartManage)) as GraphChartManage;
			chartToShow.Show ();
		} else if (num_col.Contains (lastHighlightedColumn)) {
			charTag = "BubbleChart";
			Debug.Log ("Show a bubble chart");
			var chartToShow = GameObject.FindObjectOfType (typeof(BubbleChartManage)) as BubbleChartManage;
			chartToShow.Show ();
		} else {
			Debug.Log ("Chart for target column type not implemented.");
		}
			
		/*
        // Recommend having only one tagalong.
        GameObject existingDetail = GameObject.FindGameObjectWithTag("BarChart");
        if (existingDetail != null)
        {
            //existingDetail.SetActive(false);
            return;
        }


        GameObject instantiatedDetail = GameObject.Instantiate(Detail);
		//instantiatedDetail.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
		instantiatedDetail.transform.position = Camera.main.transform.position - Camera.main.transform.right * 0.75f - Camera.main.transform.up * 0.3f + Camera.main.transform.forward * 2.3f;
        instantiatedDetail.SetActive(true);
        instantiatedDetail.AddComponent<Billboard>();
        instantiatedDetail.AddComponent<SimpleTagalong>();
        /*if (Detail.activeSelf == false)
        {
            Detail.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
            Detail.SetActive(true);
        }
        */

    }

    public void Dismiss()
    {
		// GameObject existingDetail = GameObject.FindGameObjectWithTag(charTag);
        // if (existingDetail != null)
        // {
        //     existingDetail.SetActive(false);
        // }

		if (charTag == "BarChart") {
			var chartToShow = GameObject.FindObjectOfType (typeof(BarChartManage)) as BarChartManage;
			if (chartToShow != null)
				chartToShow.Dismiss ();
		} else if (charTag == "GraphChart") {
			Debug.Log ("graph chart");
			var chartToShow = GameObject.FindObjectOfType (typeof(GraphChartManage)) as GraphChartManage;
			if (chartToShow != null)
				chartToShow.Dismiss ();
		} else if (charTag == "BubbleChart") {
			Debug.Log ("bubble chart");
			var chartToShow = GameObject.FindObjectOfType (typeof(BubbleChartManage)) as BubbleChartManage;
			if (chartToShow != null)
				chartToShow.Dismiss ();
		} else {
			Debug.Log ("Not implemented.");
		}
    }

    /*
    public void OnSelect()
    {
        Detail.GetComponent<MeshRenderer>().material.color = new
            Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f,
            Random.Range(0, 255) / 255f);
    }
    */
}
