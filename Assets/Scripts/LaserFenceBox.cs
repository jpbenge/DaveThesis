using UnityEngine;
using System.Collections;

public class LaserFenceBox : MonoBehaviour {
	public GameObject laserFence;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnExplosion () {
		laserFence.SetActive(false);
	}
}
