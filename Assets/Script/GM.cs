using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {


	public float left		= 10.0f;	//	画面の左から何マスか
	public float top		= 10.0f;	//	画面の上から何マスか
	public float width		= 100.0f;	//	文字の表示する横幅
	public float height		= 20.0f;	//	文字の表示する縦幅
	
	public float beeline	= 10.0f;	//	一文字の幅
	public int	FontSize	= 50;		//	文字サイズ
	
	private int BallCount	= 0;		//　ボールの数
	private int StrikeCount	= 0;		//　ストライクの数
	private int OutCount	= 0;		//	アウトカウント

	public static int[] BaseOnBalls = new int[4];		//	四球
	public int Base = 0;

	private float TimeCount		= 0.0f;		//	ファール表示時間
	public float TimeCountMax	= 60.0f;	//	ファール表示最大時間


	private int Scora1P		= 0;		//	得点
	private int Scora2P		= 0;



	public bool OrFoul		= false;	//	ファールかどうか
	public bool OrStrike	= false;	//	ストライクかどうか
	public bool OrBall		= false;	//	
	public bool OrOut		= false;
	public bool Or2ndBH		= false;

	private string String	= "";	//	ボールとかストライクとかを表示する

	//	スクリプトが有効になったとき一回だけ呼ばれます
	//	初期化とかに使う
	void Start () 
	{
		for(int i = 0; i < 4; i++)
		{
			BaseOnBalls[i] = 0;
		}
		Base = 0;
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
		//Debug.Log(TimeCount);

		for(int i = 0; i < 4; i++)
		{
			Debug.Log(BaseOnBalls[i]);
		}

		Debug.Log("0"+BaseOnBalls[0]);
		Debug.Log("1"+BaseOnBalls[1]);
		Debug.Log("2"+BaseOnBalls[2]);
		Debug.Log("3"+BaseOnBalls[3]);

		Count();
	}


	//	
	public void OffBase()
	{
		for(int i = 1; i <= Base; i++)
		{
			GameObject.Find("Runner").SendMessage("ThisDestroy");
		}
	}

	//	出塁関数
	public void OnBase()
	{
		//GameObject.Find("Runner").SendMessage("OnBase");


		for(int i = 0; i <= Base; i++)
		{
			if(BaseOnBalls[i] >= 1)
			{
				//	出塁
				//GameObject.Find(BaseOnBalls[i].ToString()).SendMessage("GoBase");
				GameObject.Find("Runner"+i.ToString()).SendMessage("OnBase");
			}
			else
			{
				//GameObject.Find("Runner(Clone)").SendMessage("ThisDestroy");
			}
		}
		//GameObject.Find("Runner").SendMessage("GoBase");
	}

	//	ボールだったら呼ばれる関数
	public void GetBallCount()
	{
		OrBall = true;

		String = "ボール";
	}

	//	ストライクだったら呼ばれる関数
	public void GetStrikeCount()
	{
		OrStrike = true;

		String = "ストライク";
	}

	public void GetOUT()
	{
		OrOut = true;

		String = "アウト";
	}

	//	ファールだったら呼ばれる関数
	public void GetFoul()
	{
		OrFoul = true;

		String = "ファール";
	}
	public void GetSecondBH()
	{
		Or2ndBH = true;

		String = "セカンドベースヒット";
	}

	//	ファールしたらカウントを取る
	public void Count()
	{
		if(OrFoul == true || OrStrike == true || OrBall == true || OrOut == true
		|| Or2ndBH == true)
		{
			TimeCount += 1;
			
			//	ファール表示時間
			if(TimeCount >= TimeCountMax)
			{
				switch(String)
				{
				case "ファール":
					
					Foul();

					OrFoul = false;

					break;
				case "ストライク":
					
					Strike();

					OrStrike = false;

					break;

				case "ボール":

					Ball();

					OrBall = false;

					break;

				case "アウト":

					OUT();

					OrOut = false;

					break;

				case "セカンドベースヒット":

					SecondBH();

					Or2ndBH = false;

					break;
				default:
					
					Debug.Log(String);
					
					break;
					
				}
				TimeCount = 0;
			}
		}
	}

	//	ファールの処理
	public void Foul()
	{
		if(StrikeCount < 2)
		{
			StrikeCount++;
		}
	}
	//	ストライクの処理
	public void Strike()
	{
		//	ストライクをインクリメント
		StrikeCount++;
		
		//	3ストライクで1アウト
		if(StrikeCount >= 3)
		{
			GetOUT();
		}
	}
	//	ボールの処理
	public void Ball()
	{
		//	ボールをインクリメント
		BallCount++;
		
		//	フォアボールでカウントリセット
		if(BallCount >= 4)
		{
			//OffBase();

			BallCount = 0;

			for(int i = 0; i <= Base; i++)
			{
				//	四球インクリメント
				BaseOnBalls[i]++;
			}

			OnBase();

			Base++;
		}
	}
	//	アウト処理
	public void OUT()
	{
		OutCount++;

		StrikeCount = 0;

		BallCount = 0;
	}

	//	2塁打の処理
	public void SecondBH()
	{
		//OffBase();

		for(int i = 0; i <= Base; i++)
		{
			BaseOnBalls[i] += 2;
		}

		OnBase();

		Base++;
	}
	//	GUIに関する関数
	void OnGUI()
	{
		//	文字の色とサイズを変更
		var localStyle = new GUIStyle();
		localStyle.normal.textColor = Color.black;
		localStyle.fontSize = FontSize;

		//CalcSize( new GUIContent(String) )で文字列の幅、高さを取得できる
		var stringSize = localStyle.CalcSize( new GUIContent(String) );

		//	画面の真ん中に表示
		if(TimeCount > 0 && TimeCount < TimeCountMax)
		{
			GUI.Label (new Rect (Screen.width/2-stringSize.x/2, Screen.height/2-stringSize.y/2, stringSize.x, stringSize.y), String, localStyle);
		}

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

		GUI.Label (new Rect (left + (beeline * 10), 0, width, height), "0回オモテ");

		GUI.Label (new Rect (left + (beeline * 10), top + (height * 1), width, height), Scora1P.ToString());
		GUI.Label (new Rect (left + (beeline * 10), top + (height * 2), width, height), Scora2P.ToString());
	}
}
