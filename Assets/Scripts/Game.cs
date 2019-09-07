using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

	float hp = 1f;
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
