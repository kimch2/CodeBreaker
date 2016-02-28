﻿using UnityEngine;
using System.Collections.Generic;

namespace net.peakgames.codebreaker {
	
	public class GameLogic {
		
		public const int MAX_NUMBERS = 4;
		public const int MAX_NUMBER_OF_POSSIBLE_VALUES = 10;

		private readonly int [] solution;
		public enum MatchType {NONE, WHITE, BLACK}

		public GameLogic(int [] solution) {
			this.solution = solution;
		}

		public Result Check(int [] guess) {
			int whites = 0;
			int blacks = 0;
			List<int> processed = new List<int> ();
			for (int i = 0; i < MAX_NUMBERS; i++) {
				if (guess [i] == solution [i]) {
					whites++;
					processed.Add (i);
				}
			}

			for (int i = 0; i < MAX_NUMBERS; i++) {
				for (int j = 0; j < MAX_NUMBERS; j++) {
					int aGuess = guess [i];
					if (!processed.Contains (j) && aGuess == solution [j]) {
						processed.Add (j);
						blacks++;
						break;
					}
				}
			}
			return new Result(whites, blacks);
		}

		private int [] CreateEmptyResult () {
			return new int[] { 
				(int)MatchType.NONE, 
				(int)MatchType.NONE, 
				(int)MatchType.NONE, 
				(int)MatchType.NONE
			};
		}
	}

	public class Result {
		public readonly int whiteCount;
		public readonly int blackCount;

		public Result(int white, int black) {
			this.whiteCount = white;
			this.blackCount = black;
		}

		public bool IsCorrect() {
			return this.whiteCount == GameLogic.MAX_NUMBERS;
		}

		public override string ToString () {
			return string.Format ("white {0} black {1} correct {2}", whiteCount, blackCount, IsCorrect()); 
		}
	}
}