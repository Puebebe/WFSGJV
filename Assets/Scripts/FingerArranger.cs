using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerArranger : MonoBehaviour
{
    string[] fingers = { "qaz", "wsx", "edc", "rfv" };
    int[] startArrangement;
    int[] currentArrangement;

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

            for (int i = 0; i < fingers.Length; i++)
            {
                if (currentArrangement[i] > 0 && Input.GetKeyDown(fingers[i][startArrangement[i] - currentArrangement[i]].ToString()))
                {
                    Debug.Log("good");
                    --currentArrangement[i];
                    isGood = true;
                    break;
                }
            }

            if (!isGood)
            {
                Debug.Log("bad");
                randomNewArrangement();
            }
        }
    }

    private void randomNewArrangement()
    {
        for (int i = 0; i < startArrangement.Length; i++)
        {
            currentArrangement[i] = startArrangement[i] = Random.Range(0, fingers[i].Length + 1);
        }

        int zerosCounter = 0;

        foreach (int x in startArrangement)
        {
            if (x == 0)
                zerosCounter++;
        }

        if (zerosCounter < 1)
        {
            int randomFinger = Random.Range(0, fingers.Length);
            currentArrangement[randomFinger] = startArrangement[randomFinger] = Random.Range(1, fingers[randomFinger].Length + 1);
        }

        if (zerosCounter > 3)
        {
            int randomFinger = Random.Range(0, fingers.Length);
            currentArrangement[randomFinger] = startArrangement[randomFinger] = 0;
        }

        //DEBUG
        string newArrangement = "";
        foreach (var x in startArrangement)
        {
            newArrangement += x + " ";
        }
        Debug.LogWarning(newArrangement);
    }
}
