using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

	static Text text;
	static float timer;
	static RectTransform rect;

	void Awake(){
		text = GetComponent<Text>();
		text.enabled = false;
		rect = GetComponent<RectTransform>();
		timer = 0f;
	}

	void Update(){
		timer += Time.deltaTime;
		if (timer > 0.4f){
			text.enabled = false;
		}else{
			rect.localScale += new Vector3(Time.deltaTime, Time.deltaTime);
		}
	}

	public static void setCombo(int combo){
		if (combo >= 2){
			text.text = "X" + combo;
			text.enabled = true;
			rect.localScale = new Vector3(1f, 1f, 1f);
			timer = 0f;
		}
	}
}
