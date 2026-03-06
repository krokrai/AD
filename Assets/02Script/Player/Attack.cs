using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] PlayerController pController;
    GameObject bullet;

    BulletState bulletState;

    private float _PlayerDir;
    float _useEnergy;

    private void Awake()
    {
        bulletState = Bullet.GetComponent<BulletState>();
    }

    public void SetData(float dmg, float useEnergy)
    {
        _useEnergy = useEnergy;
        if (bulletState == null)
        {
            Debug.LogWarning($"<color=red>초기화 전에 호출 되었습니다.\n호출 순서를 재정의가 필요합니다.</color>");
            return;
        }
        bulletState.dmg = dmg;
    }

    public void PlayerDirection(InputAction.CallbackContext ctx)
    {
        _PlayerDir = ctx.ReadValue<Vector2>().x;
        bulletState._dircetion = _PlayerDir;
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if ( ctx.performed && pController.state.pCurrentEnergy >= _useEnergy)
        {
            bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            pController.UseEnergy(_useEnergy);
        }
    }
}
