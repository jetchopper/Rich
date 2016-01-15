using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick1 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	public BladeRotate1 blade;
	public Image top;
	public float delta;
	
	Image bottom;
	Vector2 inputVector;

	void Awake(){
		bottom = GetComponent<Image> ();
	}
	
	public virtual void OnDrag(PointerEventData ped){
		// check if screen touched, setting parameters to pos
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bottom.rectTransform, ped.position, 
		                                                             ped.pressEventCamera, out pos)) {
			//converting
			pos.x = pos.x / bottom.rectTransform.sizeDelta.x;
			pos.y = 0;
			inputVector = new Vector2(pos.x * 2 + 1, pos.y);
			inputVector = (inputVector.magnitude > 2f) ? inputVector.normalized * 2 : inputVector;
			//move joystick
			top.rectTransform.anchoredPosition = new Vector2(inputVector.x * (bottom.rectTransform.sizeDelta.x / delta), inputVector.y);
		}
		if (top.rectTransform.anchoredPosition.x < 0){
			blade.StartRotate(top.rectTransform.anchoredPosition.x);
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		//if touched down - send to drag
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		//resetting to center
		inputVector = Vector2.zero;
		top.rectTransform.anchoredPosition = Vector2.zero;
		blade.StopRotate();
	}
}