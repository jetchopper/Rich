using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
	}

	public static void SetScore(float cost){
		text.text = "" + (int.Parse(text.text) + cost);
	}
}
