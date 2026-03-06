using System.Data.Common;
using TMPro;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    public float dmg;

    public float _dircetion = 1;

    [SerializeField] private LayerMask target;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.Translate((Vector3.right * _dircetion) * (9 * Time.deltaTime) );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == (1 << collision.gameObject.layer))
        {
            collision.gameObject.GetComponent<EnemyController>()?.TakeDamage(dmg);
            collision.gameObject.GetComponent<BossController>()?.TakeDamage(dmg);
        }
    }
}
