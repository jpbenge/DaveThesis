using UnityEngine;
using System.Collections;

public class MovingPlatformYAdjust : MonoBehaviour {

	float yOffset = 0f;
	float lastY = 0f;
	GameObject rider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () {
		if (rider != null)
		{
			if (transform.position.y - lastY > 0)
			{
				
				if (yOffset < 0)
				{
					yOffset = 0;
				}
				//print("adjusting");
				rider.transform.position = new Vector3(rider.transform.position.x,transform.position.y+yOffset,rider.transform.position.z);
			}
		}
		lastY = transform.position.y;
	}

	void OnTriggerEnter(Collider other) {
		//print("rider");
		if (other.gameObject.tag == "Player")
		{
			rider = other.gameObject;
			yOffset = rider.transform.position.y - transform.position.y;
		}
		
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player")
		{
			rider = null;
		}
	}
}
