#pragma strict
@script RequireComponent (BoxCollider)
var damage = 15;
var innerCore : ParticleEmitter;
var outerCore : ParticleEmitter;
var smoke : ParticleEmitter;
var extinguishSound : AudioClip;
var oilSound : AudioClip;
var flareUpTime : float = 4.0f;
var onFire : boolean = true;
private var flaringUp : boolean = false;
private var flareUpStart : float = 0f;
private var innerMin : float;
private var outerMin : float;
private var innerMax : float;
private var outerMax : float;
private var smokeMin : float;
private var smokeMax : float;
private var lastHitTime : float;
var hitSound : AudioClip;


function Start () {
	flaringUp = false;
	innerMin = innerCore.minEnergy;
	innerMax = innerCore.maxEnergy;
	outerMin = outerCore.minEnergy;
	outerMax = outerCore.maxEnergy;
	smokeMin = smoke.minEnergy;
	smokeMax = smoke.maxEnergy;
	if (!onFire)
	{
		PutOut();
	}
}

function Update () {
	if (flaringUp && Time.time >= flareUpStart + flareUpTime)
	{
		UnFlare();
	}
}
function Extinguish() {
	onFire = false;
	innerCore.emit = false;
	outerCore.emit = false;
	smoke.emit = false;
	if (extinguishSound)
	{
		AudioSource.PlayClipAtPoint(extinguishSound,transform.position);
	}
}

function ExtinguishTemp(relightTime : float)
{
	onFire = false;
	innerCore.emit = false;
	outerCore.emit = false;
	smoke.emit = false;
	if (extinguishSound)
	{
		AudioSource.PlayClipAtPoint(extinguishSound,transform.position);
	}
	Invoke("OnFire",relightTime);
}

function OnOil()
{
	if (!flaringUp)
	{
		FlareUp();
	}
	else
	{
		flareUpStart = Time.time;
	}
}

function FlareUp()
{
	flaringUp = true;
	flareUpStart = Time.time;
	innerCore.minEnergy = innerMin*2.5f;
	innerCore.maxEnergy = innerMax*2.5f;
	outerCore.minEnergy = outerMin*2.5f;
	outerCore.maxEnergy = outerMax*2.5f;
	smoke.minEnergy = smokeMin*2.5f;
	smoke.maxEnergy = smokeMax*2.5f;


}
function UnFlare()
{
	flaringUp = false;
	innerCore.minEnergy = innerMin;
	innerCore.maxEnergy = innerMax;
	outerCore.minEnergy = outerMin;
	outerCore.maxEnergy = outerMax;
	smoke.minEnergy = smokeMin;
	smoke.maxEnergy = smokeMax;
}

function OnFire()
{
	innerCore.emit = true;
	outerCore.emit = true;
	smoke.emit = true;
	onFire = true;
}

function OnExplosion()
{
	OnFire();
}

function OnWind()
{
	ExtinguishTemp(5.0f);
}

function OnTriggerEnter(hit : Collider)
{
	if (onFire && Time.time > lastHitTime + 0.25 && hit.collider.tag == "Player")
	{
		if (hitSound)
		{
			AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
		}
		hit.collider.SendMessage("OnHit", damage, SendMessageOptions.DontRequireReceiver);
		hit.collider.SendMessage("Slam", -2f*hit.transform.forward, SendMessageOptions.DontRequireReceiver);
		lastHitTime = Time.time;
	}
}

function PutOut()
{
	onFire = false;
	innerCore.emit = false;
	outerCore.emit = false;
	smoke.emit = false;
}