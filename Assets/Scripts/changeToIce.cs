using UnityEngine;
using System.Collections;

public class changeToIce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.SetFloat("_blend",(Mathf.Sin(Time.time)+1)/2);
	}
}
