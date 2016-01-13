using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	//killing everything outside this box
	public void OnTriggerExit(Collider c){
		Destroy(c.gameObject);
	}
}
