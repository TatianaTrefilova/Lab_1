using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
	// —сылка на менеджер игры
	public GameManager gameManager;

	// “риггер срабатывает, когда игрок входит в воду
	void OnTriggerEnter(Collider other)
	{
		// ѕеремещает игрока в точку спавна
		gameManager.ReloadScene();
	}
}
