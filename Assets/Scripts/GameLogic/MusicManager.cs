using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Wallet wallet;

    public AudioSource cashAudio;
    public AudioSource hurtAudio;

    private void OnEnable()
    {
        wallet.OnWalletChange += PlayMoneySound;
        LifeEventEmitter.OnTakeDamage += PlayHurtSound;
    }

    private void OnDisable()
    {
        wallet.OnWalletChange -= PlayMoneySound;
        LifeEventEmitter.OnTakeDamage -= PlayHurtSound;
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
}
