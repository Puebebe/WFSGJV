using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
	public RectTransform HPBar;
	public Image Vignette;

	public void DisplayHP(float hp)
	{
		if (HPBar != null)
		{
			HPBar.sizeDelta = new Vector2(100f, 720f * hp);
		}

		if (Vignette != null)
		{
			Vignette.color = new Color(Vignette.color.r, Vignette.color.g, Vignette.color.b, hp);
		}
	}

}
