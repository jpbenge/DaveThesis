using UnityEngine;
using System.Collections;

public class Ice_Freeze : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Freeze () {
		collider.isTrigger = false;
		print("freeze");
	}
}
