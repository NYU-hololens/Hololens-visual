using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class Logic : MonoBehaviour {


	List<Dictionary<string,object>> finalData;
	List<List<Dictionary<string,object>>> dataSet = new List<List<Dictionary<string, object>>>();
	List<GameObject> points = new List<GameObject>();

	// Use this for initialization
	void Start () {
		/*
        // string startPath = Directory.GetParent(Directory.GetParent (Application.dataPath).FullName).FullName;
        string startPath = Directory.GetParent (Application.dataPath).FullName;
		// string startPath = Directory.GetParent(Directory.GetParent (Application.dataPath).FullName).FullName;
		string newPath = Path.Combine (startPath, "Data\\csvs");
        //GameObject.Find ("debug").GetComponent<Text> ().text = newPath;
        DirectoryInfo dir = new DirectoryInfo (newPath);
		FileInfo[] info = dir.GetFiles("*.csv*");
		*/
		TextAsset[] info = new TextAsset[1];


		info[0] = Resources.Load("csvs/sample", typeof(TextAsset)) as TextAsset;
		//info[1] = Resources.Load("csvs/1", typeof(TextAsset)) as TextAsset;
		//info[2] = Resources.Load("csvs/2", typeof(TextAsset)) as TextAsset;
		//info[3] = Resources.Load("csvs/3", typeof(TextAsset)) as TextAsset;
		//info[4] = Resources.Load("csvs/4", typeof(TextAsset)) as TextAsset;

		// info[0] = Resources.Load("csvs/sample", typeof(TextAsset)) as TextAsset;


		//Debug.Log (csvfile.text);
		//System.Diagnostics.Debug.WriteLine (csvfile.text);

		foreach (TextAsset t in info) {
			List<Dictionary<string,object>> data = TextReader.Read (t.text);
			dataSet.Add (data);
		}

		Dictionary<object,Color> labelColors = new Dictionary<object, Color> ();
		for (var i = 0; i < dataSet[0].Count; i++) {
			GameObject point = (GameObject)Instantiate(Resources.Load("trainPoint"));
            System.Diagnostics.Debug.WriteLine(i);
            /*if (labelColors.ContainsKey (dataSet[0] [i] ["label"])) {
				point.GetComponent<Renderer> ().material.color = labelColors [dataSet[0] [i] ["label"]];
			} else {
				labelColors.Add(dataSet[0] [i] ["label"],new Color(Random.value,Random.value,Random.value,1));
				point.GetComponent<Renderer> ().material.color = labelColors [dataSet[0] [i] ["label"]];
			}*/
            point.transform.localScale =  new Vector3(2.5f,2.5f,2.5f);
			// point.transform.position = new Vector3(dataSet[0][i]["x"], dataSet[0][i]["y"], dataSet[0][i]["z"]);
			/*
			Debug.Log(dataSet[0][i]["point_latitude"]);
			Debug.Log(dataSet[0][i]["point_longitude"]);
			Debug.Log(dataSet[0][i]["point_longitude"]);
			object finalvalue = dataSet[0][i]["point_longitude"];
			float f=(float)dataSet[0][i]["point_longitude"];
			*/
			// float.TryParse(finalvalue, out f);
			// point.transform.position = new Vector3((float)dataSet[0][i]["point_latitude"]/10, (float)dataSet[0][i]["point_longitude"]/10, f);
			point.transform.position = new Vector3((float)dataSet[0][i]["x"], (float)dataSet[0][i]["y"], (float)dataSet[0][i]["x"]);
			points.Add (point);
		}
        
	}
	
	// Update is called once per frame

	void Update () {
		/*
		int currentGoal = ((int)Time.fixedTime / 2) - 1;
		if (currentGoal > dataSet.Count -1) {
			currentGoal = dataSet.Count -1;
		}
		if (currentGoal < 0) {
			currentGoal = 0;
		}*/

        int currentGoal = ((int)Time.fixedTime) % 5;

        finalData = dataSet [currentGoal];
		for (var i = 0; i < dataSet[0].Count; i++) {
			float deltaPositionX = ((float)finalData [i] ["x"] - (float)points[i].transform.position.x) * (Time.deltaTime);
			float deltaPositionY = ((float)finalData [i] ["y"] - (float)points[i].transform.position.y) * (Time.deltaTime);
			float deltaPositionZ = ((float)finalData [i] ["z"] - (float)points[i].transform.position.z) * (Time.deltaTime);
			points [i].transform.position = new Vector3((float)points [i].transform.position.x + deltaPositionX, (float)points [i].transform.position.y + deltaPositionY , (float)points [i].transform.position.z + deltaPositionZ);
		}
    }
}
