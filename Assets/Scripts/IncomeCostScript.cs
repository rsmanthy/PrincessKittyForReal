using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncomeCostScript : MonoBehaviour
{
	public Text score;
	public int increaseIncomeCost;

	void Start() {
		increaseIncomeCost = 0;
		score = GetComponent<Text>();
	}

	void Update() {
		score.text = increaseIncomeCost.ToString();
	}

	public void IncreaseCose()
	{
		increaseIncomeCost += 100;
	}
}
