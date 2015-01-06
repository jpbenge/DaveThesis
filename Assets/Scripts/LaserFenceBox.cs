using UnityEngine;
using System.Collections;

public class LaserFenceBox : MonoBehaviour {
	public GameObject laserFence;
	public AudioClip sound;
	public float soundVolume = 1f;
	public Texture2D damageTex;
	public Texture2D damageNorm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnExplosion () {
		print("Splode");
		laserFence.SetActive(false);

		if (sound)
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		if (damageTex)
			renderer.material.SetTexture("_MainTex", damageTex);
		if (damageNorm)
			renderer.material.SetTexture("_BumpMap", damageNorm);
	}
}
