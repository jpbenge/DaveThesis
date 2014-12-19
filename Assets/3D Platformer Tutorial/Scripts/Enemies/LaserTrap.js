var height = 3.2;
var speed = 2.0;
var timingOffset = 0.0;
var laserWidth = 12.0;
var damage = 20;
var hitEffect : GameObject;

private var originalPosition : Vector3;
private var hit : RaycastHit;
private var lastHitTime = 0.0;

var smoked = false;
public var sound : AudioClip;
public var soundVolume : float = 1;

function Start ()
{
	originalPosition = transform.position;
	//GetComponent(LineRenderer).SetPosition(1, Vector3.forward * laserWidth);
}

function Update ()
{
	var offset = (1 + Mathf.Sin(Time.time * speed + timingOffset)) * height / 2;
	transform.position = originalPosition + Vector3(0, offset, 0);

	if (Time.time > lastHitTime + 0.25 && Physics.Raycast(transform.position, transform.forward, hit, laserWidth))
	{
		if (hit.collider.tag == "Player" || hit.collider.tag == "Enemy")
		{
			Instantiate(hitEffect, hit.point, Quaternion.identity);
			if (!smoked)
			{
				if (sound)
				{
					AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
				}
				hit.collider.SendMessage("OnHit", damage, SendMessageOptions.DontRequireReceiver);
				hit.collider.SendMessage("Slam", -2f*hit.transform.forward, SendMessageOptions.DontRequireReceiver);
				lastHitTime = Time.time;
			}
		}
		else if (hit.collider.tag == "smoke")
		{
			smoked = true;
		}
		else
		{
			smoked = false;
		}
	}
	
}

@script RequireComponent (LineRenderer)