using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawn : MonoBehaviour {
	public GameObject[] panelObject;	//panelのプレハブを配列で管理
	public GameObject gameController;	//GameController取得
	public bool panelSpawn = false;		//pane出現フラグ
	public float timeOut;				//panelを出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private int panelType;				//panelの種類
	private int panelTotalNum;			//panelの総数

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
		float x_pos = Random.Range(-2.0f,2.0f);	//ランダムで出現位置を決める
		panelType = Random.Range(0,2);			//ランダムで出現panelを選出
		timeOut = 1.5f;							//【仮】出現させたい時間間隔

		//panelを生成する
		GameObject panel = (GameObject)Instantiate(
			panelObject[panelType],		//生成するpanel
			new Vector2(x_pos, 5.5f),	//生成時の位置
			transform.rotation			//生成時の角度
		);

		//panel生成時にaddforce
		Rigidbody2D panelRigidbody = panel.GetComponent<Rigidbody2D>();	//コンポーネント取得
		panelRigidbody.AddForce(new Vector2(0.0f, -50.0f));				//addforce

		//【予定】生成位置により、addforceする方向を設定する

		//panel生成用の時間をリセット
		timeElapsed = 0.0f;
	}
}