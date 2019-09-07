using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	float hp = 0.5f;
	public HPDisplay hpDisplay;

	public SpriteRenderer CurrentImage;
	public Sprite[] DogImages;
	public GameObject winParticles;

	public bool spawnParticles = true;

    // Update is called once per frame
    void Update()
    {
		hp -= Time.deltaTime / 50f;
		hpDisplay.DisplayHP(hp);

		if (hp >= 1f)
		{
			CurrentImage.sprite = DogImages[0];
			if (spawnParticles)
			{
				Instantiate(winParticles, winParticles.transform.position, winParticles.transform.rotation);
				spawnParticles = false;
			}
			Time.timeScale = 0f;
		}
		else if(hp >= 0.75f)
		{
			CurrentImage.sprite = DogImages[1];
		}
		else if (hp >= 0.5f)
		{
			CurrentImage.sprite = DogImages[2];
		}
		else if (hp >= 0.25f)
		{
			CurrentImage.sprite = DogImages[3];
		}
		else if (hp >= 0f)
		{
			CurrentImage.sprite = DogImages[4];
		}
		else
		{
			CurrentImage.sprite = DogImages[5];
			Time.timeScale = 0f;
		}
    }

	public void AddHP(float amount)
	{
		hp += amount;
	}

	public void ResetHP()
	{
		hp = 0.5f;
		spawnParticles = true;
	}
}
