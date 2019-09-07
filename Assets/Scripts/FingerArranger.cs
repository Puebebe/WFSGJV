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
	public GameObject badParticles;

	float goodTimer = 0f;

	public Transform Canvas;
	public GameObject[] positiveFeedbackObjects;
	public Rect positiveFeedbackArea;
	public Vector2 positiveFeedbackScale;
	public float positiveFeedbackRotation;

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
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
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
						PositiveFeedback();
						game.AddHP(0.1f);
						Debug.Log("all good");
						StartCoroutine(delayNewRandom(0.25f));
						
					}
                }

                if (Time.timeScale > 0.5f)
                {
                    key = startArrangement[finger] - currentArrangement[finger];
                    fingerMover.MoveFinger(finger, key);
                    comboDisplayScript.DisableDisplays(finger, key);
                }
            }

            if (!isGood)
            {
                Debug.Log("bad");
                
                if (Time.timeScale > 0.5f)
                    Instantiate(badParticles, badParticles.transform.position, badParticles.transform.rotation);

                StartCoroutine(delayNewRandom(0.25f));
			}

            if (Time.timeScale < 0.5f && Input.GetKeyDown(KeyCode.Return))
            {
                game.ResetHP();
                Time.timeScale = 1f;
                randomNewArrangement();
            }
        }

        goodTimer += Time.deltaTime;
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

		goodTimer = 0f;

        //DEBUG
        string newArrangement = "";
        foreach (var x in startArrangement)
        {
            newArrangement += x + " ";
        }
        Debug.LogWarning(newArrangement);
    }

	private void PositiveFeedback()
	{
		Quaternion rot = Quaternion.identity;
		rot.eulerAngles += new Vector3(0f, 0f, positiveFeedbackRotation * Random.Range(-1f, 1f));
		Vector3 pos = positiveFeedbackArea.center;
		pos += new Vector3(positiveFeedbackArea.width/2f * Random.Range(-1f,1f),positiveFeedbackArea.height/2f * Random.Range(-1f,1f) ,0);
		float scale = Mathf.Lerp(positiveFeedbackScale.x,positiveFeedbackScale.y, Random.Range(0f,1f));
		Vector3 scl = new Vector3(1f,1f,1f);
		GameObject tmp = null;

		if (goodTimer <= 1f)
		{
			tmp = Instantiate(positiveFeedbackObjects[0],Canvas);
		}
		else if (goodTimer <= 1.5f)
		{
			tmp = Instantiate(positiveFeedbackObjects[1], Canvas);
		}
		else if (goodTimer <= 2f)
		{
			tmp = Instantiate(positiveFeedbackObjects[2], Canvas);
		}
		else
		{
			tmp = Instantiate(positiveFeedbackObjects[3], Canvas);
		}

		tmp.transform.localScale = scl;
		tmp.transform.rotation = rot;
		tmp.transform.localPosition = pos;
		StartCoroutine( DelayDestroy(tmp, 1f));
	}

	IEnumerator DelayDestroy(GameObject target, float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		Destroy(target);
	}
}
