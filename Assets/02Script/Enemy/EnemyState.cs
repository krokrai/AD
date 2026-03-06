using UnityEngine;

public class EnemyState
{
    public float health;
    public float moveSpeed;
    public bool canFly;
    public float damage;
    public int maxAttackCount;

    public EnemyState( EnemyStateSO so)
    {
        health = so.commonEnemyHealth;
        moveSpeed = so.commonEnemyMoveSpeed;
        canFly = so.commonEnemyCanFly;
        damage = so.commonEnemyDamage;
        maxAttackCount = so.commonEnemyMaxAttackCounte;
    }
}
