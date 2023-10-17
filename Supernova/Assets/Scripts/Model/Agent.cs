using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : Deployable
{
    public int health;
    public int attack;
    public int speed;

    public Agent(Card card, int health, int attack, int speed)
    {
        this.card = card;
        this.health = health;
        this.attack = attack;
        this.speed = speed;
    }
}
