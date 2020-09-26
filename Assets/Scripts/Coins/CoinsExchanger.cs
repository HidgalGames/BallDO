using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsExchanger : MonoBehaviour
{
    private enum ValueType
    {
        Coins,
        UC
    }

    [Header("Data objects")]
    public Coins playerCoins;
    public DonateCoins donateCoins;
    public UpgradePointsObject upgradeCoins;

    [Header("Coins UI")]
    public Slider coinsSlider;
    public TextMeshProUGUI coinsCostText;
    public TextMeshProUGUI coinsCountText;
    public Button coinsAcceptButton;
    private int coinsToPurchase = 0;
    private int coinsCost = 0;

    [Header("UC UI")]
    public Slider UCSlider;
    public TextMeshProUGUI UCCostText;
    public TextMeshProUGUI UCCountText;
    public Button UCAcceptButton;
    private int UCToPurchase = 0;
    private int UCCost = 0;

    [Header("Coins Exchange Rates")]
    [Tooltip("Количество coins за 1 donate coin")] [Min(0)] public float coinsRate = 100;
    [Tooltip("Количество upgrade coins за 1 donate coin")] [Min(0)] public float UCRate = 0.1f;

    [Header("Coins ToolTips")]
    public TextMeshProUGUI CDTooltipText;
    public TextMeshProUGUI CTooltipText;

    [Header("UCoins ToolTips")]
    public TextMeshProUGUI UCDTooltipText;
    public TextMeshProUGUI UCTooltipText;

    private void Start()
    {
        CDTooltipText.text = "1";
        CTooltipText.text = coinsRate.ToString();

        UCDTooltipText.text = "10";
        UCTooltipText.text = (10 * UCRate).ToString();
    }

    public void CalculateCoinsSliderValues()
    {
        CalculateSliderValues(coinsSlider, ValueType.Coins);
    }

    public void AcceptCoinsPurchase()
    {
        AcceptPurchase(ValueType.Coins);
    }

    public void CalculateCoinsCosts()
    {
        CalculateCosts(coinsSlider, ValueType.Coins);
    }

    public void ResetCoinsSlider()
    {
        ResetSlider(coinsSlider, ValueType.Coins);
    }



    public void CalculateUCSliderValues()
    {
        CalculateSliderValues(UCSlider, ValueType.UC);
    }

    public void AcceptUCPurchase()
    {
        AcceptPurchase(ValueType.UC);
    }

    public void CalculateUCCosts()
    {
        CalculateCosts(UCSlider, ValueType.UC);
    }

    public void ResetUCSlider()
    {
        ResetSlider(UCSlider, ValueType.UC);
    }



    private void CalculateSliderValues(Slider slider, ValueType type)
    {
        switch (type)
        {
            case ValueType.Coins:
                coinsAcceptButton.interactable = donateCoins.TotalCoins > 0;
                slider.maxValue = donateCoins.TotalCoins;
                SetSliderActive(slider, donateCoins.TotalCoins > 0);
                break;

            case ValueType.UC:
                UCAcceptButton.interactable = donateCoins.TotalCoins >= 1 / UCRate;
                slider.maxValue = Mathf.FloorToInt(donateCoins.TotalCoins * UCRate);
                SetSliderActive(slider, donateCoins.TotalCoins >= 1 / UCRate);
                break;
        }       
    }

    private void CalculateCosts(Slider slider, ValueType type)
    {
        switch (type)
        {
            case ValueType.Coins:
                coinsCost = Mathf.CeilToInt(coinsSlider.value);
                coinsToPurchase = Mathf.CeilToInt(coinsSlider.value * coinsRate);

                coinsCostText.text = coinsCost.ToString();
                coinsCountText.text = coinsToPurchase.ToString();
                break;

            case ValueType.UC:
                UCCost = Mathf.CeilToInt(UCSlider.value / UCRate);
                UCToPurchase = Mathf.CeilToInt(UCSlider.value);

                if(UCCost > 0)
                {
                    UCCostText.text = UCCost.ToString();
                }
                else
                {
                    UCCostText.text = donateCoins.TotalCoins.ToString();
                }

                UCCountText.text = UCToPurchase.ToString();
                break;
        }
    }

    private void ResetSlider(Slider slider, ValueType type)
    {
        switch (type)
        {
            case ValueType.Coins:
                CalculateCoinsSliderValues();
                coinsSlider.value = coinsSlider.minValue;
                CalculateCoinsCosts();
                break;

            case ValueType.UC:
                CalculateUCSliderValues();
                UCSlider.value = UCSlider.minValue;
                CalculateUCCosts();
                break;
        }
    }

    private void AcceptPurchase(ValueType type)
    {
        switch (type)
        {
            case ValueType.Coins:
                if (donateCoins.TakeCoins(coinsCost))
                {
                    playerCoins.AddCoins(coinsToPurchase);
                }
                break;

            case ValueType.UC:
                if (donateCoins.TakeCoins(UCCost))
                {
                    upgradeCoins.Add(UCToPurchase);
                }
                break;
        }
    }

    private void SetSliderActive(Slider slider, bool isActive)
    {
        slider.interactable = isActive;

        if (isActive)
        {            
            slider.minValue = 1;
        }
        else
        {
            slider.minValue = 0;
        }
    }
}
