#pragma strict
var prefabLuminousCharge:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound :AudioClip;
var soundVolume : float = 1f;
function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire10")) {

		var instanceLuminousCharge = Instantiate(prefabLuminousCharge, spawnpos.position, Quaternion.identity);
		instanceLuminousCharge.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}