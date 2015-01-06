#pragma strict
var prefabEMPgrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire1")) {

		var instanceEMPgrenade = Instantiate(prefabEMPgrenade, spawnpos.position, Quaternion.identity);
		instanceEMPgrenade.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}