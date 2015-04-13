using UnityEngine;
using System.Collections;

public class OpenDoors : MonoBehaviour {

	// To open and close doors via Inspector
	public bool Open_Doors;
	public bool Close_Doors;

	// Once the doors has been opened they can be closed again
	private bool door_opened;


	public GameObject BottomDoors;
	public GameObject TopDoors;

	// Store original position of top and bottom doors
	public Vector3 TopDoorsOriginPosition;
	public Vector3 BottomDoorsOriginPosition;

	void Awake()
	{
		TopDoorsOriginPosition = TopDoors.transform.localPosition;
		BottomDoorsOriginPosition = BottomDoors.transform.localPosition;
	}

	void Start() {
		if (Open_Doors)
		{
			OpenSciFiDoors();
		}
	}
	// Update is called once per frame
	void Update () {

	}


	void OpenSciFiDoors()
	{	
		Hashtable h1 = new Hashtable();
		h1.Add("position",new Vector3(TopDoorsOriginPosition.x+35,TopDoorsOriginPosition.y,TopDoorsOriginPosition.z));
		h1.Add("islocal",true);
		h1.Add("time",3f);
		Hashtable h2 = new Hashtable();
		h2.Add("position",new Vector3(BottomDoorsOriginPosition.x+35,BottomDoorsOriginPosition.y,BottomDoorsOriginPosition.z));
		h2.Add("islocal",true);
		h2.Add("time",3f);
		iTween.MoveTo(TopDoors,h1);
		iTween.MoveTo(BottomDoors,h2);
	}

	void CloseSciFiDoors()
	{
		Hashtable h1 = new Hashtable();
		h1.Add("position",TopDoorsOriginPosition);
		h1.Add("islocal",true);
		h1.Add("time",1f);
		Hashtable h2 = new Hashtable();
		h2.Add("position",BottomDoorsOriginPosition);
		h2.Add("islocal",true);
		h2.Add("time",1f);
		iTween.MoveTo(TopDoors,h1);
		iTween.MoveTo(BottomDoors,h2);
	}

	void OnTerminalActivate()
	{
		OpenSciFiDoors();
	}
	void OnTerminalDeactivate()
	{
		CloseSciFiDoors();
	}
}
