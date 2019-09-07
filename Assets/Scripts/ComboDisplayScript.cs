using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboDisplayScript : MonoBehaviour
{

	public GameObject[] Displays;

	public void SetDisplays(int[] input)
	{
		for (int i = 0; i < 4; i++)
		{
			switch (input[i])
			{
				case 0:
					for (int j = 0; j < 3; j++)
					{
						Displays[i * 3 + j].SetActive(false);
					}
					break;
				case 1:
					Displays[i * 3].SetActive(true);
					for (int j = 1; j < 3; j++)
					{
						Displays[i * 3 + j].SetActive(false);
					}
					break;
				case 2:
					Displays[i * 3 + 2].SetActive(false);
					for (int j = 0; j < 2; j++)
					{
						Displays[i * 3 + j].SetActive(true);
					}
					break;
				case 3:
					for (int j = 0; j < 3; j++)
					{
						Displays[i * 3 + j].SetActive(true);
					}
					break;
				default:
					break;
			}
		}
	}

}
