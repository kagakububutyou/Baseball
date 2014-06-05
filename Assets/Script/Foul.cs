using UnityEngine;
using System.Collections;

//	ファールのスクリプト
public class Foul : MonoBehaviour {

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{

	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
		
	}

	//	弾が止まった時にファールゾーンにあったら
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "Ball(Clone)" && MoveBall.IsHitBatt == true)
		{
			Debug.Log("ファール");

			MoveBall.IsHitBatt = false;

			//	ファールカウント関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetFoul");

			//	削除する
			Destroy(collider.gameObject);
		}
	}
}
