using UnityEngine;
using System.Collections;

//	何らかのスピードでとあるオブジェクトの周りを回転するスクリプト
public class Batter : MonoBehaviour {

	//	変数
	public GameObject Batt;
	//	一秒あたりの回転角度
	public float anglu = -360.0f;

	//	回転の中心を取るために使う変数
	private Vector3 targetPos;


	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		// targetに"Sample"の名前のオブジェクトのコンポーネントを見つけてアクセスする
		Transform target = GameObject.Find("Sample").transform;
		//	変数targetPosにSmpleの位置情報を取得
		targetPos = target.position;

	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
		//var hor = "Horizontal_Joy1";

		if (Input.GetButtonDown("ButtanB")/* && transform.eulerAngles.y <= 150*/)
		{
			// Sampleを中心にし自分を現在の横方向に、毎秒angle分だけ回転する。
			Vector3 axis = transform.TransformDirection(1,0,0);
			transform.RotateAround(targetPos, axis, -1 * anglu * Time.deltaTime);
		}
		if (Input.GetButtonUp("ButtanB")/* && transform.eulerAngles.y <= 100*/)
		{
			// Sampleを中心にし自分を現在の横方向に、毎秒angle分だけ回転する。
			Vector3 axis = transform.TransformDirection(1,0,0);
			transform.RotateAround(targetPos, axis, anglu * Time.deltaTime);
		}
	}
}
