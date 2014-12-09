﻿using UnityEngine;
using System.Collections;

public class PlayerStatusManager : MonoBehaviour {

	public GUISkin gSkin;
	public float baseWidth = 1920f;
	public float baseHeight = 1200f;
	Vector2 UIScale;

	int numKeyCards;
	public int keyCardGoal = 5;
	public GameObject spawnPoint;
	public GameObject mCam;
	public Texture2D[] healthImages;
	public int maxHealth = 100;
	public int curHealth;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
		numKeyCards = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGetKeyCard()
	{
		numKeyCards += 1;
		print(numKeyCards);
	}

	void OnGUI()
	{
		GUI.skin = gSkin;
		UIScale = new Vector2(Screen.width / baseWidth, Screen.height / baseHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (UIScale.x, UIScale.y, 1));
		GUI.Label(new Rect(1550,1075,100,50),""+numKeyCards);
		if (curHealth == maxHealth)
		{
			GUI.DrawTexture(new Rect(8,886,168,168),healthImages[5]);
		}
		else if (curHealth >= maxHealth*(5f/6f))
		{
			GUI.DrawTexture(new Rect(8,886,168,168),healthImages[4]);
		}
		else if (curHealth >= maxHealth*(2f/3f))
		{
			GUI.DrawTexture(new Rect(8,886,168,168),healthImages[3]);
		}
		else if (curHealth >= maxHealth*0.5f)
		{
			GUI.DrawTexture(new Rect(8,886,168,168),healthImages[2]);
		}
		else if (curHealth >= maxHealth*(1f/3f))
		{
			GUI.DrawTexture(new Rect(8,886,168,168),healthImages[1]);
		}
		else if (curHealth > 0)
		{
			GUI.DrawTexture(new Rect(8,886,168,168),healthImages[0]);
		}
	}

	void OnHit(int dmg)
	{
		curHealth -= dmg;
		if (curHealth <= 0)
		{
			OnDeath();
		}
	}

	void OnDeath()
	{
		mCam.SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
		transform.position = spawnPoint.transform.position;
		Respawn();
	}

	void Respawn()
	{
		curHealth = maxHealth;
	}
}
