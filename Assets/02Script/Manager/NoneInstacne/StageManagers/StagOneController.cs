using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StagOneController : MonoBehaviour
{
    [SerializeField] PlayerController pcontroller;
    [SerializeField] Vector2[] SpawnPoint;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] Camera _cam;
    [SerializeField] Vector2[] cameraLockPoint;
    [SerializeField] GameObject boss;

    public event Action<float> OnLifeChanged;

    public int unitCounter;

    
    int playerMaxLife;
    bool canCamMove;
    bool isbossSpawn;

    private void PlayerLifeChecker()
    {
        playerMaxLife--;
        
        //OnLifeChanged?.Invoke((float)playerMaxLife / GameController.instance._maxPlayerLife); @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        OnLifeChanged?.Invoke((float)playerMaxLife / 5);

        if (playerMaxLife > 0)
        {
            StartCoroutine(ReSpawn());
        }
        else
        {
            gameOverMenu.SetActive(true);
        }
    }

    // 카메라 작업 필요 / 조건 : 특정 위치에 도달할시 카메라 이동 불가 할것, 특정 위치에서 이동가능 상태가 되면 다시 카메라 이동이 허용될 것
    private void Update()
    {
        if (unitCounter <= 0 && !isbossSpawn)
        {
            isbossSpawn = true;
            boss.SetActive(true);
        }
        //_cam.transform.position += pcontroller.state.pMoveSpeed;
    }

    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(1f);
        pcontroller.InitPlayerCharacterNonGenInstance(SpawnPoint[0]);
        yield break;
    }

    public void Restart()
    {
        SceneLoader.instance.SceneChanger(Scenes.StageOne);
    }

    public void MainMenu()
    {
        SceneLoader.instance.SceneChanger(Scenes.MainMenu);
    }

    private void Awake()
    {
        playerMaxLife = GameController.instance._maxPlayerLife;
        unitCounter = 3; // 임시 유닛 카운터 후에 재작업 필요
        isbossSpawn = false;
        playerMaxLife = 5;
        gameOverMenu.SetActive(false);
        pcontroller.InitPlayerCharacter(SpawnPoint[0]);
        canCamMove = true;
    }

    private void OnEnable()
    {
        pcontroller.OnPlayerDead += PlayerLifeChecker;
    }

    private void OnDisable()
    {
        pcontroller.OnPlayerDead -= PlayerLifeChecker;
    }
}
