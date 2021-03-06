﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Slider : MonoBehaviour {
	private Slider slider;				//Sliderコンポーネント取得用
	private float level;				//スライド値を入れる用
	public Text slideNumText;			//Textコンポーネント取得用
	public GameObject gameController;	//GameController取得

	AudioSource audioSource;			//AudioSourceコンポーネント取得用
	public AudioClip audioClipMove;		//Move SE

	void Start () {
		slider = GetComponent<Slider>();//Sliderコンポーネント取得
		slider.value = 1;				//スライド値の初期化
		level = slider.value;			//スライド値の変化判定用
		audioSource = gameObject.GetComponent<AudioSource>();		//AudioSourceコンポーネント取得
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		slider.maxValue = gc.sliderMaxValue;	//max Valueの変更

		//スライド値が変化したら
		if (slider.value != level) {
			level = slider.value;		//スライド値の変化判定用に再設定
			slideNumText.text = slider.value.ToString("00");
		}
	}

	//Sliderの値が変わる度にスクリプトのメソッドを呼び出す
    public void MoveSlider(){
		//スライド動かすとSEが鳴る
		audioSource.clip = audioClipMove;	//SE決定
		audioSource.Play ();				//SE再生
    }

}
