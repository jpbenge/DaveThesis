using UnityEngine;
using System.Collections;

public class ColdFanGroup : MonoBehaviour {
	public FloorState[] floors;
	public float refreezeTime = 12f;
	bool enabled = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled)
		{
			foreach(FloorState floor in floors)
			{
				if (floor.floorState != FloorState.FState.Ice && !floor.IsInvoking("GoToIce"))
				{
					floor.Invoke("GoToIce",refreezeTime);
				}
			}
		}
	}

	void OnTerminalActivate()
	{
		enabled = true;
		foreach (Transform fan in transform)
		{
			fan.gameObject.GetComponent<Animation>().Play();
			if (fan.gameObject.audio != null)
			{
				fan.gameObject.audio.Play();
			}
			fan.SendMessage("OnTerminalActivate", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTerminalDeactivate()
	{
		foreach(FloorState floor in floors)
			{
				floor.CancelInvoke();
			}
		enabled = false;
		foreach (Transform fan in transform)
		{
			fan.gameObject.GetComponent<Animation>().Stop();
			if (fan.gameObject.audio != null)
			{
				fan.gameObject.audio.Stop();
			}
			fan.gameObject.SendMessage("OnTerminalDeactivate", SendMessageOptions.DontRequireReceiver);
		}
	}
}
