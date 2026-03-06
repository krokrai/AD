using System.Data.Common;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] LayerMask target;
    [SerializeField] private EnemyController body;

    public bool canAttack;

    private float dmg;

    private void Start()
    {
        dmg = body.state.damage;
        canAttack = false;
    }

    // FIXME : 움직여서 Trigger 여러번 건드리면 대미지가 건드리는 만큼 들어가는 버그 있음. 애니메이션으로 고칠 수 있으나 후순위로 작업 예정.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( target ==  (1<<collision.gameObject.layer)) // && canAttack)
        {
            AttackToTarget(collision.gameObject);
        }
    }


    void AttackToTarget(GameObject target)
    {
        target.GetComponent<PlayerController>()?.Damaged(dmg);
    }
}
