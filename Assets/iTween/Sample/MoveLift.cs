using UnityEngine;
using System.Collections;

public class MoveLift : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", 10, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 2));
	}
}

