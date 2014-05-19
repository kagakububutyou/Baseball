using UnityEngine;
using System.Collections;

//	何らかのスピードでとあるオブジェクトの周りを回転するスクリプト
public class Batter : MonoBehaviour {

	//	変数
	public GameObject Batt;
	//	一秒あたりの回転角度
	public float Anglu = -360.0f;

	//最大角度
	public const float AngluMax = -90.0f;
	//最低角度
	public const float AngluMin = 150.0f;

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
		var anglu = 0.0f;
		//var count = 0;
		var buttan = Input.GetKey(KeyCode.Joystick2Button0);

		// 現在の回転角度を0～360から-180～180に変換
		float rotateY = (transform.eulerAngles.y > 180) ?
						transform.eulerAngles.y - 360: transform.eulerAngles.y;

		if(buttan == true && rotateY <= AngluMin)
		{
			anglu = -Anglu;
		}
		if(buttan == false && rotateY >= AngluMax && transform.eulerAngles.y != 45.00001f)
		{
			anglu = Anglu * 1.5f;
		}

		// Sampleを中心にし自分を現在の横方向に、毎秒angle分だけ回転する。
		Vector3 axis = transform.TransformDirection(1,0,0);
		transform.RotateAround(targetPos, axis, anglu * Time.deltaTime);

		Debug.Log(rotateY);
	}
}
