using UnityEngine;
using System.Collections;

public class Theme : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
