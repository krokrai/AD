using UnityEngine;

public class BeamObject : MonoBehaviour
{
    LayerMask layerMaskTarget;

    public bool canDamage;

    public void InitState(LayerMask layer)
    {
        layerMaskTarget = layer;
        canDamage = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canDamage && layerMaskTarget == (1 << collision.gameObject.layer))
        {
            collision.GetComponent<PlayerController>().Damaged(80);
        }
    }
}
