#pragma strict
var prefabIcegrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound :AudioClip;
var soundVolume : float = 1f;
function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Punch")) {

		var instanceIcegrenade = Instantiate(prefabIcegrenade, spawnpos.position, Quaternion.identity);
		instanceIcegrenade.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}