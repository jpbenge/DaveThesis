#pragma strict
var prefabH20mine:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound : AudioClip;
var soundVolume : float = 1f;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire4")) {

		var instanceH20mine = Instantiate(prefabH20mine, spawnpos.position, Quaternion.identity);
		instanceH20mine.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}