using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public List<EmptyDirt> emptyDirts;

    public void Init()
    {
        for (int i = 0; i < emptyDirts.Count; i++)
        {
            emptyDirts[i].id = i;
            emptyDirts[i].Init();
        }
    }
}
