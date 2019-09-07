using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerArranger : MonoBehaviour
{
    string[] fingers = { "qaz", "wsx", "edc", "rfv" };
    int[] startArrangement = { 1, 2, 3, 0 };
    int[] currentArrangement;

    // Start is called before the first frame update
    void Start()
    {
        currentArrangement = new int[startArrangement.Length];

        for (int i = 0; i < currentArrangement.Length; i++)
        {
            currentArrangement[i] = startArrangement[i];
        }
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
                Debug.Log("bad");
        }
    }
}
