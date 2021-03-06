﻿using strange.extensions.signal.impl;
using net.peakgames.codebreaker.views;
using net.peakgames.codebreaker.audio;

namespace net.peakgames.codebreaker.signals {
	public enum LoginType {
		Guest, Facebook
	}
	public class StartAppSignal : Signal {}
	public class StartNewGameSignal : Signal {}
	public class PlayerGuessSignal : Signal<int []> {}
	public class GuessResultSignal : Signal<int [], Result> { public GuessResultSignal() {AddListener((guess, result)=>{});}}
	public class GameOverSignal : Signal<int [], bool> { public GameOverSignal() { AddListener((solution, isNewRecord) => {});}}
	public class LoginRequestSignal : Signal<LoginType> {}
	public class LoginSuccessSignal : Signal<LoginType> { public LoginSuccessSignal() { AddListener((loginType) => {});}}
	public class LoginFailedSignal : Signal<LoginType, string> { public LoginFailedSignal() { AddListener((loginType, errorMessage) => {});}}
	public class PlaySoundSignal : Signal<GameSound> {}
}
