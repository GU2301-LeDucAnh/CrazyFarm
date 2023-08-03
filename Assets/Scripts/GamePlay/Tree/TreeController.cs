using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public List<TreeElement> treeElements;

    public void Init()
    {
        foreach (TreeElement treeElement in treeElements)
        {
            treeElement.InitState();
        }
    }
}
