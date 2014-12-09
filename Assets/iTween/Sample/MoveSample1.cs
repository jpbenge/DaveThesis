using UnityEngine;
using System.Collections;

public class MoveSample1 : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", 3, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .3));
	}
}

