using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private GameManager gameManager;
	private float lastChangeTime;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10; // TODO make private
	private bool ballOutOfPlay = false;

	void Start() {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}


	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle();
			standingDisplay.color = Color.red;
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.gameObject.name == "Ball") {
			SetBallOutOfPlay ();
		}
	}

	public void SetBallOutOfPlay () {
		ballOutOfPlay = true;
	}

	public void Reset () {
		lastSettledCount = 10;
	}

	void UpdateStandingCountAndSettle () {
		// Update the lastStandingCount
		// Call PinsHaveSettled() when they have
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;  // How long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime) { // If last change > 3s ago
			PinsHaveSettled();
		}

	}

	void PinsHaveSettled () {
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl (pinFall);

		lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
		print (standingDisplay.color);
	}

	int CountStanding () {
		int standing = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				standing++;
			}
		}

		return standing;
	}

}
