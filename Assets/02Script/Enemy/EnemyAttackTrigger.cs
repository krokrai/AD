using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] EnemyController body;
    [SerializeField] LayerMask Target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Target == (1 << collision.gameObject.layer))
        {
            body.inRanged = true;
            body.Attacking();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Target == (1 << collision.gameObject.layer))
        {
            body.inRanged = false;
        }
    }
}
