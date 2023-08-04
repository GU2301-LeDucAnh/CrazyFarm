using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile : MonoBehaviour
{
    public static string PlayerName
    {
        get
        {
            if (!PlayerPrefs.HasKey(StringHelper.PLAYER_NAME))
            {
                var deviceName = SystemInfo.deviceUniqueIdentifier;
                var lastFiveName = SystemInfo.deviceUniqueIdentifier.Length - 4;
                for (int i = 0; i < SystemInfo.deviceUniqueIdentifier.Length; i++)
                {
                    if (i == lastFiveName - 1)
                    {
                        deviceName = SystemInfo.deviceUniqueIdentifier[i].ToString();
                    }
                    else if (i > lastFiveName - 1)
                    {
                        deviceName += SystemInfo.deviceUniqueIdentifier[i].ToString();
                    }
                }
                PlayerPrefs.SetString(StringHelper.PLAYER_NAME, "User#" + deviceName);
            }
            return PlayerPrefs.GetString(StringHelper.PLAYER_NAME);
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.PLAYER_NAME, value);
            PlayerPrefs.Save();
        }
    }

    public static int CurrentLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey(StringHelper.CURRENT_LEVEL))
                PlayerPrefs.SetInt(StringHelper.CURRENT_LEVEL, 1);
            return PlayerPrefs.GetInt(StringHelper.CURRENT_LEVEL);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_LEVEL, value);
            PlayerPrefs.Save();
        }
    }

    public static int CurrentCoin
    {
        get
        {
            if (!PlayerPrefs.HasKey(StringHelper.CURRENT_COIN))
                PlayerPrefs.SetInt(StringHelper.CURRENT_COIN, 100);
            return PlayerPrefs.GetInt(StringHelper.CURRENT_COIN);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_COIN, value);
            PlayerPrefs.Save();
        }
    }

    public static int CurrentExp
    {
        get
        {
            if (!PlayerPrefs.HasKey(StringHelper.CURRENT_EXP))
                PlayerPrefs.SetInt(StringHelper.CURRENT_EXP, 0);
            return PlayerPrefs.GetInt(StringHelper.CURRENT_EXP);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_EXP, value);
            PlayerPrefs.Save();
        }
    }

    public int CurrentSkin
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.CURRENT_SKIN);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_SKIN, value);
            PlayerPrefs.Save();
        }
    }

    public static int CurrentPlantCollection
    {
        get
        {
            if (!PlayerPrefs.HasKey(StringHelper.CURRENT_PLANT_COLLECTION))
                PlayerPrefs.SetInt(StringHelper.CURRENT_PLANT_COLLECTION, 0);
            return PlayerPrefs.GetInt(StringHelper.CURRENT_PLANT_COLLECTION);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_PLANT_COLLECTION, value);
            PlayerPrefs.Save();
        }
    }


    public static int CurrentTreeCollection
    {
        get
        {
            if (!PlayerPrefs.HasKey(StringHelper.CURRENT_TREE_COLLECTION))
                PlayerPrefs.SetInt(StringHelper.CURRENT_TREE_COLLECTION, 0);
            return PlayerPrefs.GetInt(StringHelper.CURRENT_TREE_COLLECTION);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.CURRENT_TREE_COLLECTION, value);
            PlayerPrefs.Save();
        }
    }

    public bool OnVibration
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.ONOFF_VIBRATION) == 1 ? true : false;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.ONOFF_VIBRATION, value ? 1 : 0);
        }
    }

    public float SoundVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(StringHelper.SOUND_VOLUME);
        }
        set
        {
            PlayerPrefs.SetFloat(StringHelper.SOUND_VOLUME, value);
        }
    }

    public float MusicVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(StringHelper.MUSIC_VOLUME);
        }
        set
        {
            PlayerPrefs.SetFloat(StringHelper.MUSIC_VOLUME, value);
        }
    }
}
