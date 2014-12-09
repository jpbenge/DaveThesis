using UnityEngine;
using System.Collections;

public class MoveSample2 : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", 3, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .7));
	}
}

