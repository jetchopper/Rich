using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Subscore : MonoBehaviour {

	AudioSource coinsBag;

	static Text text;
	static bool shift;
	static float score;
	
	// Use this for initialization
	void Awake () {
		coinsBag = GetComponent<AudioSource>();
		text = GetComponent<Text>();
		text.text = "";
	}

	void Update(){
		if (shift && text.lineSpacing > 0){
			text.lineSpacing -= Time.deltaTime * 10;
		}
		if (text.lineSpacing < 0){
			Score.SetScore(score);
			coinsBag.Play();
			score = 0f;
			text.text = "";
			text.lineSpacing = 1f;
			shift = false;
		}
	}
	
	public static void SetSubscore(float costCombo){
		text.text += "\n+" + costCombo;
		score += costCombo;
	}

	public static void Clear(){
		shift = true;
	}
}
