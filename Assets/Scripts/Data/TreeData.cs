using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeData", menuName = "Data/TreeData", order = 3), Serializable]
public class TreeData : ScriptableObject
{
    public List<TreeInfo> lstTree;
}

[Serializable]
public class TreeInfo
{
    public int idTree;
    public int coinSpent;
    public int playerLvCanUlock;
    public Sprite iconTree;
    public Mesh nonClaimMesh;
    public Mesh canClaimMesh;

    public float timeToHarvest;
    public TreeRewards rewards;
}

[Serializable]
public class TreeRewards
{
    public int coinCollect;
    public int expCollect;

    public int treeCollect;
}
