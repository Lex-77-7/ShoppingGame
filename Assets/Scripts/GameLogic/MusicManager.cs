using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Wallet wallet;

    public AudioSource cashAudio;
    public AudioSource hurtAudio;
    public AudioSource restoreAudio;

    private void OnEnable()
    {
        wallet.OnWalletChange += PlayMoneySound;

        LifeEventEmitter.OnTakeDamage += PlayHurtSound;
        LifeEventEmitter.OnHeal += PlayRestoreSound;
    }

    private void OnDisable()
    {
        wallet.OnWalletChange -= PlayMoneySound;

        LifeEventEmitter.OnTakeDamage -= PlayHurtSound;
        LifeEventEmitter.OnHeal -= PlayRestoreSound;
    }

    private void PlayMoneySound()
    {
        AudioClip cashClip = cashAudio.clip;
        cashAudio.PlayOneShot(cashClip);
    }

    private void PlayHurtSound()
    {
        AudioClip hurtClip = hurtAudio.clip;
        hurtAudio.PlayOneShot(hurtClip);
    }

    private void PlayRestoreSound()
    {
        AudioClip restoreClip = restoreAudio.clip;
        restoreAudio.PlayOneShot(restoreClip);
    }
}
