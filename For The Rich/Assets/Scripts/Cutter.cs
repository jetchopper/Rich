using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cutter : MonoBehaviour
{
	
	public RectTransform touchField;
	private bool reloaded = false;

	void Update ()
	{	 
		if (reloaded && BouthTouchesOnField ()) {
			reloaded = false;
			Cut ();
		}

		if (BouthTouchesNotOnField ()) {
			reloaded = true;
		}
	}

	void Cut ()
	{
		//тут посчитать середину между тачями
		//сконвертировать с координат тачскрина в систему объектов
		//и сделать что-то типа: money.Cut(cutPoint);
	}

	bool BouthTouchesOnField ()
	{
		return Input.touchCount == 2 && IsTouchAtField (Input.touches [0])
			&& IsTouchAtField (Input.touches [1]);
	}

	bool BouthTouchesNotOnField ()
	{
		return Input.touchCount == 2 && !IsTouchAtField (Input.touches [0])
			&& !IsTouchAtField (Input.touches [1]);
	}

	bool IsTouchAtField (Touch touch)
	{
		return RectTransformUtility.RectangleContainsScreenPoint (touchField, touch.position);
	}
}