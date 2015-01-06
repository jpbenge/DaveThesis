#pragma strict
var prefabteslaGrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire5")) {

		var instanceteslaGrenade = Instantiate(prefabteslaGrenade, spawnpos.position, Quaternion.identity);
		instanceteslaGrenade.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}