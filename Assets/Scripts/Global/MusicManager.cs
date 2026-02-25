using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Wallet wallet;

    public AudioSource CashAudio;
    public AudioSource HurtAudio;
    public AudioSource RestoreAudio;

    private void OnEnable()
    {
        wallet.OnWalletChange += PlayMoneySound;

        LifeEventEmitter.OnTakeDamage += PlayHurtSound;
        InventoryUI.OnConsumedItem += PlayRestoreSound;
    }

    private void OnDisable()
    {
        wallet.OnWalletChange -= PlayMoneySound;

        LifeEventEmitter.OnTakeDamage -= PlayHurtSound;
        InventoryUI.OnConsumedItem -= PlayRestoreSound;
    }

    private void PlayMoneySound()
    {
        AudioClip cashClip = CashAudio.clip;
        CashAudio.PlayOneShot(cashClip);
    }

    private void PlayHurtSound()
    {
        AudioClip hurtClip = HurtAudio.clip;
        HurtAudio.PlayOneShot(hurtClip);
    }

    private void PlayRestoreSound()
    {
        AudioClip restoreClip = RestoreAudio.clip;
        RestoreAudio.PlayOneShot(restoreClip);
    }
}
