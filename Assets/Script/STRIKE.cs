using UnityEngine;
using System.Collections;


//	審判に関するスクリプト
public class STRIKE : MonoBehaviour {

	public float left		= 10.0f;	//	画面の左から何マスか
	public float top		= 10.0f;	//	画面の上から何マスか
	public float width		= 100.0f;	//	文字の表示する横幅
	public float height		= 20.0f;	//	文字の表示する縦幅

	public float beeline	= 20.0f;	//	一文字の幅

	private int StrikeCount	= 0;		//　ストライクの数
	private int OutCount	= 0;		//	アウトカウント
	
	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
	
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
		//	3ストライクで1アウト
		if(StrikeCount >= 3)
		{
			OutCount++;

			StrikeCount = 0;
		}
	}

	// 衝突した弾を
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Ball(Clone)")
		{
			//	ストライクをインクリメント
			StrikeCount++;

			//	削除する
			Destroy(collision.gameObject);
		}
	}

	//	GUIに関する関数
	void OnGUI()
	{
		GUI.Label (new Rect (left, top + height, width, height), "S");
		GUI.Label (new Rect (left, top + (height * 2), width, height), "O");

		//　ストライク
		for(int i = 1; i <= StrikeCount; i++)
		{
			GUI.Label (new Rect (left + beeline + (beeline * i), top + height, width, height), "●");
		}

		//　アウト
		for(int i = 1; i <= OutCount; i++)
		{
			GUI.Label (new Rect (left + beeline + (beeline * i), top + (height * 2), width, height), "●");
		}
	}
}
