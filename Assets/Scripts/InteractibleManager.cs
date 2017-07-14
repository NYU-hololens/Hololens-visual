using Academy.HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// InteractibleManager keeps tracks of which GameObject
/// is currently in focus.
/// </summary>
public class InteractibleManager : Singleton<InteractibleManager>
{
    public GameObject FocusedGameObject { get; private set; }
	public Text ObjectName;
	public Text col;
	public Text row;

    private GameObject oldFocusedGameObject = null;

    void Start()
    {
        FocusedGameObject = null;
    }

    void Update()
    {
        oldFocusedGameObject = FocusedGameObject;

        if (GazeManager.Instance.Hit)
        {
            RaycastHit hitInfo = GazeManager.Instance.HitInfo;
            if (hitInfo.collider != null)
            {
                FocusedGameObject = hitInfo.collider.gameObject;
				ObjectName.text = FocusedGameObject.name;
				if (ObjectName.text.Equals ("SphereTable1")) {
					row.text = FocusedGameObject.GetComponent<TableScript1>().row.ToString();
					col.text = FocusedGameObject.GetComponent<TableScript1>().column.ToString();
				}
				else if (ObjectName.text.Equals ("SphereTable2")) {
					row.text = FocusedGameObject.GetComponent<TableScript2>().row.ToString();
					col.text = FocusedGameObject.GetComponent<TableScript2>().column.ToString();
				}

            }
            else
            {
                FocusedGameObject = null;
            }
        }
        else
        {
			ObjectName.text = "null";
			col.text = "";
			row.text = "";
	
            FocusedGameObject = null;
        }

        if (FocusedGameObject != oldFocusedGameObject)
        {
            ResetFocusedInteractible();

            if (FocusedGameObject != null)
            {
                if (FocusedGameObject.GetComponent<Interactible>() != null)
                {
                    FocusedGameObject.SendMessage("GazeEntered");
                }
            }
        }
    }

    private void ResetFocusedInteractible()
    {
        if (oldFocusedGameObject != null)
        {
            if (oldFocusedGameObject.GetComponent<Interactible>() != null)
            {
                oldFocusedGameObject.SendMessage("GazeExited");
            }
        }
    }
}