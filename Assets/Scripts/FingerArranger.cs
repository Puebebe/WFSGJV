using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerArranger : MonoBehaviour
{
    string[] fingers = { "qaz", "wsx", "edc", "rfv" };
    int[] startArrangement;
    int[] currentArrangement;

	public ComboDisplayScript comboDisplayScript;
	public Game game;
	public FingerMover fingerMover;

    // Start is called before the first frame update
    void Start()
    {
        startArrangement = new int[fingers.Length];
        currentArrangement = new int[startArrangement.Length];
        randomNewArrangement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            bool isGood = false;

            for (int finger = 0; finger < fingers.Length; finger++)
            {
                int key = startArrangement[finger] - currentArrangement[finger];

				if (currentArrangement[finger] > 0 && Input.GetKeyDown(fingers[finger][key].ToString()))
                {
                    Debug.Log("good");
					currentArrangement[finger]--;
                    isGood = true;

					bool allGood = true;
					for (int i = 0; i < currentArrangement.Length; i++)
					{
						if (currentArrangement[i] != 0)
						{
							allGood = false;
						}
					}

					if (allGood)
					{
						game.AddHP(0.1f);
						StartCoroutine(delayNewRandom(0.25f));
					}
                }

				key = startArrangement[finger] - currentArrangement[finger];
				fingerMover.MoveFinger(finger, key);

            }

            if (!isGood)
            {
                Debug.Log("bad");
				StartCoroutine(delayNewRandom(0.25f));
			}
        }
    }

	IEnumerator delayNewRandom(float delay)
	{
		yield return new WaitForSeconds(delay);
		randomNewArrangement();
	}

    private void randomNewArrangement()
    {
        for (int i = 0; i < startArrangement.Length; i++)
        {
            currentArrangement[i] = startArrangement[i] = Random.Range(0, fingers[i].Length + 1);
			fingerMover.MoveFinger(i, 0);
        }

        int zerosCounter = 0;

        foreach (int x in startArrangement)
        {
            if (x == 0)
                zerosCounter++;
        }
		 
        if (zerosCounter > 3)
        {
            int randomFinger = Random.Range(0, fingers.Length);
            currentArrangement[randomFinger] = startArrangement[randomFinger] = Random.Range(1, fingers[randomFinger].Length + 1);
        }

        if (zerosCounter < 1)
        {
            int randomFinger = Random.Range(0, fingers.Length);
            currentArrangement[randomFinger] = startArrangement[randomFinger] = 0;
        }

		comboDisplayScript.SetDisplays(startArrangement);

        //DEBUG
        string newArrangement = "";
        foreach (var x in startArrangement)
        {
            newArrangement += x + " ";
        }
        Debug.LogWarning(newArrangement);
    }
}
