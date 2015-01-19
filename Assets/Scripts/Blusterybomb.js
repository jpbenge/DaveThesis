#pragma strict
var prefabBlusteryBomb:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound :AudioClip;
var soundVolume : float = 1f;
function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire8")) {

		var instanceBlusteryBomb = Instantiate(prefabBlusteryBomb, spawnpos.position, Quaternion.identity);
		instanceBlusteryBomb.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}