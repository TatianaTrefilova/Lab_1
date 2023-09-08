// ����������� ���������
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// ���� ��� ����������� � ������ ��������
	public Transform spawnPoint;
	public GameObject player;

	// �����, ������� ������������ ��������� ����
	private float elapsedTime = 0;
	private bool isRunning = false;
	private bool isFinished = false;

	// ������ � ����������� ������ �� ����� �������
	private FirstPersonController fpsController;


	// �������������
	void Start ()
	{
		// ������� ������ ����������� ������
		fpsController = player.GetComponent<FirstPersonController> ();
	
		// ������ ����
		StartGame();
	}

	private void StartGame()
	{
		// ����� � ��������� ���������� ����
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;

		// ���������� ������ � ����� ������
		PositionPlayer();
	}

	// ���������� ���������� ���� ��� �� ����
	void Update ()
	{
		// ���� ���� ��������, ���������� ����������
		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}

		// ����� �� ����, ���� ������ ������� Esc
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}

	// ����������, ����� ������ ����� ����������� ������� � ����� ������
	public void PositionPlayer()
	{
		player.transform.position = spawnPoint.position;
		player.transform.rotation = spawnPoint.rotation;
	}

	// ����������, ����� ����� ������ � �������� ����
	public void FinishedGame()
	{
		// ��������� ������, ������� ������������ ��������� ����
		isRunning = false;
		isFinished = true;
		// ������ �� ����������� ������
		fpsController.enabled = false;
	}

	// ������������ �����
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	// � ���� ������� ��������� ����������� ���������������� ��������� (GUI) ����������� �����
	void OnGUI() {
		
		// ����������, ����� ����� �����������
		if(isFinished)
			{
			// ���������� ������������� ������� ��� ������ (��������� x � y, ������ � ������)
			Rect startButton = new Rect(Screen.width/2 - 120, Screen.height/2, 255, 30);

			// ���� �������� ���� �� ������ ��� ������ ������� Enter, ����������� ������������ �����
			if (GUI.Button(startButton, "������� Enter ��� ����������� ����") || Input.GetKeyDown(KeyCode.Return))
				ReloadScene();
			}

		// ���� ����� �������� ����, ���������� ��������� �����
		if (isFinished)
		{
			// ������� ��������� � ������������� �������
			GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "���� �����");

			// ������� ��������� �����
			GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
		}
		else if(isRunning)
		{
			// ���� ���� ��������, ���������� ������� ����� ������ 
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "���� �����");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
		}
	}
}
