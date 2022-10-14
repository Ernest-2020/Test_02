using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppView : MonoBehaviour
{
    public event Action<string, string, string> OnStart;

    [SerializeField] private TMP_InputField _spawnTime;
    [SerializeField] private TMP_InputField _distance;
    [SerializeField] private TMP_InputField _speed;
    [SerializeField] private TextMeshProUGUI _exeptionText;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _showSettingButton;
    [SerializeField] private Button _hideSettingButton;
    [SerializeField] private GameObject _settigsPanel;

    private void Awake()
    {
        _startButton.onClick.AddListener(ClickStart);
        _showSettingButton.onClick.AddListener(ShowSettingsPanel);
        _hideSettingButton.onClick.AddListener(HideSettingsPanel);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(ClickStart);
        _showSettingButton.onClick.RemoveListener(ShowSettingsPanel);
        _hideSettingButton.onClick.RemoveListener(HideSettingsPanel);
        _exeptionText.text = "";
    }

    private void ClickStart()
    {
        try
        {
            OnStart?.Invoke(_spawnTime.text, _distance.text, _speed.text);
            HideSettingsPanel();
        }
        catch
        {
            _exeptionText.text = $"Incorrect data entered";
        }
    }

    private void ShowSettingsPanel()
    {
        _settigsPanel.SetActive(true);
    }
    private void HideSettingsPanel()
    {
        _settigsPanel.SetActive(false);
        _exeptionText.text = "";
    }
}

