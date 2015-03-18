using UnityEngine;
using System.Collections;

public class H20Extinguish : MonoBehaviour {

	float startTime = 0;
	public float extinguishTime = 1f;
	public bool extinguished = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		extinguished = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime + extinguishTime)
		{
			if (!extinguished)
			{
				Flow();
				extinguished = true;
			}
		}
	}

	void Flow()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.2f);
		
		int i = 0;
		while (i < hitColliders.Length)
        {
        	if (hitColliders[i].transform.parent != null)
            {
            	hitColliders[i].transform.parent.gameObject.SendMessage("Extinguish",SendMessageOptions.DontRequireReceiver);
            }
            hitColliders[i].gameObject.SendMessage("Extinguish",SendMessageOptions.DontRequireReceiver);
           	i++;
        }
	}
}
