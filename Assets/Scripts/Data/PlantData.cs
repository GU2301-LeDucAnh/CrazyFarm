using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Data/PlantData", order = 2), Serializable]
public class PlantData : ScriptableObject
{
    public List<PlantInfo> lstPlant;

    public PlantInfo CurrentPlant(int idPlant)
    {
        PlantInfo curPlant = lstPlant.Find(x => x.idPlant == idPlant);
        return curPlant;
    }
}

[Serializable]
public class PlantInfo
{
    public int idPlant;
    public int coinSpent;
    public int playerLvCanUlock;
    public Sprite iconPlant;

    public GameObject smallPlant;
    public GameObject mediumPlant;
    public GameObject bigPlant;

    public float timeToHarvest;
    public PlantRewards rewards;
}

[Serializable]
public class PlantRewards
{
    public int coinCollect;
    public int expCollect;

    public int plantCollect;
}
