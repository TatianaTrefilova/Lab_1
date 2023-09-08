using UnityEngine;

public class FinishZone : MonoBehaviour
{
	// Ссылка на менеджер игры
	public GameManager gameManager;

	// Когда объект входит в зону финиша, менеджер игры
	// получает сообщение, что текущая игра закончилась
	void OnTriggerEnter(Collider other)
	{
		gameManager.FinishedGame();
	}
}
