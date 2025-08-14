using UnityAtoms.BaseAtoms;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private IntVariable vida; // Current health of the entity
    [SerializeField] private IntConstant vidaMax; // Maximum health of the entity
    [SerializeField] private VoidEvent OnDamage; // Event triggered when the entity takes damage
    [SerializeField] private VoidEvent OnDeath; // Event triggered when the entity dies

    private void Awake()
    {
        // Initialize health to maximum health at the start
        vida.Value = vidaMax.Value;
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce health by the damage amount
        vida.Value -= damageAmount;
        // Check if health is less than or equal to zero
        if (vida.Value <= 0)
        {
            // Trigger the OnDeath event
            OnDeath.Raise();

            vida.Value = 0; // volver a poner la vida a 0 si es que se pasa de 0

            // Optionally, destroy the game object or handle death logic here
            //Destroy(gameObject);
        }
        else
        {
            OnDamage.Raise(); // Trigger the OnDamage event
        }
    }
}
