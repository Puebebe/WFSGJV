using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoScript : MonoBehaviour
{
	public AudioSource[] piano;
	KeyCode[] keys = { KeyCode.Q, KeyCode.A,KeyCode.Z,KeyCode.W,KeyCode.S,KeyCode.X,KeyCode.E,KeyCode.D,KeyCode.C,KeyCode.R,KeyCode.F,KeyCode.V};

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < keys.Length; i++)
		{
			if (Input.GetKeyDown(keys[i]))
			{
				piano[i].Play();
			}
		}
    }
}
