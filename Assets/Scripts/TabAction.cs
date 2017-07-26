using UnityEngine;
using System.Collections;

public class TabAction : MonoBehaviour
{
    public GameObject Detail;
    // Use this for initialization  
    void Start()
    {
    }

    // Update is called once per frame  
    void Update()
    {

    }


    void OnTap()
    {
        if (Detail == null)
        {
            return;
        }

        // Recommend having only one tagalong.
        GameObject existingDetail = GameObject.FindGameObjectWithTag("Detail");
        if (existingDetail != null)
        {
            existingDetail.SetActive(false);
            return;
        }

        GameObject instantiatedDetail = GameObject.Instantiate(Detail);

        instantiatedDetail.SetActive(true);

    }
}