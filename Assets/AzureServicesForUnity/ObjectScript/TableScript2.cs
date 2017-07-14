using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzureServicesForUnity;
using AzureServicesForUnity.Shared;
using AzureServicesForUnity.AppService;

public class TableScript2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string filterquery = null;
		bool includeTotalCount = true;
		TableQuery tq = new TableQuery();
		tq.filter = filterquery;
		tq.orderBy = "score";
		tq.inlineCount = includeTotalCount;

		EasyTablesClient.Instance.SelectFiltered<TableB>(tq, x =>
			{
				if (x.Status == CallBackResult.Success)
				{
					foreach (var item in x.Result.results)
					{
						if (Globals.DebugFlag) Debug.Log(string.Format("ID is {0},score is {1},name is {2}", item.id, item.score, item.Name ));
					}
					if (includeTotalCount)
					{
						float number = x.Result.count*0.1F+1;
						transform.localScale = new Vector3 (number, number, number);
						Debug.Log(string.Format("Number of rows: {0}", x.Result.count));
					}
					else
					{
						//StatusText.text = string.Format("Brought {0} rows", x.Result.results.Count());
					}
				}
				else
				{
					// ShowError(x.Exception.Message);
				}
			});
		// StatusText.text = "Loading...";

	}
		

	
	// Update is called once per frame
	void Update () {
	}
		
}
