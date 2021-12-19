using UnityEngine;

public class Shooter : MonoBehaviour
{
    // 1 is in seconds
    [SerializeField] float rateOffFire;

    [SerializeField] Projectile projectile;


    private float nextFireAllowed;

    [HideInInspector]
    public Transform muzzle;

    public bool canFire;

    void Awake() {
        muzzle = transform.Find("Muzzle");
    }

    public virtual void Fire() {

        canFire = false;

        if (Time.time < nextFireAllowed) 
            return;

        nextFireAllowed = Time.time + rateOffFire;

        print("Firing : "+ Time.time);
        //instanciate the projectile

        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canFire = true;
    }


   
}
