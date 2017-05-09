using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 () {
		int[] rolls = { 1 };
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T02Bowl3 () {
		int[] rolls = { 1, 8, 3 };
		string rollsString = "183";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T03BowlWithSpire01 () {
		int[] rolls = { 1, 8, 2, 8, 5 };
		string rollsString = "182/5";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T04BowlWithSpire02 () {
		int[] rolls = { 1, 9, 3, 5, 5 };
		string rollsString = "1/355";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T05BowlWithSpire03 () {
		int[] rolls = { 1, 9 };
		string rollsString = "1/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T06BowlWithStrike () {
		int[] rolls = { 10, 3, 3, 10, 5 };
		string rollsString = "X 33X 5";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	// http://slocums.homestead.com/gamescore.html
	[Test]
	[Category ("Verification")]
	public void TG02GoldenCopyA () {
		int[] rolls = { 10, 7,3, 9,0, 10, 0,8, 8,2, 0,6, 10, 10, 10,8,1};
		string rollsString = "X 7/9-X -88/-6X X X81";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyB1of3 () {
		int[] rolls = { 10, 9,1, 9,1, 9,1, 9,1, 7,0, 9,0, 10, 8,2, 8,2,10};
		string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyB2of3 () {
		int[] rolls = { 8,2, 8,1, 9,1, 7,1, 8,2, 9,1, 9,1, 10, 10, 7,1};
		string rollsString = "8/819/718/9/9/X X 71";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	//http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyB3of3 () {
		int[] rolls = { 10, 10, 9,0, 10, 7,3, 10, 8,1, 6,3, 6,2, 9,1,10};
		string rollsString = "X X 9-X 7/X 8163629/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyC1of3 () {
		int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9};
		string rollsString = "72X X X X 7/X X 9/XX9";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyC2of3 () {
		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
		string rollsString = "X X X X 9-X X X X X9/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

}