using Enemies;
using UnityEngine;

public class Roamer : Enemy
{
    protected override void OnDeath()
    {
        sr.color = new Color(sr.color.r - .1f, sr.color.g - .1f, sr.color.b - .1f);
        cc.enabled = false;
    }
}
