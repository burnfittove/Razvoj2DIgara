using Enemies;
using UnityEngine;

public class Roamer : Enemy
{
    protected override void OnDeath()
    {
        sr.color = new Color(sr.color.r / 3, sr.color.g / 3, sr.color.b / 3);
        cc.enabled = false;
        enabled = false;
    }
}
