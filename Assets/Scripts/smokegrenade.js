#pragma strict
var prefabsmokegrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire3")) {

		var instancesmokegrenade = Instantiate(prefabsmokegrenade, spawnpos.position, Quaternion.identity);
		instancesmokegrenade.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}