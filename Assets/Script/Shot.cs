using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	
	public GameObject Tama; // 弾のオブジェクト

	GameObject axis = GameObject.Find("Ball");	//	弾があるかどうか


	public float speed = 0;	//	スピード

	public int BallCount = 0;	//	ボールの数


	//	弾の座標
	private const float Tama_x = 125.0436f;
	private const float Tama_y = 0.5f;
	private const float Tama_z = 146.1412f;

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{

	}
	// 毎フレーム呼ばれます
	void Update () 
	{
		//　なんのボタンを押しているか
		var buttan = Input.GetKeyDown(KeyCode.Joystick1Button0);

		//	Aボタンをおした時
		if(buttan)
		{
			// 発射位置に弾を生成します 
			Instantiate(Tama,transform.position,transform.rotation);

			BallCount++;
		}
	}
}
