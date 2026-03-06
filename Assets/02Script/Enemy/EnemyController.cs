using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyStateSO stateSO;
    [SerializeField] float tempMovementSpeed;
    [SerializeField] LayerMask RayTarget;
    [SerializeField] LayerMask Target;
    [SerializeField] StagOneController stage;

    Rigidbody2D _rb;
    Animator _ani;

    public EnemyState state;

    public bool inRanged;

    private float RayMaxDistance = 1.2f;
    private bool canMove;

    float time;

    private void Awake()
    {
        state = new EnemyState(stateSO);
        _rb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
    }

    private void Start()
    {
        inRanged = false;
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (!inRanged && canMove)
            _rb.linearVelocityX = Vector2.left.x * tempMovementSpeed;
        else
            _rb.linearVelocityX = 0;
    }

    public void Attacking()
    {
        canMove = false;
    }

    public void Walking() => canMove = true;

    public void TriggedAttack()
    {
        _ani.SetTrigger("Attack");
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (Physics2D.Raycast(transform.position, Vector2.down,RayMaxDistance, RayTarget) || time < 0.3f)
        {
            return;
        }
        else
        {
            time = 0f;
            
            tempMovementSpeed *= -1;
            transform.Rotate(new Vector3(0,0,180));
        }
    }

    public void TakeDamage(float dmg)
    {
        state.health -= dmg;
        Debug.Log($"{dmg} Damaged");
        if ( state.health <= 0 )
        {
            stage.unitCounter--;
            gameObject.SetActive(false);
        }
    }
}
