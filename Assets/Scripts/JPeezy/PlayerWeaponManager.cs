using UnityEngine;
using System.Collections;

public class PlayerWeaponManager : MonoBehaviour {
	
	public GameObject[] weapons;
	public AudioClip[] weaponSounds;
	public float[] weaponShootForce;
	public float weaponVolume = 1;
	public int curWeapon;
	public Transform weaponSpawnPoint;
	public Transform wileySpawnPoint;
	
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


		if (Input.GetButtonDown("Fire1"))
		{
			FireWeapon(curWeapon);
		}
	}
	void FireWeapon(int w)
	{
		GameObject obj;
		if (w == 12)
		{
			obj = (GameObject)Instantiate(weapons[w], wileySpawnPoint.position, Quaternion.identity);
		}
		else
		{
			obj = (GameObject)Instantiate(weapons[w], weaponSpawnPoint.position, Quaternion.identity);
		}
		obj.rigidbody.AddForce(transform.forward * weaponShootForce[w]);
		if (weaponSounds[w] != null)
		{
			AudioSource.PlayClipAtPoint(weaponSounds[w], transform.position, weaponVolume);
		}
	}
}
