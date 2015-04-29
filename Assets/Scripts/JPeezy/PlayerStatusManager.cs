using UnityEngine;
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
	public Texture2D[] WeaponImages;
	public int maxHealth = 100;
	public int curHealth;
	PlayerWeaponManager wManager;
	bool victory = false;
	public AudioClip deathSound;
	public AudioClip respawnSound;
	public AudioClip victoryMusic;
	public GameObject shockParticles;

	// Use this for initialization
	void Start () {
		victory = false;
		curHealth = maxHealth;
		numKeyCards = 0;
		wManager = GetComponent<PlayerWeaponManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (victory && Input.GetButtonDown("Submit"))
		{
			CancelInvoke();
			LoadTitle();
		}
	}

	void OnGetKeyCard()
	{
		numKeyCards += 1;
		print(numKeyCards);
	}

	void RemoveKeyCard()
	{
		if (numKeyCards > 0)
		{
			numKeyCards -= 1;
		}
	}
	public int GetNumKeyCards()
	{
		return numKeyCards;
	}

	void OnGUI()
	{
		GUI.skin = gSkin;
		UIScale = new Vector2(Screen.width / baseWidth, Screen.height / baseHeight);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (UIScale.x, UIScale.y, 1));
		if (!victory)
		{
			GUI.Label(new Rect(1550,1075,100,50),""+numKeyCards);
			if (curHealth == maxHealth)
			{
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[5]);
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[5]);
			}
			else if (curHealth >= maxHealth*(5f/6f))
			{
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[4]);
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[4]);
			}
			else if (curHealth >= maxHealth*(2f/3f))
			{
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[3]);
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[3]);
			}
			else if (curHealth >= maxHealth*0.5f)
			{
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[2]);
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[2]);
			}
			else if (curHealth >= maxHealth*(1f/3f))
			{
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[1]);
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[1]);
			}
			else if (curHealth > 0)
			{
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[0]);
				GUI.DrawTexture(new Rect(8,886,168,168),healthImages[0]);
			}
			GUI.DrawTexture(new Rect(375,1010,120,120),WeaponImages[wManager.curWeapon]);
		}
		else //victory
		{

		}
	}

	void OnVictory()
	{
		victory = true;
		Camera.main.SendMessage("OnVictory");
		Camera.main.GetComponent<AudioSource>().clip = victoryMusic;
		Camera.main.GetComponent<AudioSource>().Play();
		Invoke("LoadTitle",25f);	
	}
	void LoadTitle()
	{
		Application.LoadLevel("title");
	}

	void OnHit(int dmg)
	{
		curHealth -= dmg;
		if (curHealth <= 0)
		{
			OnDeath();
		}
	}

	void OnHealthPickup(int amt)
	{
		if (curHealth + amt <= maxHealth)
		{
			curHealth += amt;
		}
		else
		{
			curHealth = maxHealth;
		}
	}

	void OnDeath()
	{
		mCam.SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
		transform.localEulerAngles = spawnPoint.transform.localEulerAngles;
		transform.position = spawnPoint.transform.position;
		if (deathSound)
		{
			audio.clip = deathSound;
			audio.Play();
		}
		Respawn();
	}

	void Respawn()
	{
		curHealth = maxHealth;
		if (respawnSound)
		{
			AudioSource.PlayClipAtPoint(respawnSound,transform.position);
		}
	}

	void OnCameraShock ()
	{
		GameObject clone = (GameObject)Instantiate(shockParticles, new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z), Quaternion.identity);
		clone.transform.parent = transform;
		Vector3 slamDir = -transform.forward;
		slamDir = new Vector3(slamDir.x*2, slamDir.y*5, slamDir.z*2);
		gameObject.SendMessage("Slam", slamDir);
		OnHit(10);
	}
}
