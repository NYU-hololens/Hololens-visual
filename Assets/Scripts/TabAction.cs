using UnityEngine;
using Academy.HoloToolkit.Unity;
using System.Collections;

public class TabAction : MonoBehaviour
{
    public GameObject Detail;
    // Use this for initialization  
    private Material[] defaultMaterials;
    void Start()
    {
        defaultMaterials = GetComponent<Renderer>().materials;
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
        instantiatedDetail.AddComponent<Billboard>();
        instantiatedDetail.AddComponent<SimpleTagalong>();
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            defaultMaterials[i].SetFloat("_Highlight", .5f);
        }

    }
}