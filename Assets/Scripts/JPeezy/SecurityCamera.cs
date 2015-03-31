using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {

	private bool moving = true;
	private float sinVal = 0f;
	private float initialVal = 0f;
	public GameObject cameraBody;
	public GameObject cameraLight;
	private Light camLightLight;
	public float startOffset = 0f;
	public float moveSpeed = 1f;
	public float moveDistance = 10f;
	private Color spotNormalColor;
	public Color spottedLightColor = Color.red;
	public float alarmDelayTime = 1f;
	public AudioClip spottedSound;
	float spottedTime;
	bool spottedPlayer;
	float alarmTime;
	public float alarmDuration = 20f;
	public GameObject alarmLight;
	public AudioSource alarmAudioSource;
	public float timeBetweenShots = 5f;
	float lastShot;
	enum CameraState {seeking,spotted,alarm};
	CameraState state;
	// Use this for initialization
	void Start () {
		state = CameraState.seeking;
		spottedTime = 0;
		alarmTime = 0;
		lastShot = 0;
		moving = true;
		spottedPlayer = false;
		sinVal += startOffset;
		initialVal = cameraBody.transform.localEulerAngles.y;
		camLightLight = cameraLight.GetComponent<Light>();
		spotNormalColor = camLightLight.color;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moving)
		{
			cameraBody.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, initialVal+(moveDistance*Mathf.Sin(sinVal)), transform.localEulerAngles.z);
			sinVal += (0.01f*moveSpeed);
		}
		if (state == CameraState.seeking || state == CameraState.spotted)
		{
			if (Time.time > spottedTime + alarmDelayTime)
			{
				if (spottedPlayer)
				{
					Alarm();
				}
				else
				{
					ForgetPlayer();
				}
			}
			RaycastHit hit;
			int layer = 11;
			int layermask = 1 << layer;
			if (Physics.SphereCast(cameraBody.transform.position, 3, cameraLight.transform.forward, out hit, 10,layermask))
			{
            	SpotPlayer();
            }
            else
            {
            	spottedPlayer = false;
            }
		}

		if (state == CameraState.alarm)
		{
			RaycastHit hit;
			int layer = 11;
			int layermask = 1 << layer;
			if (Physics.SphereCast(cameraBody.transform.position, 3, cameraLight.transform.forward, out hit, 10,layermask))
			{
          		ShootPlayer();
            }
            else
            {
            	if (Time.time > alarmTime + alarmDuration)
            	{
            		DeactivateAlarm();
            	}
            }
        	
		}
	}

	void SpotPlayer()
	{
		if (!spottedPlayer)
		{
			camLightLight.color = spottedLightColor;
			moving = false;
			spottedTime = Time.time;
			spottedPlayer = true;
			state = CameraState.spotted;
			if (spottedSound != null)
			{
				audio.clip = spottedSound;
				audio.Play();
			}
		}
	}

	void ForgetPlayer()
	{
		camLightLight.color = spotNormalColor;
		moving = true;
		spottedPlayer = false;
		state = CameraState.seeking;
	}

	void Alarm()
	{
		alarmLight.SendMessage("AlarmOn");
		alarmAudioSource.Play();
		state = CameraState.alarm;
		alarmTime = Time.time;
	}

	void DeactivateAlarm()
	{
		print("Deactivate Alerm");
		alarmLight.SendMessage("AlarmOff");
		alarmAudioSource.Stop();
		state = CameraState.seeking;
		ForgetPlayer();
	}

	void ShootPlayer()
	{
		print("Shoot Player");
	}
}
