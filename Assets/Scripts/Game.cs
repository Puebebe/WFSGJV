using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	float hp = 0.5f;
	public HPDisplay hpDisplay;

    // Update is called once per frame
    void Update()
    {
		hp -= Time.deltaTime / 50f;
		hpDisplay.DisplayHP(hp);
    }

	public void AddHP(float amount)
	{
		hp = Mathf.Min(1f, hp + amount);
	}
}
