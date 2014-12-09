#pragma strict
var prefabIncindiary:GameObject;
var shootForce:float;
var spawnpos:Transform;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Incindiary")) {

		var instanceIncindiary = Instantiate(prefabIncindiary, spawnpos.position, Quaternion.identity);
		instanceIncindiary.rigidbody.AddForce( transform.forward * shootForce );
	}
}