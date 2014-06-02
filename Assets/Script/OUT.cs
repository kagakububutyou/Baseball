using UnityEngine;
using System.Collections;

public class OUT : MonoBehaviour {

	private bool IsHitBatt = false;

	public bool OrStopBall = false;
	
	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
		IsHitBatt = false;

		collider.isTrigger = true;
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
		
	}
	
	//	バットにあったったら呼ばれます
	public void HitBatt()
	{
		IsHitBatt = true;
	}
	public void StopBall()
	{
		OrStopBall = true;


	}

	//	弾がとっ待った時にファールゾーンにあったら
	private void OnTriggerStay(Collider collider)
	{
		Debug.Log("＼(＾o＾)／");

		if(collider.gameObject.name == "Ball(Clone)" && collider.gameObject.rigidbody.velocity == Vector3.zero)
		{
			Debug.Log("アウト");
			
			IsHitBatt = false;
			
			//	ファールカウント関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetOUT");

			Destroy(collider.gameObject);
		}
	}
}
