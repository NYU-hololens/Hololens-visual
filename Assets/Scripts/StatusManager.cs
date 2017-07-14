using UnityEngine.VR.WSA.Input;
using UnityEngine.UI;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	GestureRecognizer recognizer;

	public Text curr_status;

	// Use this for initialization
	void Start () {
		recognizer = new GestureRecognizer();

		recognizer.TappedEvent += Recognizer_TappedEvent;

		recognizer.StartCapturingGestures();
	}

	private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
	{
		curr_status.text = "Table";
	}
}