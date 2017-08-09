using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class Collide : MonoBehaviour {

    private float x;
    private float y;
    private float z;
    private bool isOver = true;
    private float speed = 0.2f;
    private float xx, yy, zz;
    private static bool isCollided = false;
    private float similarity;
    // Use this for initialization
    private bool isTriggered;
	void Start () {
        Debug.Log(x + " " + y + " " + z);
        isTriggered = false;
        if (gameObject.tag == "100") similarity = 1.0f;
        else if (gameObject.tag == "50") similarity = .5f;
        else similarity = .0f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (isTriggered && !HandDraggable.getDraggingState())
        {
            MoveTo(new Vector3(xx, yy, zz));
        }
	}
    

    void OnTriggerEnter(Collider collider)
    {
        isOver = false;
        
        isTriggered = true;
        x = gameObject.GetComponent<Transform>().position.x;
        y = gameObject.GetComponent<Transform>().position.y;
        z = gameObject.GetComponent<Transform>().position.z;
        xx = collider.gameObject.GetComponent<Transform>().position.x;
        yy = collider.gameObject.GetComponent<Transform>().position.y;
        zz = collider.gameObject.GetComponent<Transform>().position.z;
        xx += (1 - similarity) * (x - xx);
        yy += (1 - similarity) * (y - yy);
        zz += (1 - similarity) * (z - zz);
        isCollided = true;
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider collider)
    {
        isCollided = false;
        Debug.Log("Exit");
    }

    /*void OnTriggerStay(Collider collider)
    {
        if (!HandDraggable.getDraggingState())
        {
            isOver = false;
            float similarity = 0.6f;
            float xx = collider.gameObject.GetComponent<Transform>().position.x;
            float yy = collider.gameObject.GetComponent<Transform>().position.y;
            float zz = collider.gameObject.GetComponent<Transform>().position.z;
            xx += (1-similarity) * (x - xx);
            yy += (1-similarity) * (y - yy);
            zz += (1-similarity) * (z - zz);
            Debug.Log(collider.gameObject.GetComponent<Transform>().position.x);
            MoveTo(new Vector3(xx, yy, zz));
            //gameObject.GetComponent<Transform>().position = new Vector3(xx, yy, zz);
        }
        
        Debug.Log("Stay");
    }
    */

    private void MoveTo(Vector3 tar)
    {
        if (!isOver)
        {
            Vector3 offSet = tar - transform.position;
            transform.position += offSet.normalized * speed * Time.deltaTime;
            if (Vector3.Distance(tar, transform.position) < 0.005f)
            {
                isOver = true;
                transform.position = tar;
                Collide collide;
                collide = gameObject.GetComponent<Collide>();
                collide.enabled = false;
            }
        }

    }

    public static bool getCollideState()
    {
        return isCollided;
    }
}
