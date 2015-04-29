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
	bool newTrigger = false;
	bool triggerDown = false;
	bool victory = false;
	
	// Use this for initialization
	void Start () {
		victory = false;
		curWeapon = 0;
		newTrigger = false;
		triggerDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (showRadialMenu.getSelection()){
			//Nothing is selected
			case -1: //Do nothing
				break;
			default:
				//print(showRadialMenu.getSelection()-1);
				curWeapon = showRadialMenu.getSelection()-1;
				break;
		}
		bool newTrigger = Input.GetAxis("Run/Shoot") > 0f;
		if (!victory)
		{
			if (Input.GetButtonDown("Shoot") || (!triggerDown && newTrigger)) {
				FireWeapon(curWeapon);
			}
		}
		triggerDown = newTrigger;
	}
	void FireWeapon(int w)
	{
		GameObject obj;
		if (w == 11)
		{
			gameObject.SendMessage("OnCloak");
		}
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

	void WeaponUpdate()
	{
		curWeapon = showRadialMenu.getSelection()-1;
	}

	void OnVictory()
	{
		victory = true;
	}
}
