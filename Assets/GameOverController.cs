using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	RectTransform yourCirlce;
	Text percent;
	float yourCircleSizeLerp; // Current lerp amount for 
	float percentComplete;
	bool isGameOver = false;

	void Start () {
		yourCirlce = transform.Find ("YourCircle").GetComponent<RectTransform>();
		percent = yourCirlce.Find ("Percent").GetComponent<Text>();
	}

	void GameOver(float percentComplete) {
		if (isGameOver)
			return;

		this.percentComplete = percentComplete;

		isGameOver = true;
		yourCircleSizeLerp = 0;
	}

	void Update () {
		if (isGameOver) {
			yourCircleSizeLerp = Mathf.Min (percentComplete, yourCircleSizeLerp + 0.5f * Time.deltaTime);
			yourCirlce.localScale = Vector3.Lerp (Vector3.zero, Vector3.one, yourCircleSizeLerp);
			percent.text = "%" + (int)(yourCircleSizeLerp * 100);
		}
	}
}
