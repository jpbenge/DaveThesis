#pragma strict

var extinguishTime : float = 1;
var startTime : float = 0;
var extinguished : boolean = false;

function Start () {
	startTime = Time.time;
	extinguished = false;
}

function Update () {
	if (Time.time >= startTime + extinguishTime)
	{
		if (!extinguished)
		{
			Flow();
			extinguished = true;
		}
	}
}

function Flow() {
	var hits : RaycastHit[];
	
	hits = Physics.SphereCastAll(transform.position,3,transform.forward);
	for (var hit : RaycastHit in hits)
	{
		//Debug.Log(hit.collider.gameObject.name);
		if (hit.collider.transform.parent != null)
			hit.collider.transform.parent.BroadcastMessage("Extinguish",SendMessageOptions.DontRequireReceiver);
		else
			hit.collider.BroadcastMessage("Extinguish",SendMessageOptions.DontRequireReceiver);
	}
}