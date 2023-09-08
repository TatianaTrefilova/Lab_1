// Подключение библиотек
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Поля для подключения к другим объектам
	public Transform spawnPoint;
	public GameObject player;

	// Флаги, которые контролируют состояние игры
	private float elapsedTime = 0;
	private bool isRunning = false;
	private bool isFinished = false;

	// Доступ к контроллеру игрока из этого скрипта
	private FirstPersonController fpsController;


	// Инициализация
	void Start ()
	{
		// Находит скрипт контроллера игрока
		fpsController = player.GetComponent<FirstPersonController> ();
	
		// Запуск игры
		StartGame();
	}

	private void StartGame()
	{
		// Сброс к начальным установкам игры
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;

		// Перемещает игрока в точку спавна
		PositionPlayer();
	}

	// Обновление вызывается один раз за кадр
	void Update ()
	{
		// Если игра запущена, включается секундомер
		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}

		// Выход из игры, если нажата клавиша Esc
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}

	// Вызывается, когда игрока нужно переместить обратно в точку спавна
	public void PositionPlayer()
	{
		player.transform.position = spawnPoint.position;
		player.transform.rotation = spawnPoint.rotation;
	}

	// Вызывается, когда игрок входит в финишную зону
	public void FinishedGame()
	{
		// Установка флагов, которые контролируют состояние игры
		isRunning = false;
		isFinished = true;
		// Запрет на перемещение игрока
		fpsController.enabled = false;
	}

	// Перезагрузка сцены
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	// В этом разделе создается графический пользовательский интерфейс (GUI) программным путем
	void OnGUI() {
		
		// Вызывается, когда игрок финишировал
		if(isFinished)
			{
			// Определяет прямоугольную область для кнопки (кординаты x и y, ширина и высота)
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2, 255, 30);

			// Если выполнен клик по кнопке или нажата клавиша Enter, выполняется перезагрузка сцены
			if (GUI.Button(startButton, "Нажмите Enter для продолжения игры") || Input.GetKeyDown(KeyCode.Return))
				ReloadScene();
			}

		// Если игрок закончил игру, показывает финальное время
		if (isFinished)
		{
			// Выводит сообщение в прямоугольной области
			GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Ваше время");

			// Выводит финальное время
			GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
		}
		else if(isRunning)
		{
			// Если игра запущена, показывает текущее время игрока 
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Ваше время");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
		}
	}
}
