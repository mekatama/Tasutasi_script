using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawn : MonoBehaviour {
	public GameObject[] panelObject;	//panelのプレハブを配列で管理
	public GameObject[] panelObject_i;	//panel(image)のプレハブを配列で管理
	public GameObject gameController;	//GameController取得
	public bool panelSpawn = false;		//pane出現フラグ
	public float timeOut;				//panelを出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private int panelType;				//panelの種類
	private int panelImageType;			//panelの絵柄種類
	public int panelTotalNum;			//panelの総数
	private int spawnType;				//生成位置の種類(上0 左1 右2)
	private GameObject kariPaneru;		//仮代入用

	void Start () {
	}

	void Update () {
		if(panelSpawn){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			//時間判定→パネル生成
			timeElapsed += Time.deltaTime;	//経過時間の保存
			if(panelTotalNum < gc.calcNum){	//GameControllerで生成数を管理
				if(timeElapsed >= timeOut){	//指定した経過時間に達したら生成
					PanelGo();
					panelTotalNum ++;		//カウンター
				}
			}
		}
	}

	public void PanelGo(){
		float x_pos = Random.Range(-2.0f, 2.0f);	//ランダムで出現位置を決める
		float y_pos = Random.Range(0.0f, 5.0f);		//ランダムで出現位置を決める
		panelImageType = Random.Range(0, 2);		//ランダムで出現panelの絵柄を選出
		panelType = Random.Range(0, 2);				//ランダムで出現panelを選出
		spawnType = Random.Range(0, 3);				//ランダムで出現する位置を選出
		timeOut = 1.5f;								//【仮】出現させたい時間間隔
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();

		//生成位置により、出現位置を設定する
		switch(spawnType){
			case 0:				//upから生成
				y_pos = 5.5f;
				break;
			case 1:				//leftから生成
				x_pos = -2.5f;
				break;
			case 2:				//rightから生成
				x_pos = 2.5f;
				break;
		}

		//panelを生成する
		//数字のみ出現
		if(gc.imageUse == 0){
			kariPaneru = panelObject[panelType];
		//数字と絵柄のランダム
		}else if(gc.imageUse == 1){
			if(panelImageType == 0){
				kariPaneru = panelObject[panelType];
			}else{
				kariPaneru = panelObject_i[panelType];
			}
		//絵柄のみ出現
		}else{
			kariPaneru = panelObject_i[panelType];
		}

		GameObject panel = (GameObject)Instantiate(
			kariPaneru,					//生成するpanel
			new Vector2(x_pos, y_pos),	//生成時の位置
			transform.rotation			//生成時の角度
		);
		Debug.Log("PanelGo!!");

		//コンポーネント取得
		Rigidbody2D panelRigidbody = panel.GetComponent<Rigidbody2D>();

		//生成位置により、addforceする方向を設定する
		switch(spawnType){
			case 0:													//upから生成
				//panel生成時にaddforce
				panelRigidbody.AddForce(new Vector2(0.0f, -50.0f));	//addforce
				break;
			case 1:													//leftから生成
				panelRigidbody.AddForce(new Vector2(30.0f, 0.0f));	//addforce
				break;
			case 2:													//rightから生成
				panelRigidbody.AddForce(new Vector2(-30.0f, 0.0f));	//addforce
				break;
		}

		//panel生成用の時間をリセット
		timeElapsed = 0.0f;
	}
}