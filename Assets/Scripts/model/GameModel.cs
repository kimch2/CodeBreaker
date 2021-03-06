﻿using System;
using System.Collections.Generic;
using net.peakgames.codebreaker.signals;

namespace net.peakgames.codebreaker {
	public class GameModel {
		
		[Inject]
		public RandomNumberInterface randomNumberGenerator { get; set; }

		private GameLogic gameLogic;
		private List<GuessResult> guessList;
		private int numberOfGuesses;
		public int NumberOfGuesses {
			get { return this.numberOfGuesses; }
			set { this.numberOfGuesses = value; }
		}

		public void StartGame() {			
			int[] solution = GameLogic.CreateRandomSolution (randomNumberGenerator);
			this.gameLogic = new GameLogic (solution);
			this.guessList = new List<GuessResult> ();
			this.numberOfGuesses = 0;
		}

		public GuessResult MakeAGuess(int [] guess) {
			GuessResult result = 
				new GuessResult (
					guess, 
					this.gameLogic.Check (guess));
			this.guessList.Add( result );
			numberOfGuesses++;
			return result;
		}

	}

	public class GuessResult {
		public int[] guess;
		public Result result;

		public GuessResult(int [] guess, Result result) {
			this.guess = guess;
			this.result = result;
		}
	}
}
