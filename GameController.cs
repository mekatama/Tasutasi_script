﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	//ゲームステート
	enum State{
		Ready,
		Play,
		Anser,
		Result
	}

	State state;
	public int calcNum;			//計算させる数の個数
	public int[] panelNum;		//計算用行列変数
	public int panelNumTotal;	//合計
	public int panelDestroyNum;	//生成後に削除したpanel数
	public bool isAnser;		//解答したフラグ
	public bool isSeikai;		//正解フラグ

	public float startTime = 1.5f;	//UIのSTARTを表示する時間
	float time = 0f;				//UIのSTARTを表示する時間用の変数
	public float resultTime = 1.5f;	//UIの〇✖を表示する時間
	float time_marubatu = 0f;		//UIの〇✖を表示する時間用の変数

	public Canvas startCamvas;		//Canvas_Start
	public Canvas inputCamvas;		//Canvas_Input
	public Canvas maruCamvas;		//Canvas_Maru
	public Canvas batuCamvas;		//Canvas_Batu
	public PanelSpawn ps;			//PanelSpawn1

	void Start () {
		inputCamvas.enabled = false;	//InputUI非表示
		maruCamvas.enabled = false;		//maruUI非表示
		batuCamvas.enabled = false;		//batuUI非表示
		calcNum = 2;					//【仮】後からスタート時に選択予定
		Ready();						//ステート変更
		time = 0;						//UIのSTARTを表示する時間用の変数の初期化
	}
	
	void LateUpdate () {
		//ステートの制御
		switch(state){
			//START表示
			case State.Ready:
				time += Time.deltaTime;
				if(time > startTime){
					startCamvas.enabled = false;	//StartUI非表示
					GameStart();					//ステート変更
				}
				Debug.Log("State.Ready");
				break;
			//ゲーム中
			case State.Play:
				Debug.Log("State.Play");
				ps.panelSpawn = true;				//panel生成するフラグon
				isAnser = false;
				//panel出現数と削除数を比較
				if(calcNum == panelDestroyNum){
					Anser();						//ステート変更
				}
				break;
			//回答中
			case State.Anser:
				inputCamvas.enabled = true;			//InputUI表示
				Debug.Log("State.Anser");
				//解答したら、以下を呼び出せば良さそう
				if(isAnser == true){
					Result();	//ステート変更
				}
				break;
			//〇✖表示
			case State.Result:
				//ここで〇✖の表示をする
				if(isSeikai){
					maruCamvas.enabled = true;		//maruUI表示
				}else{
					batuCamvas.enabled = true;		//batuUI表示
				}
				inputCamvas.enabled = false;		//InputUI非表示

				//指定時間で〇✖を非表示にする
				time_marubatu += Time.deltaTime;
				if(time_marubatu > resultTime){
					maruCamvas.enabled = false;		//maruUI非表示
					batuCamvas.enabled = false;		//batuUI非表示

					//イロイロ初期化
					panelDestroyNum = 0;			//panel削除数を初期化
					ps.panelTotalNum = 0;			//panelの総数を初期化
					panelNum[0] = 0;				//panelの数字を初期化
					panelNum[1] = 0;				//panelの数字を初期化
					time_marubatu = 0;				//〇✖表示時間を初期化
					GameStart();	//ステート変更
				}
				Debug.Log("State.Result");
				break;
		}
	}

	void Update () {
		//未使用
	}

	void Ready(){
		state = State.Ready;
	}

	void GameStart(){
		state = State.Play;
	}

	void Anser(){
		state = State.Anser;
		//合計を計算
		panelNumTotal = panelNum[0] + panelNum[1];
		Debug.Log("Goukei = " + panelNumTotal);

		//ここで、最後の集計用に正誤を保存するかもしれない
	}

	void Result(){
		state = State.Result;
	}
}
