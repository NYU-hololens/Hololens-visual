using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ExistingDBScript : MonoBehaviour {

	public Text DebugText;

	// Use this for initialization
	void Start () {
		var ds = new DataService ("mainsql.db");
		var rows = ds.GetRows ();
        // ToConsole(people);
        rows = ds.GetPersonsNamedRoberto ();
        ToConsole(rows);
	}
	
	private void ToConsole(IEnumerable<FL_insurance_sample_test1> rows){
		foreach (var row in rows) {
			// ToConsole(person.ToString());
            Debug.Log(row.ToString());
        }
	}

	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}

}
