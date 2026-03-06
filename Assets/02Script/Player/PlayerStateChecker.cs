using UnityEngine;
using UnityEngine.Playables;

public class PlayerStateChecker : MonoBehaviour
{
    PlayerMovement pMovement;
    PlayerStateMachin stateMachin;

    private void Start()
    {
        pMovement = GetComponent<PlayerMovement>();
        stateMachin = new PlayerStateMachin();
    }

    void Update()
    {
        if (pMovement.movement <= 0)
        {
            stateMachin.ChangeState(States.Idle);
        }
        /*
        else if( 체력이 0 보다 낮은 경우)
        {
            if ( 목숨이 0 인경우)
                stateMachin.ChangeState(States.Dead);
            stateMachin.ChangeState(States.Revive);
        }

        else if ( pMovement.movement > 0)
        
        else if ( 대쉬를 사용한 경우 )

        else if ( 공격을 한 경우 )

        if ( 만약 게임에서 승리한 경우. ) // 이건 후순위
        */
    }
}
