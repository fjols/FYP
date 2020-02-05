using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Powerup", menuName = "Powerup")]
public class Powerup : ScriptableObject
{
    public string _name;

    public Sprite m_sprite;
    public float speedIncrease;
    public int healthIncrease;
    public float duration;
    public int damageIncrease;
}
