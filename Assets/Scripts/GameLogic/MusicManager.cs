using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Wallet wallet;

    public AudioSource cashAudio;

    private void OnEnable()
    {
        wallet.OnWalletChange += PlayMoneySound;
    }

    private void OnDisable()
    {
        wallet.OnWalletChange -= PlayMoneySound;
    }

    private void PlayMoneySound()
    {
        AudioClip cashClip = cashAudio.clip;
        cashAudio.PlayOneShot(cashClip);
    }
}
