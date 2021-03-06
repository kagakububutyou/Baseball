﻿using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	public float speed		= -30.0f; 	// 弾のスピード

	public float Curve		= 0.0f;		//	カーブの度合い

	public static bool IsHitBatt	= false;	//	バットに当たったか

	public float LightCurve	=  7.0f;	//	右カーブ
	public float LeftCurve	= -7.0f;	//	左カーブ

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		IsHitBatt = false;

		// ホームベース向きに速度を渡してあげます
		rigidbody.velocity = new Vector3(speed, 0, speed);
	}

	// 毎フレーム呼ばれます
	void Update ()
	{

		if(LightCurve > Curve && LeftCurve < Curve)
		{
			//	カーブ
			Curve += Input.GetAxisRaw("1P");
		}

		//	カーブするときの処理
		if(Input.GetAxisRaw("Horizontal") != 0 && IsHitBatt == false)
		{
			rigidbody.velocity = new Vector3(speed + Curve, 0, speed - Curve);
		}else
		{
			Curve = 0;
		}

		//	ボールが止まったら消す
		if(rigidbody.velocity == Vector3.zero)
		{
			//GameObject.Find("OUT").SendMessage("StopBall");
			Destroy(gameObject);
		}
	}

	//	当たり判定
	void OnCollisionEnter(Collision collision)
	{
		//	壁にあたったら
		if(collision.gameObject.name == "Wall")
		{

			//	動きを止めて
			//rigidbody.velocity = Vector3.zero;
			//	回転を止める
			//rigidbody.angularVelocity = Vector3.zero;
			//	カーブを止める
			IsHitBatt = true;
		}
		//	バットに当たったら
		if(collision.gameObject.name == "Batter")
		{
			//	カーブを止める
			IsHitBatt = true;
		}
	}
}
