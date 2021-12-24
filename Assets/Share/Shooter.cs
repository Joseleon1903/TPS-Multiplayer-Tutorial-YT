using UnityEngine;

public class Shooter : MonoBehaviour
{
    void Awake()
    {
        muzzle = transform.Find("Muzzle");
        _reloader = GetComponent<WeaponReloader>();
    }


    // 1 is in seconds
    [SerializeField] float rateOffFire;

    [SerializeField] Projectile projectile;

    [HideInInspector]
    public Transform muzzle;

    private WeaponReloader _reloader;

    public void Reload(){

        if (_reloader == null) {
            return;
        }
        _reloader.Reload();
    
    }

    private float nextFireAllowed;
    public bool canFire;


    public virtual void Fire() {

        canFire = false;

        if (Time.time < nextFireAllowed) 
            return;

        if (_reloader != null) {

            // cant fire while reloading
            if (_reloader.IsReloading)
                return;

            // cant fire while no clip remasins
            if (_reloader.RoundsRemaningInCLip == 0)
                return;

            _reloader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOffFire;

        print("Firing : "+ Time.time);
        //instanciate the projectile

        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canFire = true;
    }


   
}
