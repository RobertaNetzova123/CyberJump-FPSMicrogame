using UnityEngine;
using UnityEngine.Serialization;

public class SpeedPickup : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of time to be invincible on pickup")]
    public float duration;

    public float speedBuff;
    private float originalSpeedGround;
    private float originalSpeedAir;
    private float originalSpeedCrouch;

    private PlayerCharacterController player;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, SpeedPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
        Debug.Log("fuckk off");
    }

    void OnPicked(PlayerCharacterController player)
    {
        this.player = player;

        originalSpeedGround = this.player.maxSpeedOnGround;
        originalSpeedAir = this.player.maxSpeedInAir;
        originalSpeedCrouch = this.player.maxSpeedCrouchedRatio;
        
        this.player.speedActive = true;
        this.player.maxSpeedOnGround += speedBuff;
        this.player.maxSpeedInAir += speedBuff;
        this.player.maxSpeedCrouchedRatio += speedBuff;

        m_Pickup.PlayPickupFeedback();

        foreach (Renderer r in GetComponentsInChildren<Renderer>()) 
        { 
            r.enabled = false;
        }
        
        Invoke("RevertEffect", duration);
    }

    void RevertEffect()
    {
        
        player.maxSpeedOnGround = originalSpeedGround;
        player.maxSpeedInAir = originalSpeedAir;
        player.maxSpeedCrouchedRatio = originalSpeedCrouch;
        player.speedActive = false;
        Destroy(gameObject);
    }
}