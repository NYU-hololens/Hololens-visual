﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using Academy.HoloToolkit.Unity;

public class GraphChartManage : MonoBehaviour
{
    public GameObject Detail;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show()
    {
        if (Detail == null)
        {
            return;
        }

		Debug.Log ("Show a graph chart");
			
        // Recommend having only one tagalong.
        GameObject existingDetail = GameObject.FindGameObjectWithTag("GraphChart");
        /*if (existingDetail != null)
        {
            //existingDetail.SetActive(false);
            return;
        }*/

        GameObject instantiatedDetail = GameObject.Instantiate(Detail);
		//instantiatedDetail.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
		instantiatedDetail.transform.position = Camera.main.transform.position - Camera.main.transform.right * 0.75f - Camera.main.transform.up * 0.6f + Camera.main.transform.forward * 2.3f;
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
        GameObject existingDetail = GameObject.FindGameObjectWithTag("GraphChart");
        if (existingDetail != null)
        {
            existingDetail.SetActive(false);
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
