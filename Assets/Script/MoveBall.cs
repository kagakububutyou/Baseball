using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	private int speed		= -30; 		// 弾のスピード

	public float Curve		= 0.0f;		//	カーブの度合い

	public float LightCurve	=  7.0f;	//	右カーブ
	public float LeftCurve	= -7.0f;	//	左カーブ

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		// ホームベース向きに速度を渡してあげます
		rigidbody.velocity = new Vector3(speed, 0, speed);
	}

	// 毎フレーム呼ばれます
	void Update () 
	{


		//	カーブ
		Curve += Input.GetAxisRaw("Horizontal");

		if(Input.GetAxisRaw("Horizontal") == 0)
		{
			Curve = 0;
		}


		Debug.Log(Curve);

		// ホームベース向きに速度を渡してあげます
		rigidbody.velocity = new Vector3(0, 0, - Curve);
	}

	//	壁にあたったら
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Wall")
		{
			//	動きを止めて
			rigidbody.velocity = Vector3.zero;
			//	回転を止める
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}