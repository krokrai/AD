using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStateSO stateSO;
    [SerializeField] PlayerMovement movement;
    [SerializeField] Attack atk;

    public InputSystem_Actions _inputActions;

    public PlayerState state;

    bool isRecharge;
    float energyRechargeofRate = 1f;
    float time;

    WaitForSeconds delay = new WaitForSeconds(0.5f);

    public event Action<float> OnHPValueChanged;
    public event Action<float> OnEnergyValueChanged;
    public event Action OnPlayerDead;

    private void Update()
    {
        time += Time.deltaTime;
        if ( time > energyRechargeofRate && state.pCurrentEnergy < state.pMaxEnergy && !isRecharge)
        {
            StartCoroutine(Recharge());
        }
    }

    // FIXME : 해당 코루틴이 여러번 실행되는 버그가 있으나 현재는 중요하지 않으니 후에 재작업 필요
    IEnumerator Recharge()
    {
        isRecharge = true;
        Debug.Log("코루틴 실행됌");
        while (true)
        {
            state.pCurrentEnergy += 5;
            OnEnergyValueChanged?.Invoke(state.pCurrentEnergy / state.pMaxEnergy);
            if (state.pCurrentEnergy >= state.pMaxEnergy)
            {
                state.pCurrentEnergy = state.pMaxEnergy;
                time = 0;
                yield break;
            }
            yield return delay;
        }
        /*
         초당 10 회복인데
        frame drop 으로 frame이 박살 났을때 보정값
        프레임 간격 > 0.5 경우
        2회 마다 검사를 해서 1초 초과분 마다 보정값 추가인데 시간이 남을때 생각하기.
         */
    }

    public void Damaged(float dmg)
    {
        state.pCurrentHealth -= dmg;
        Debug.Log($"플레이어가 {dmg}만큼 피해 입음");
        if (state.pCurrentHealth <= 0)
        {
            state.pCurrentHealth = 0;
            OnPlayerDead?.Invoke();
            gameObject.SetActive(false);
            Debug.Log("플레이어 체력 0 이하됌\n사망");
        }
        // 게임 오버 출력

        // UI invoke
        OnHPValueChanged?.Invoke(state.pCurrentHealth / state.pMaxHealth);
    }

    public void UseEnergy(float useEnergy)
    {
        state.pCurrentEnergy -= useEnergy;
        isRecharge = false;
        time = 0;
        StopCoroutine(Recharge());
        OnEnergyValueChanged?.Invoke(state.pCurrentEnergy / state.pMaxEnergy);
    }

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        isRecharge = false;
    }

    public void InitPlayerCharacter(Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        transform.position = spawnPoint;
        state = new PlayerState(stateSO);
    }

    public void InitPlayerCharacterNonGenInstance(Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        transform.position = spawnPoint;
        state.SetData(stateSO);
        OnHPValueChanged?.Invoke(1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement.InitState(state.pMoveSpeed, state.pJumpPower);
        atk.SetData(state.pDamage,state.pUseEnergy);
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Move.performed += movement.Move;
        _inputActions.Player.Move.canceled += movement.Move;

        _inputActions.Player.Jump.performed += movement.Jump;

        _inputActions.Player.Move.performed += atk.PlayerDirection;

        _inputActions.Player.Attack.performed += atk.Shoot;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Move.performed -= movement.Move;
        _inputActions.Player.Move.canceled -= movement.Move;

        _inputActions.Player.Jump.performed -= movement.Jump;

        _inputActions.Player.Move.performed -= atk.PlayerDirection;

        _inputActions.Player.Attack.performed -= atk.Shoot;
    }
}