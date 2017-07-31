using UnityEngine;
using System.Collections;
using ChartAndGraph;

public class BarChartFeed : MonoBehaviour {

	public string[] col_name = new string[]{
	"policyID,statecode,county,eq_site_limit,hu_site_limit,fl_site_limit,fr_site_limit,tiv_2011,tiv_2012,eq_site_deductible,hu_site_deductible,fl_site_deductible," +
	"fr_site_deductible,point_latitude,point_longitude,line,construction,point_granularity"};
	
	void Start () {
        BarChart barChart = GetComponent<BarChart>();
        if (barChart != null)
        {
			// barChart.DataSource.
			barChart.DataSource.SetValue("eq_site_limit", "Value1", 1000);
			barChart.DataSource.SetValue("hu_site_limit", "Value1", 1000);
			barChart.DataSource.SetValue("fl_site_limit", "Value1", 16425);
			barChart.DataSource.SetValue("fr_site_limit", "Value1", 1000);
			// barChart.DataSource.SlideValue("Player 2", "Value 1", Random.value * 20, 40f);
			// barChart.DataSource.SlideValue("Player2", "Value1", 40, 40f);
        }
    }
    private void Update()
    {
    }
}
