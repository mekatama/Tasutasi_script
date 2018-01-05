using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anser_Save : MonoBehaviour {
	public float anserNum;				//スライド値を入れる
	public Slider slider;				//Sliderコンポーネント取得用
	public Text text;					//Textコンポーネント取得用
	public GameObject gameController;	//GameController取得

	public void SaveNum () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();

		anserNum = slider.value;		//スライド値を取得
		text.text = anserNum.ToString("000");

		//ここで、最後の集計用に正誤を保存するかもしれない
		int i = gc.syutudaiNumNow - 1;

		//計算の合計と比較
		if(gc.panelNumTotal == anserNum){
			//正解
			gc.seigo[i] = 1;				//配列に正解1を入れておく
			Debug.Log("配列番号[" + i + "]  = (正解)" + gc.seigo[i]);
//			Debug.Log("Good Job !!");
			gc.seikaiNum += 1;
			gc.isSeikai = true;
			gc.isAnser = true;
		}else{
			//間違い
			gc.seigo[i] = 2;				//配列に不正解2を入れておく
			Debug.Log("配列番号[" + i + "]  = (不正解)" + gc.seigo[i]);
//			Debug.Log("Miss !!");
			gc.isSeikai = false;
			gc.isAnser = true;
		}
	}
}
