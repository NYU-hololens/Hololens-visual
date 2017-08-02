using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using ChartAndGraph;


public class LargeDataLogic : MonoBehaviour, IComparer<DoubleVector2> {
	public Material mDefaultMaterial;
	public string[] col_name = new string[]{
		"Average Value Weighted Returns -- Daily\n ,SMALL LoBM,ME1 BM2,ME1 BM3,ME1 BM4,SMALL HiBM,ME2 BM1,ME2 " +
		"BM2,ME2 BM3,ME2 BM4,ME2 BM5,ME3 BM1,ME3 BM2,ME3 BM3,ME3 BM4,ME3 BM5,ME4 BM1,ME4 BM2,ME4 BM3,ME4 BM4," +
		"ME4 BM5,BIG LoBM,ME5 BM2,ME5 BM3,ME5 BM4,BIG HiBM"};
	public string primaryKey = "Average Value Weighted Returns -- Daily";
	public string value = "BM4";
	List<Dictionary<string,object>> finalData;
	List<List<Dictionary<string,object>>> dataSet = new List<List<Dictionary<string, object>>>();
	List<GameObject> points = new List<GameObject>();

	// Use this for initialization
	List<DoubleVector2> mData = new List<DoubleVector2>();
	double pageSize = 50f;
	double currentPagePosition = 0.0;
	GraphChartBase graph;

	void Start () {
		TextAsset[] info = new TextAsset[1];
		info[0] = Resources.Load("csvs/Global_25_Portfolios_ME_BE-ME_Daily", typeof(TextAsset)) as TextAsset;

		foreach (TextAsset t in info) {
			List<Dictionary<string,object>> data = TextReader.Read (t.text);
			dataSet.Add (data);
		}

		// chart.DataSource.AddGroup ("test1");
		/*
		for (var i = 0; i < dataSet[0].Count; i++) {
			// System.Diagnostics.Debug.WriteLine(dataSet[0][i]);
			// Debug.Log (dataSet [0] [i]["policyID"]);
			if (mDefaultMaterial == null) {
				mDefaultMaterial = new Material (Shader.Find ("Standard"));
				mDefaultMaterial.color = Color.blue;
			}
			chart.DataSource.AddCategory (dataSet [0] [i] [primaryKey].ToString(), mDefaultMaterial);
			double result = 0;
			double.TryParse (dataSet [0] [i] [value].ToString(), out result);
			chart.DataSource.SetValue(dataSet [0] [i][primaryKey].ToString(), "test1", result);
		}
		*/
        
		GraphChartBase graph = GetComponent<GraphChartBase>();
		double x = 0f;
		for (int i = 0; i < 250000; i++)    // initialize with random data
		{
			double.TryParse (dataSet [0] [i] [value].ToString(), out x);
			mData.Add(new DoubleVector2(x, UnityEngine.Random.value));
			x += UnityEngine.Random.value * 10f;
		}
		LoadPage(currentPagePosition); // load the page at position 0
	}

	int FindClosestIndex(double position) // if you want to know what is index is currently displayed . use binary search to find it
	{
		//NOTE :: this method assumes your data is sorted !!! 
		int res = mData.BinarySearch(new DoubleVector2(position, 0.0), this);
		if (res >= 0)
			return res;
		return ~res;
	}


	void findPointsForPage(double position, out int start, out int end) // given a page position , find the right most and left most indices in the data for that page. 
	{
		int index = FindClosestIndex(position);
		int i = index;
		double endPosition = position + pageSize;
		double startPosition = position - pageSize;

		//starting from the current index , we find the page boundries
		for (start = index; start > 0; start--)
		{
			if (mData[i].x < startPosition) // take the first point that is out of the page. so the graph doesn't break at the edge
				break;
		}
		for (end = index; end < mData.Count; end++)
		{
			if (mData[i].x > endPosition) // take the first point that is out of the page
				break;
		}
	}
	private void Update()
	{
		if (graph != null)
		{
			//check the scrolling position of the graph. if we are past the view size , load a new page
			double pageStartThreshold = currentPagePosition - pageSize;
			double pageEndThreshold = currentPagePosition + pageSize - graph.DataSource.HorizontalViewSize;
			if (graph.HorizontalScrolling < pageStartThreshold || graph.HorizontalScrolling > pageEndThreshold)
			{
				LoadPage(graph.HorizontalScrolling);
			}
		}
	}
	void LoadPage(double pagePosition)
	{

		if (graph != null)
		{

			Debug.Log("Loading page :" + pagePosition);
			graph.DataSource.StartBatch(); // call start batch 
			graph.DataSource.HorizontalViewOrigin = 0;
			int start, end;
			findPointsForPage(pagePosition, out start, out end); // get the page edges
			graph.DataSource.ClearCategory("Player 1"); // clear the cateogry
			for (int i = start; i < end; i++) // load the data
				graph.DataSource.AddPointToCategory("Player 1", mData[i].x, mData[i].y);
			graph.DataSource.EndBatch();
			graph.HorizontalScrolling = pagePosition;
		}
		currentPagePosition = pagePosition;
	}

	public int Compare(DoubleVector2 x, DoubleVector2 y)
	{
		if (x.x < y.x)
			return -1;
		if (x.x < y.x)
			return 1;
		return 0;
	}
}
