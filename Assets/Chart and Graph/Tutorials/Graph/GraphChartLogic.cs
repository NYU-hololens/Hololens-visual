using UnityEngine;
using ChartAndGraph;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;

public class GraphChartLogic : MonoBehaviour
{
	List<Dictionary<string,object>> finalData;
	List<List<Dictionary<string,object>>> dataSet = new List<List<Dictionary<string, object>>>();
	public string primaryKey = "AVWR_Daily";
	public string value = "ME1_BM2";
	void Start ()
    {
		TextAsset[] info = new TextAsset[1];
		info[0] = Resources.Load("csvs/Global_25_Portfolios_ME_BE-ME_Daily", typeof(TextAsset)) as TextAsset;

		foreach (TextAsset t in info) {
			List<Dictionary<string,object>> data = TextReader.Read (t.text);
			// Debug.Log (t.text);
			dataSet.Add (data);
		}

		foreach (object key in dataSet[0][0].Keys) {
			Debug.Log (key.ToString());
		}
		// Debug.Log (dataSet [0] [0] [value].GetType());

        GraphChartBase graph = GetComponent<GraphChartBase>();

        if (graph != null)
        {
			graph.DataSource.StartBatch();
			graph.DataSource.ClearCategory("Player 1");
			// graph.DataSource.ClearAndMakeBezierCurve("Player 2");
			for (int i = 0; i <30; i++)
			{
				// DateTime dt;
				double dt;
				double.TryParse(dataSet [0] [i] ["AVWR_Daily"].ToString(), out dt);
				// DateTime.TryParseExact(dataSet [0] [i] ["AVWR_Daily"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
				// string formattedDateTime = dt.ToString("yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);
				// graph.DataSource.AddPointToCategory("Player 1", formattedDateTime, UnityEngine.Random.value);
				double val;
				double.TryParse(dataSet [0] [i] ["ME1_BM2"].ToString(), out val);
				graph.DataSource.AddPointToCategory("Player 1", dt, val*100f);
				// graph.DataSource.AddPointToCategory("Player 1", dt, UnityEngine.Random.value*10f + 20f);
				// graph.DataSource.AddPointToCategory("Player 1",UnityEngine.Random.value*10f, UnityEngine.Random.value*10f + 20f);
				/*if (i == 0)
					graph.DataSource.SetCurveInitialPoint("Player 2",0f, UnityEngine.Random.value * 10f + 10f);
				else
					graph.DataSource.AddLinearCurveToCategory("Player 2", 
						new DoubleVector2(i * 10f/30f, UnityEngine.Random.value * 10f + 10f));
						*/
			}

			// graph.DataSource.MakeCurveCategorySmooth("Player 2");
			graph.DataSource.EndBatch();
			/*
            graph.DataSource.StartBatch();
            graph.DataSource.ClearCategory("Player 1");
            // graph.DataSource.ClearAndMakeBezierCurve("Player 2");
            for (int i = 0; i <30; i++)
            {
				DateTime date;
				// DateTime.TryParse (dataSet [0] [i] [primaryKey].ToString (), out date);
				double result = 0;
				double.TryParse(dataSet [0] [i] ["AVWR_Daily"].ToString(), out result);
				// double.TryParse (dataSet [0] [i] [value].ToString(), out result);
				// graph.DataSource.AddPointToCategory(
				// Debug.Log (result);
				graph.DataSource.AddPointToCategory("Player 1", result, UnityEngine.Random.value*1f + 2f, 5);

                if (i == 0)
					graph.DataSource.SetCurveInitialPoint("Player 2",0f, UnityEngine.Random.value * 1f + 1f);
                else
                    graph.DataSource.AddLinearCurveToCategory("Player 2", 
						new DoubleVector2(i * 10f/3f, UnityEngine.Random.value * 10f + 1f));

            }

            graph.DataSource.MakeCurveCategorySmooth("Player 2");
            graph.DataSource.EndBatch();
            */
        }
    }
}
