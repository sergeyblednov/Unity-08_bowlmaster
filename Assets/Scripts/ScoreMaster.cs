using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> scoreList = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
		}

		return scoreList;
	}

	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int> ();
		int bowl = 1;
		int runningSum = 0;
		for (int i = 0; i < rolls.Count; i++) {
			runningSum += rolls [i];
			if (bowl % 2 == 0 && runningSum < 10) {
					frameList.Add (runningSum);
					runningSum = 0;	
			} else if (runningSum > 10) {
					frameList.Add (runningSum - rolls[i]);
					frameList.Add (runningSum - 10);
					runningSum = 0;	
			}

			bowl++;
		}

		return frameList;
	}
}
