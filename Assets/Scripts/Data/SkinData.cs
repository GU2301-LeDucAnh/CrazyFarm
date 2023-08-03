using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinData", menuName = "Data/SkinData", order = 1), Serializable]
public class SkinData : ScriptableObject
{
    public List<SkinInfo> skins;
}

[Serializable]
public class SkinInfo
{
    public int id;
    public Material skinMaterial;
    public bool isUnlock;
    public GameObject iconSkin;
}
