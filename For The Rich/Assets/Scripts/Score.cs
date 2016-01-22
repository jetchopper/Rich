using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		text.text = "";
	}

	public static void SetScore(float cost){
		if (text.text.Equals("")){
			text.text = "0";
		}
		text.text = "" + (int.Parse(text.text) + (cost));
	}
}
