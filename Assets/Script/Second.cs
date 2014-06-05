using UnityEngine;
using System.Collections;

public class Second : MonoBehaviour {

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
		collider.isTrigger = true;
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
		var buttan = Input.GetKey(KeyCode.Joystick2Button4);

		if(buttan)
		{
			GameObject.Find("GameManager").SendMessage("GetSecondBH");
		}
	}

	//	弾がとっ待った時に2ndBHにあったら
	private void OnTriggerStay(Collider collider)
	{
		if(collider.gameObject.name == "Ball(Clone)" && collider.gameObject.rigidbody.velocity == Vector3.zero)
		{
			Debug.Log("2BH");
			
			MoveBall.IsHitBatt = false;
			
			//	2BH関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetSecondBH");
			
			Destroy(collider.gameObject);
		}
	}
}
