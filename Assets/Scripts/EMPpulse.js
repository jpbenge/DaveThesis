#pragma strict

var explodeTime : float = 3;
var startTime : float = 0;
var exploded : boolean = false;

function Start () {
	startTime = Time.time;
	exploded = false;
}

function Update () {
	if (Time.time >= startTime + explodeTime)
	{
		if (!exploded)
		{
			Pulse();
			exploded = true;
		}
	}
}

function Pulse() {
	var hits : RaycastHit[];
	
	hits = Physics.SphereCastAll(transform.position,3,transform.forward);
	for (var hit : RaycastHit in hits)
	{
		//Debug.Log(hit.collider.gameObject.name);
		if (hit.collider.transform.parent != null)
			hit.collider.transform.parent.BroadcastMessage("Scramble",SendMessageOptions.DontRequireReceiver);
		else
			hit.collider.BroadcastMessage("Scramble",SendMessageOptions.DontRequireReceiver);
	}
}