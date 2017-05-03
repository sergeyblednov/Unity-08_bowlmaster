using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int>();
		bool allPins = false;
		for (int i = 1; i < rolls.Count; i++) {
			if (i % 2 == 0 ) { 
				frameList.Add (rolls [i] + rolls [i - 1]);
				if (rolls [i] + rolls [i - 1] == 10) {
					allPins = true;
				}
			} else {
				if (allPins) {
					frameList [frameList.Count - 1] += rolls [i];
					allPins = false;
				}	
			}
		}
		return frameList;
	}
}
