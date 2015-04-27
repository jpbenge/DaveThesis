using UnityEngine;
using System.Collections;

public class CrystalPlatform : MonoBehaviour {

	public AudioClip steamSound;
	public AudioClip lowerSound;
	void LowerPlatform()
	{
		Phase1();
	}

	void Phase1()
	{
		AudioSource.PlayClipAtPoint(steamSound, transform.position,4f);
		Invoke("Phase2",1f);
	}

	void Phase2()
	{
		for (int i = 0;i<3;i++)
		{
			transform.GetChild(i).GetComponent<ParticleEmitter>().emit = true;
		}
		Invoke("Phase3",1f);
	}
	void Phase3()
	{
		for (int i = 3;i<6;i++)
		{
			transform.GetChild(i).GetComponent<ParticleEmitter>().emit = true;
		}
		Invoke("Phase4",2f);
	}
	void Phase4()
	{
		AudioSource.PlayClipAtPoint(lowerSound, transform.position,4f);
		iTween.MoveTo(gameObject,new Vector3(transform.position.x,transform.position.y-3.2f,transform.position.z),5f);
		Invoke("Phase5",5f);
	}
	void Phase5()
	{
		for (int i = 0;i<6;i++)
		{
			transform.GetChild(i).GetComponent<ParticleEmitter>().emit = false;
		}
	}
}
