using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [HideInInspector] public string playerName;
    [HideInInspector] public int levelPlayer;

    public void Init(FirebaseManager firebaseManager)
    {
        PlayerProfile playerProfile = new PlayerProfile();
        playerName = UserProfile.PlayerName;
        levelPlayer = UserProfile.CurrentLevel;
        //firebaseManager.SendPlayerProfile(playerProfile);
    }
}
