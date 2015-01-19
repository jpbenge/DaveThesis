#pragma strict
var prefabOccularFlux:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound :AudioClip;
var soundVolume : float = 1f;
function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire9")) {

		var instanceOccularFlux = Instantiate(prefabOccularFlux, spawnpos.position, Quaternion.identity);
		instanceOccularFlux.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}