using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullet;
    public int MaxNumberOfBullet;
    public Text AmmoText;
    public PlayerArmory PlayerArmory;

    public override void PistolFire1()
    {
        base.PistolFire1();
        NumberOfBullet -= 1;
        AmmoTextUpdate();
        if (NumberOfBullet <= 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }

    }

    private void AmmoTextUpdate()
    {
        AmmoText.text = ("Bullets: ") + NumberOfBullet.ToString();
    }

    public override void Activate()
    {
        base.Activate();
        AmmoText.enabled = true;
        AmmoTextUpdate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        AmmoText.enabled = false;
    }

    public override void AddNewGunOrAmmo(int numberOfAmmo)
    {
        base.AddNewGunOrAmmo(numberOfAmmo);
        NumberOfBullet += numberOfAmmo;
        PlayerArmory.TakeGunByIndex(1);
        AmmoTextUpdate();
    }

   
}
