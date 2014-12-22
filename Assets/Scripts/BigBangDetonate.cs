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
			RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, 5);
			if (hits.Length > 0)
            {
            	foreach (RaycastHit hit in hits)
            	{
            		print(hit.collider.gameObject);
            		hit.collider.gameObject.SendMessage("OnExplosion",SendMessageOptions.DontRequireReceiver);
        		}
        	}
			Destroy(gameObject);
		}
	}

}
