using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] Wallet wallet;
    [SerializeField] TextMeshProUGUI goldText;


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
