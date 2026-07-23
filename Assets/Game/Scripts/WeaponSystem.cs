using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // [SerializeField] private WeaponData equippedWeapon;
    private float nextAttackTime;
    [SerializeField] private float attackCooldown = 2f;

    public void TryAttack()
    {
        
        if (Time.time < nextAttackTime) 
        {
            return;
        }

        nextAttackTime = Time.time + attackCooldown;

        PerformAttack();
    }

    public void PerformAttack()
    {
        Debug.Log("Angriff ausgeführt!");
    }



}
