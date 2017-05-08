using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> scoreList = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			scoreList.Add (runningTotal);
		}

		return scoreList;
	}

	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int> ();
		int bowl = 1;
		int runningSum = 0;
		int strike = 0;

		for (int i = 0; i < rolls.Count; i++) {
			runningSum += rolls [i];

			if (rolls[i] == 10) {
				strike += 10;
				if (strike == 30) {
					frameList.Add (strike);
					strike -= 10;
				}
				bowl += 2;
				continue;					
			}

			if (bowl % 2 == 0 && runningSum < 10) {
				frameList.Add (runningSum);
				runningSum = 0;	
			} else if (bowl % 2 == 0 && runningSum > 10) {
				if (strike != 0 && frameList.Count < 9) {
					if (strike > 10 && runningSum % 10 != 0) {
						frameList.Add (runningSum - rolls [i]);
					} else  {
						frameList.Add (runningSum);	
					}
					while (strike > 0) {
						runningSum -= 10;
						strike -= 10;
						frameList.Add (runningSum);
					}
					runningSum = 0;
				} else if (strike != 0 && frameList.Count == 9){
					frameList.Add (runningSum);
					runningSum = 0;
				}
			}

			if (bowl % 2 != 0 && runningSum > 10) {
				if (strike == 0) {
					frameList.Add (runningSum);
					runningSum = rolls [i];
				}
			}
			bowl++;
		}
		return frameList;
	}
}
