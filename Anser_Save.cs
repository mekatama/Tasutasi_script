using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anser_Save : MonoBehaviour {
	public float anserNum;	//
	public Slider slider;	//Sliderコンポーネント取得用
	public Text text;		//Textコンポーネント取得用
	public GameObject gameController;	//GameController取得

	public void SaveNum () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();

		anserNum = slider.value;		//スライド値を取得
		text.text = anserNum.ToString("000");

		//計算の合計と比較
		if(gc.panelNumTotal == anserNum){
			//正解
			Debug.Log("Good Job !!");
		}else{
			//間違い
			Debug.Log("Miss !!");
		}
	}
}
