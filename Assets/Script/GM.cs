using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {


	public float left		= 10.0f;	//	画面の左から何マスか
	public float top		= 10.0f;	//	画面の上から何マスか
	public float width		= 100.0f;	//	文字の表示する横幅
	public float height		= 20.0f;	//	文字の表示する縦幅
	
	public float beeline	= 10.0f;	//	一文字の幅
	
	private int BallCount	= 0;		//　ボールの数
	private int BaseOnBalls	= 0;		//	四球
	private int StrikeCount	= 0;		//　ストライクの数
	private int OutCount	= 0;		//	アウトカウント

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
		
	}

	//	ボールだったら呼ばれる関数
	public void GetBallCount()
	{
		//	ボールをインクリメント
		BallCount++;

		//	フォアボールでカウントリセット
		if(BallCount >= 4)
		{
			BallCount = 0;

			//	四球インクリメント
			BaseOnBalls++;

			OnBase();
		}
	}


	//	出塁関数
	public void OnBase()
	{
		if(BaseOnBalls < 4)
			//	四球出塁
			GameObject.Find(BaseOnBalls.ToString()).SendMessage("GoBase");
	}



	//	ストライクだったら呼ばれる関数
	public void GetStrikeCount()
	{
		//	ストライクをインクリメント
		StrikeCount++;
		
		//	3ストライクで1アウト
		if(StrikeCount >= 3)
		{
			OutCount++;
			
			StrikeCount = 0;
		}
	}

	//	GUIに関する関数
	void OnGUI()
	{
		GUI.Label (new Rect (left, top, width, height), "B");
		GUI.Label (new Rect (left, top + height, width, height), "S");
		GUI.Label (new Rect (left, top + (height * 2), width, height), "O");

		//　ボール
		for(int i = 1; i <= BallCount; i++)
		{
			GUI.Label (new Rect (left + beeline + (beeline * i), top, width, height), "●");
		}
		
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
