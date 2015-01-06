#pragma strict
var prefabtexasGold:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire6")) {

		var instancetexasGold = Instantiate(prefabtexasGold, spawnpos.position, Quaternion.identity);
		instancetexasGold.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}