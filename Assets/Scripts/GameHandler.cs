using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeGame
{
	Classic,
	Brain
}
public class GameHandler : MonoBehaviour
{

	public static GameHandler Instance;
	public List<BallColor> BallsColor = new List<BallColor>();
	public TypeGame Type;

	private void Awake()
	{
		Instance = this;
	}


	public void SetGame(TypeGame type)
	{
		Type = type;
	}
	public void BallDestroy(int id)
	{
		foreach (var ball in BallsColor)
		{
			if (ball.gameObject.activeInHierarchy && id == ball.Id)
			{
				ball.DestroyBall();
				break;
			}
		}
		if (!HasActiveBall())
		{
			DisplayScoreHandler.Instance.UpdateTextLevel();
			foreach (var ball in BallsColor)
			{
				ball.ResetBall();
			}
			YandexSDK.instance.ShowInterstitial();
		}
	}
	private bool HasActiveBall()
	{
		foreach (var ball in BallsColor)
		{
			if (ball.gameObject.activeInHierarchy)
			{
				return true;
			}
		}
		return false;
	}
}
