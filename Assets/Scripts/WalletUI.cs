using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        goldText.text = wallet.Gold.ToString();
    }

    private void OnEnable()
    {
        wallet.OnWalletChange += UpdateUI;
    }

    private void OnDisable()
    {
        wallet.OnWalletChange -= UpdateUI;
    }

    private void UpdateUI()
    {
        goldText.text = wallet.Gold.ToString();
    }
}
