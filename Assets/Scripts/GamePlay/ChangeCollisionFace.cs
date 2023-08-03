using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollisionFace : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var getComponentDirt = other.GetComponent<EmptyDirt>();
        if (other.CompareTag(NameTag.GROUND_ATTACH) && getComponentDirt != null)
        {
            GamePlayController.Instance.GroundAttach(getComponentDirt);
        }
        var getComponentTree = other.GetComponent<TreeElement>();
        if (other.CompareTag(NameTag.TREE) && getComponentTree != null)
        {
            GamePlayController.Instance.TreeAttach(getComponentTree);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(NameTag.GROUND_ATTACH))
        {
            GamePlayController.Instance.ActionExit();
        }
        if (other.CompareTag(NameTag.TREE))
        {
            GamePlayController.Instance.ActionExit();
        }
    }
}
