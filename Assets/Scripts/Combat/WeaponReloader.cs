using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;

    int ammo;
    public int shotsFiredInClip;
    bool isReloading;

    public int RoundsRemaningInCLip {
        get { return clipSize - shotsFiredInClip; }
    }

    public bool IsReloading { 
    
        get { return isReloading; }
    }

    public void Reload() 
    {
        if (isReloading) { 
            return;
        }
        print("Reload Executed");
        isReloading = true;
        GameManager.Instance.Timer.Add(ExecuteReload, reloadTime);
    }

    private void ExecuteReload() {
        print("Reload Complete");
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        if (ammo < 0 ) {
            ammo = 0;
            shotsFiredInClip += 0;
        }
    }

    public void TakeFromClip(int clip) {
        shotsFiredInClip += clip;
    }

}
