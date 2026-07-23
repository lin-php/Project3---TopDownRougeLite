using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private WeaponData equippedWeapon;
    private float nextAttackTime;
   

    public void TryAttack()
    {
        
        if (Time.time < nextAttackTime) 
        {
            return;
        }

        nextAttackTime = Time.time + equippedWeapon.attackCooldown;

        PerformAttack();
    }

    public void PerformAttack()
    {
        Debug.Log("Angriff ausgeführt!");
    }



}
