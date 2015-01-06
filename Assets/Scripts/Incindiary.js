#pragma strict
var prefabIncindiary:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Incindiary")) {

		var instanceIncindiary = Instantiate(prefabIncindiary, spawnpos.position, Quaternion.identity);
		instanceIncindiary.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}