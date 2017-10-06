using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anser_Save : MonoBehaviour {
	public float anserNum;	//
	public Slider slider;	//Sliderコンポーネント取得用
	public Text text;		//Textコンポーネント取得用

	public void SaveNum () {
		anserNum = slider.value;		//スライド値を取得
		text.text = anserNum.ToString("000");
//		Debug.Log("Test" + anserNum);	//スライド値取得Log		
	}
}
