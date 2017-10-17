using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	//ゲームステート
	enum State{
		Ready,
		Play,
		Anser
	}

	State state;
	public int calcNum;			//計算させる数の個数
	public int[] panelNum;		//計算用ぎ行列変数
	public int panelNumTotal;	//合計
	public int panelDestroyNum;	//生成後に削除したpanel数

	public float startTime = 1.5f;	//UIのSTARTを表示する時間
	float time = 0f;				//UIのSTARTを表示する時間用の変数

	public Canvas startCamvas;		//Canvas_Start
	public Canvas inputCamvas;		//Canvas_Input
	public PanelSpawn ps;			//PanelSpawn1

	void Start () {
		inputCamvas.enabled = false;	//InputUI非表示
		calcNum = 2;	//【仮】後からスタート時に選択予定
		Ready();		//ステート変更
		time = 0;		//UIのSTARTを表示する時間用の変数の初期化
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
				//panel出現数と削除数を比較
				if(calcNum == panelDestroyNum){
					Anser();						//ステート変更
				}
				break;
			//回答中
			case State.Anser:
				inputCamvas.enabled = true;			//InputUI表示
				Debug.Log("State.Anser");
				break;
		}
	}


	void Update () {
//		time += Time.deltaTime;
//		if(time > startTime){
//			startCamvas.enabled = false;	//StartUI非表示
//			GameStart();					//ステート変更
//		}

		//【仮】この計算はアップデートで判定したくない
		panelNumTotal = panelNum[0] + panelNum[1];
		Debug.Log("Goukei = " + panelNumTotal);
	}

	void Ready(){
		state = State.Ready;
	}

	void GameStart(){
		state = State.Play;
	}

	void Anser(){
		state = State.Anser;
	}
}
