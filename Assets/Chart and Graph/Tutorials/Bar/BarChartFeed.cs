using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using ChartAndGraph;

public class BarChartFeed : MonoBehaviour {
	public Material mDefaultMaterial;

	public string key;
	public string value;
	// List<Dictionary<string,object>> finalData;
	List<List<Dictionary<string,object>>> dataSet = new List<List<Dictionary<string, object>>>();

	void Start () {
		// info supports multiple csv reads, for now we just use one
		TextAsset[] info = new TextAsset[1];
		info[0] = Resources.Load("csvs/sample", typeof(TextAsset)) as TextAsset;

		foreach (TextAsset t in info) {
			List<Dictionary<string,object>> data = TextReader.Read (t.text);
			dataSet.Add (data);
		}


        BarChart chart = GetComponent<BarChart>();
		// BarChart barChart = GetComponent<BarChart>();
        if (chart != null)
        {
			/*
            barChart.DataSource.SetValue("Player 1", "Value 1", Random.value * 20);
            barChart.DataSource.SlideValue("Player 2", "Value 1", Random.value * 20, 40f);
			barChart.DataSource.SlideValue("Player 3", "Value 2", Random.value * 20, 40f);
			*/
			chart.DataSource.AddGroup ("test1");
			for (var i = 0; i < dataSet[0].Count; i++) {
				if (mDefaultMaterial == null) {
					mDefaultMaterial = new Material (Shader.Find ("Standard"));
					mDefaultMaterial.color = Color.blue;
				}
				chart.DataSource.AddCategory (dataSet [0] [i] [key].ToString(), mDefaultMaterial);
				double result = 0;
				double.TryParse (dataSet [0] [i] [value].ToString(), out result);
				chart.DataSource.SetValue(dataSet [0] [i][key].ToString(), "test1", result);
			}
			chart.DataSource.AddGroup ("test2");
			for (var i = 0; i < dataSet[0].Count; i++) {
				if (mDefaultMaterial == null) {
					mDefaultMaterial = new Material (Shader.Find ("Standard"));
					mDefaultMaterial.color = Color.red;
				}
				chart.DataSource.AddCategory (dataSet [0] [i] [key].ToString(), mDefaultMaterial);
				double result = 0;
				double.TryParse (dataSet [0] [i] [value].ToString(), out result);
				chart.DataSource.SetValue(dataSet [0] [i][key].ToString(), "test2", result);
			}
        }
    }
    private void Update()
    {
    }
}
