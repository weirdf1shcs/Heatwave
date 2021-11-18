using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AmmoHandler : MonoBehaviour
{
    //This script handles the ammo of the gun
    public int maxInGunAmmo = 20;
    public int currentInGunAmmo;
    public int maxCarryAmmo = 100;
    public int currentCarryAmmo;
    public int startingInGunAmmo;
    public int startingCarryAmmo;
    [SerializeField] UIManager uIManager;
    public bool CheckAmmo()
    {
        if (currentInGunAmmo > 0)
        {
            return true;
        }
        return false;
    }
    public void DecrementGunAmmo()
    {
        currentInGunAmmo -= 1;
        uIManager.UpdateInGunAmmoText(currentInGunAmmo);
    }
    public void Reload()
    {
        if (currentCarryAmmo >= maxInGunAmmo)
        {
            StartCoroutine(WaitToReloadOne());
        }
        else if (currentCarryAmmo < maxInGunAmmo && currentCarryAmmo > 0)
        {
            int ammoToLoad = currentCarryAmmo;
            currentCarryAmmo = 0;
            StartCoroutine(WaitToReloadTwo(ammoToLoad));
        }
        else if (currentCarryAmmo == 0)
        {
            currentCarryAmmo = 0;
        }
    }
    IEnumerator WaitToReloadOne()
    {
        yield return new WaitForSeconds(1.5f);
        currentCarryAmmo -= maxInGunAmmo;
        currentInGunAmmo += maxInGunAmmo;
        print("Reloaded");
        print(currentCarryAmmo);
        uIManager.UpdateCarryAmmoText(currentCarryAmmo);
        uIManager.UpdateInGunAmmoText(currentInGunAmmo);
    }
    IEnumerator WaitToReloadTwo(int ammoToReload)
    {
        yield return new WaitForSeconds(1.5f);
        currentInGunAmmo += ammoToReload;
        print("Reloaded");
        print(currentCarryAmmo);
        uIManager.UpdateCarryAmmoText(currentCarryAmmo);
        uIManager.UpdateInGunAmmoText(currentInGunAmmo);
    }
}
