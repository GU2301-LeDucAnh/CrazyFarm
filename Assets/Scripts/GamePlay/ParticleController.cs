using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject lvUpParticle;

    public void LevelUp()
    {
        var lvUp = Instantiate(lvUpParticle, GamePlayController.Instance.playerController.transform);
        lvUp.transform.position = GamePlayController.Instance.playerController.transform.position;
        Destroy(lvUp, 2f);
    }
}
