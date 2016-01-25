using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuTimeScore : MonoBehaviour {

	Text text;
	
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		text.text = "Time Record\n$" + PlayerPrefs.GetInt("timeRecord");
	}
}
