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
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {					

			if (frames.Count == 10) {								// Prevent from 11th frame score
				break;
			}

			if (rolls [i - 1] + rolls [i] < 10) {					// NORMAL FRAME
				frames.Add (rolls [i - 1] + rolls [i]);	
			}

			if (rolls.Count - i <= 1) {								// Insufficient look-ahead
				break;
			}

			if (rolls [i - 1] == 10) {								// STRIKE
				i--;												//
				frames.Add (10 + rolls [i + 1] + rolls [i + 2]);
			} else if (rolls [i - 1] + rolls [i] == 10) {			// SPARE
				frames.Add (10 + rolls [i + 1]);
			}
		}
			
		return frames;
	}
}
