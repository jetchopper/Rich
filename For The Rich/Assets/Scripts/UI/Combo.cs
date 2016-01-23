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
		if (timer > 1f){
			text.enabled = false;
		}else{
			text.color -= Color.black * Time.deltaTime * 2f; 
			rect.localScale += new Vector3(Time.deltaTime, Time.deltaTime) * 2f;
		}
	}

	public static void setCombo(int combo){
		if (combo >= 2){
			text.text = "X" + combo;
			text.enabled = true;
			rect.localScale = new Vector3(1f, 1f, 1f);
			text.color = Color.white;
			timer = 0f;
		}
	}
}
