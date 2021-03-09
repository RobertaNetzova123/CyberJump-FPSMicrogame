using UnityEngine;

public class InvinciblePickup : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of time to be invincible on pickup")]
    public float duration;

    private Health playerHealth;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, InvinciblePickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        playerHealth = player.GetComponent<Health>();
        if (playerHealth)
        {
            playerHealth.invincible = true;

            m_Pickup.PlayPickupFeedback();

            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }

            Invoke("RevertEffect", duration);
        }
    }

    void RevertEffect()
    {
        playerHealth.invincible = false;
        Destroy(gameObject);
    }
}