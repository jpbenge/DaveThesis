using UnityEngine;
using System.Collections;

public class PlayerWeaponManager : MonoBehaviour {
	
	public GameObject[] weapons;
	public int curWeapon;
	
	// Use this for initialization
	void Start () {
		curWeapon = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(1))
		{
			switch (showRadialMenu.getSelection()){
				//Nothing is selected
				case -1: //Do nothing
						 break;
				default: 
						print(showRadialMenu.getSelection()-1);
						curWeapon = showRadialMenu.getSelection()-1;
						break;
			}
		}
	}
}
