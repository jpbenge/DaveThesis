using UnityEngine;
using System.Collections;

public class RespawnBounds : MonoBehaviour {

	public GameObject spawnPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
		{
			other.GetComponent<PlayerStatusManager>().spawnPoint = spawnPoint;
		}
	}
}
