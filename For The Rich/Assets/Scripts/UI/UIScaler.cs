using UnityEngine;
using System.Collections;

public class UIScaler : MonoBehaviour {

	public float scaleSpeed, offset, timeBetween;
	
	float effectTimer;
	RectTransform rect;
	Vector3 initScale;

	// Use this for initialization
	void Awake () {
		effectTimer = timeBetween / 2 + offset;;
		rect = GetComponent<RectTransform>();
		initScale = rect.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		effectTimer += Time.deltaTime;
		if (effectTimer < scaleSpeed){
			rect.localScale += Vector3.one * Time.deltaTime;
		}
		if (effectTimer > scaleSpeed && effectTimer < scaleSpeed * 2){
			rect.localScale -= Vector3.one * Time.deltaTime;
		}
		if (effectTimer > scaleSpeed * 2){
			rect.localScale = initScale;
		}
		if (effectTimer > timeBetween){
			effectTimer = 0f;
		}
	}
}
