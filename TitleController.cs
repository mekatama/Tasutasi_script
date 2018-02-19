﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

	void Update(){
		//backキー
		if (Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();	//アプリ終了
		}
	}

	//セレクト画面用の制御関数
	public void OnSelectButtonClicked(){
		SceneManager.LoadScene("Select_yoko");	//シーンのロード
	}

	//遊び方ボタン用の制御関数
	public void OnHowToPlayButtonClicked(){
		SceneManager.LoadScene("HowToPlay_yoko");	//シーンのロード
	}

	//タイトルに戻るボタン用の制御関数
//	public void OnReturnTitleButtonClicked(){
//		SceneManager.LoadScene("Title");	//シーンのロード
//	}
	
	//アプリ終了
	public void OnExitButtonClicked(){
		Application.Quit();
		Debug.Log("exit");	
	}

	//Debug用ハイスコアリセットボタン
	public void OnResetButtonClicked(){
		PlayerPrefs.SetFloat("HighScore1", 0.0f);
	}
}
