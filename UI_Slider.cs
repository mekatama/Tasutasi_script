using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Slider : MonoBehaviour {
	private Slider slider;		//Sliderコンポーネント取得用
	private float level;		//スライド値を入れる用
	public Text slideNumText;	//Textコンポーネント取得用


	void Start () {
		slider = GetComponent<Slider>();//Sliderコンポーネント取得
		slider.value = 1;				//スライド値の初期化
		level = slider.value;			//スライド値の変化判定用
	}
	
	void Update () {
		//スライド値が変化したら
		if (slider.value != level) {
			level = slider.value;		//スライド値の変化判定用に再設定
//			Debug.Log(slider.value);	//スライド値取得Log
			slideNumText.text = slider.value.ToString("000");
		}
	}

	//Sliderの値が変わる度にスクリプトのメソッドを呼び出す
    public void MoveSlider(){
		//ここ、使用するかどうかは未定
//		Debug.Log("Moving");
    }

}
