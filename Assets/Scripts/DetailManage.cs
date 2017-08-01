using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using Academy.HoloToolkit.Unity;

public class DetailManage : MonoBehaviour
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

        // Recommend having only one tagalong.
        GameObject existingDetail = GameObject.FindGameObjectWithTag("BarGraph");
        if (existingDetail != null)
        {
            //existingDetail.SetActive(false);
            return;
        }

        GameObject instantiatedDetail = GameObject.Instantiate(Detail);
        instantiatedDetail.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.85f;
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
        GameObject existingDetail = GameObject.FindGameObjectWithTag("BarGraph");
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
