using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider myCollider;

    [SerializeField]
    private GameObject stickingArrow;

    private bool isThrown = false;

    private void OnCollisionEnter(Collision collision)
    {
        ArcheryGameController.Instance.playerArrowCount++;
        if (isThrown == true
            || collision.collider.CompareTag("Arrow") || (collision.collider.CompareTag("Floor"))) // Must be changed to "Floor" tag: Terrain, too
        {
            return;
        }

        // game score check
        if (isThrown == false && collision.gameObject.tag == "CloseTarget")
        {
            ArcheryGameController.Instance.playerScore += ArcheryGameController.Instance.closePoint;
        }
        else if (isThrown == false && collision.gameObject.tag == "MidTarget")
        {
            ArcheryGameController.Instance.playerScore += ArcheryGameController.Instance.midPoint;
        }
        else if (isThrown == false && collision.gameObject.tag == "LongTarget")
        {
            ArcheryGameController.Instance.playerScore += ArcheryGameController.Instance.farPoint;
        }

        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.rotation = transform.rotation;
        arrow.transform.forward = -transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        collision.collider.GetComponent<IHittable>()?.GetHit();

        Destroy(gameObject);

        isThrown = true;
    }
}