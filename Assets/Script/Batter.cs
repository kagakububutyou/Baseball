using UnityEngine;
using System.Collections;

//	何らかのスピードでとあるオブジェクトの周りを回転するスクリプト
public class Batter : MonoBehaviour {

	//	オブジェクト
	public GameObject Batt;
	//	一秒あたりの回転角度
	public float Angle = -360.0f;

	//最大角度
	public const float AngleMax = -90.0f;
	//最低角度
	public const float AngleMin = 150.0f;

	//	回転の中心を取るために使う変数
	private Vector3 targetPos;


	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		// targetに"Sample"の名前のオブジェクトのコンポーネントを見つけてアクセスする
		Transform target = Batt.transform;
		//	変数targetPosにSmpleの位置情報を取得
		targetPos = target.position;
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{

		//	バットの振る早さ
		var angle = 0.0f;
		//	なんのボタンを押しているか
		var buttan = Input.GetKey(KeyCode.Joystick2Button0);

		// 現在の回転角度を0～360から-180～180に変換
		float rotateY = (transform.eulerAngles.y > 180) ?
						transform.eulerAngles.y - 360: transform.eulerAngles.y;

		//	押たらバットを構える
		if(buttan == true && rotateY <= AngleMin)
		{
			angle = -Angle;
		}
		//	離したらバットを振る
		if(buttan == false && rotateY >= AngleMax && transform.eulerAngles.y != 45.00001f)
		{
			angle = Angle * 2.0f;
		}

		// Sampleを中心にし自分を現在の横方向に、毎秒angle分だけ回転する。
		Vector3 axis = transform.TransformDirection(1,0,0);
		transform.RotateAround(targetPos, axis, angle * Time.deltaTime);
	}
}