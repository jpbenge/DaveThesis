#pragma strict
var prefabBigBangBoom:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire7")) {

		var instanceBigBangBoom = Instantiate(prefabBigBangBoom, spawnpos.position, Quaternion.LookRotation(transform.forward));
		instanceBigBangBoom.rigidbody.AddForce( instanceBigBangBoom.transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}