using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Effect {
    None,
    Stun,
    Reset,
}

public class Enemy : MonoBehaviour
{
    public Effect effect;
}
