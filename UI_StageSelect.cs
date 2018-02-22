using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageSelect : MonoBehaviour {
	public Text highScore1;		//ハイスコアを表示するオブジェクト用
	public Text highScore2;		//ハイスコアを表示するオブジェクト用
	public Text highScore3;		//ハイスコアを表示するオブジェクト用
	public Text highScore4;		//ハイスコアを表示するオブジェクト用
	public Text highScore5;		//ハイスコアを表示するオブジェクト用
	public Text highScore6;		//ハイスコアを表示するオブジェクト用
	public Text highScore7;		//ハイスコアを表示するオブジェクト用
	public Text highScore8;		//ハイスコアを表示するオブジェクト用
	public Text highScore9;		//ハイスコアを表示するオブジェクト用
	public Text highScore10;	//ハイスコアを表示するオブジェクト用
	public Text highScore11;	//ハイスコアを表示するオブジェクト用
	public Text highScore12;	//ハイスコアを表示するオブジェクト用

	void Update () {
		//ハイスコア系テキストの表示
		highScore1.text = PlayerPrefs.GetFloat("HighScore1").ToString("000.000") + "s";
		highScore2.text = PlayerPrefs.GetFloat("HighScore2").ToString("000.000") + "s";
		highScore3.text = PlayerPrefs.GetFloat("HighScore3").ToString("000.000") + "s";
		highScore4.text = PlayerPrefs.GetFloat("HighScore4").ToString("000.000") + "s";
		highScore5.text = PlayerPrefs.GetFloat("HighScore5").ToString("000.000") + "s";
		highScore6.text = PlayerPrefs.GetFloat("HighScore6").ToString("000.000") + "s";
		highScore7.text = PlayerPrefs.GetFloat("HighScore7").ToString("000.000") + "s";
		highScore8.text = PlayerPrefs.GetFloat("HighScore8").ToString("000.000") + "s";
		highScore9.text = PlayerPrefs.GetFloat("HighScore9").ToString("000.000") + "s";
		highScore10.text = PlayerPrefs.GetFloat("HighScore10").ToString("000.000") + "s";
		highScore11.text = PlayerPrefs.GetFloat("HighScore11").ToString("000.000") + "s";
		highScore12.text = PlayerPrefs.GetFloat("HighScore12").ToString("000.000") + "s";
	}
}
