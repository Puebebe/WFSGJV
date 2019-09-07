using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMover : MonoBehaviour
{

	public GameObject[] Fingers;

	private void Start()
	{
		MoveFinger(0, 0);
		MoveFinger(1, 0);
		MoveFinger(2, 0);
		MoveFinger(3, 0);
	}

	public void MoveFinger(int finger, int amount)
	{
		Debug.Log("finger " + finger + " amount " + amount);
		switch (amount)
		{
			case 0:
				Fingers[finger * 3 + 2].transform.localEulerAngles = new Vector3(0f, 19f, 0f);
				Fingers[finger * 3 + 2].transform.localPosition = new Vector3(1.1f + finger * 0.2f, 0f, -1f + finger * 0.5f);

				Fingers[finger * 3 + 1].transform.localEulerAngles = new Vector3(0f, 19f, 0f);
				Fingers[finger * 3 + 1].transform.localPosition = new Vector3(2.1f + finger * 0.2f, 0f, -1.35f + finger * 0.5f);

				Fingers[finger * 3].transform.localEulerAngles = new Vector3(0f, 19f, 0f);
				Fingers[finger * 3].transform.localPosition = new Vector3(2.9f + finger * 0.2f, 0f, -1.6f + finger * 0.5f);

				break;
			case 1:
				Fingers[finger * 3 + 2].transform.localEulerAngles = new Vector3(0f, 19f, 0f);
				Fingers[finger * 3 + 2].transform.localPosition = new Vector3(1.1f + finger * 0.2f, 0f, -1f + finger * 0.5f);

				Fingers[finger * 3 + 1].transform.localEulerAngles = new Vector3(0f, 19f, 0f);
				Fingers[finger * 3 + 1].transform.localPosition = new Vector3(2.1f + finger * 0.2f, 0f, -1.35f + finger * 0.5f);

				Fingers[finger * 3].transform.localEulerAngles = new Vector3(0f, 19f, 45f);
				Fingers[finger * 3].transform.localPosition = new Vector3(2.9f + finger * 0.2f, 0f, -1.6f + finger * 0.5f);

				break;
			case 2:
				Fingers[finger * 3 + 2].transform.localEulerAngles = new Vector3(0f, 19f, 0f);
				Fingers[finger * 3 + 2].transform.localPosition = new Vector3(1.1f + finger * 0.2f, 0f, -1f + finger * 0.5f);

				Fingers[finger * 3 + 1].transform.localEulerAngles = new Vector3(0f, 19f, 45f);
				Fingers[finger * 3 + 1].transform.localPosition = new Vector3(2.1f + finger * 0.2f, 0f, -1.35f + finger * 0.5f);

				Fingers[finger * 3].transform.localEulerAngles = new Vector3(0f, 19f, 90f);
				Fingers[finger * 3].transform.localPosition = new Vector3(2.5f + finger * 0.2f, 0.8f, -1.45f + finger * 0.5f);

				break;
			case 3:
				Fingers[finger * 3 + 2].transform.localEulerAngles = new Vector3(0f, 19f, 45f);
				Fingers[finger * 3 + 2].transform.localPosition = new Vector3(1.1f + finger * 0.2f, 0f, -1f + finger * 0.5f);

				Fingers[finger * 3 + 1].transform.localEulerAngles = new Vector3(0f, 19f, 90f);
				Fingers[finger * 3 + 1].transform.localPosition = new Vector3(1.7f + finger * 0.2f, 0.8f, -1.25f + finger * 0.5f);

				Fingers[finger * 3].transform.localEulerAngles = new Vector3(0f, 19f, 135f);
				Fingers[finger * 3].transform.localPosition = new Vector3(1.4f + finger * 0.2f, 1.7f, -1.15f + finger * 0.5f);

				break;
			default:
				break;
		}
	}

}
