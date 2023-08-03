using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class FirebaseManager : MonoBehaviour
{
    DatabaseReference databaseRef;

    public void Init()
    {
        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl("https://console.firebase.google.com/u/0/project/learning-vtiacademy/hosting/sites");
        //FirebaseApp.DefaultInstance.SetDatabaseUrl("https://console.firebase.google.com/u/0/project/learning-vtiacademy/hosting/sites");
        databaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SendPlayerProfile(PlayerProfile playerProfile)
    {
        string json = JsonUtility.ToJson(playerProfile);
        databaseRef.Child("playerProfiles").Push().SetRawJsonValueAsync(json);
    }
}
