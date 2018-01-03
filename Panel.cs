using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {
	public int panelNum;				//panelの番号を入れる
	public GameObject gameController;	//GameController取得

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "DestroyArea"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();

			//gamrControllerにpanelNumを渡して計算できそうか実験する
			if(gc.panelNum[0] == 0){
				gc.panelNum[0] = panelNum;
			}else if(gc.panelNum[1] == 0){
				gc.panelNum[1] = panelNum;
			}

			//削除したパネル数カウント
			gc.panelDestroyNum ++;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
