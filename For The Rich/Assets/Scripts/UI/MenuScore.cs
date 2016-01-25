using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		text.text = "Personal Record\n$" + PlayerPrefs.GetString("score");
	}
}
