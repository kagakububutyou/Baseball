﻿using UnityEngine;
using System.Collections;

public class OUT : MonoBehaviour {

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
		collider.isTrigger = true;
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
		
	}

	//	弾がとっ待った時にファールゾーンにあったら
	private void OnTriggerStay(Collider collider)
	{
		if(collider.gameObject.name == "Ball(Clone)" && collider.gameObject.rigidbody.velocity == Vector3.zero)
		{
			Debug.Log("アウト");
			
			MoveBall.IsHitBatt = false;

			//	ファールカウント関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetOUT");

			Destroy(collider.gameObject);
		}
	}
}
