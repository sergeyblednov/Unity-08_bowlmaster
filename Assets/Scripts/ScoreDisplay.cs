using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text [] rollTexts;
	public Text [] frameTexts;

	void Start () {
		rollTexts[0].text = "X";
		frameTexts[0].text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
