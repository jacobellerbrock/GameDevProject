using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    [SerializeField] private MCHandler mc;
    [SerializeField] private AnimationStateChanger changer;

    public void EnableInvincible()
    {
        mc.invulnerable = true;
    }

    public void DisableInvincible()
    {
        mc.invulnerable = false;
    }

    public void ChangeAnimationStateString(string s)
    {
        changer.currentState = s;
    }
}
