using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

	// Update is called once per frame
	void Awake () {
		Destroy(gameObject, 2f);
	}
}
