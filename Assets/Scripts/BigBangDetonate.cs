using UnityEngine;
using System.Collections;

public class BigBangDetonate : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag != "Player")
		{
			GameObject clone = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			clone.AddComponent<DestroyAfterSeconds>();
        	Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.5f);
        	int i = 0;
        	while (i < hitColliders.Length) 
        	{
            	hitColliders[i].gameObject.SendMessage("OnExplosion",SendMessageOptions.DontRequireReceiver);
            	i++;
        	}
			Destroy(gameObject);
		}
	}

}
