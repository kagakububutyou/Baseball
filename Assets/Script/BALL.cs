using UnityEngine;
using System.Collections;

//	ボールを数えるスクリプト
public class BALL : MonoBehaviour {

	public float left		= 10.0f;	//	画面の左から何マスか
	public float top		= 10.0f;	//	画面の上から何マスか
	public float width		= 100.0f;	//	文字の表示する横幅
	public float height		= 20.0f;	//	文字の表示する縦幅
	
	public float beeline	= 10.0f;	//	一文字の幅
	
	private int BallCount	= 0;		//　ストライクの数
	
	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
		
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
		if(BallCount >= 4)
		{
			GameObject.Find("GameManager").SendMessage("OnBase");

			BallCount = 0;

		}
	}
	
	// 衝突した弾を
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Ball(Clone)")
		{
			//	ボールをインクリメント
			BallCount++;
			
			//	削除する
			Destroy(collision.gameObject);
		}
	}

	//	GUIに関する関数
	void OnGUI()
	{
		GUI.Label (new Rect (left, top, width, height), "B");

		//　ボール
		for(int i = 1; i <= BallCount; i++)
		{
			GUI.Label (new Rect (left + beeline + (beeline * i), top, width, height), "●");
		}
	}
}
