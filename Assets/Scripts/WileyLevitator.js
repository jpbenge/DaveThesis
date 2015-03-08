#pragma strict
var prefabWileyLevitator:GameObject;
var shootForce:float;
var spawnpos:Transform;
var sound :AudioClip;
var soundVolume : float = 1f;
function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire11")) {

		var instanceWileyLevitator = Instantiate(prefabWileyLevitator, spawnpos.position, Quaternion.identity);
		instanceWileyLevitator.rigidbody.AddForce( transform.forward * shootForce );
		if (sound)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
		}
	}
}