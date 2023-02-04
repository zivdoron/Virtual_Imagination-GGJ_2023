using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] CanvasGroup _secondPanel;
    Image _secondPanelImage;

    private void Start()
    {
        _secondPanelImage = _secondPanel.GetComponent<Image>();
    }

    public void SetSecondPanelOpen(bool _isOpen)
    {
        StartCoroutine(FadeSecondPanel(_isOpen));
    }

    IEnumerator FadeSecondPanel(bool _isOpen)
    {
        _secondPanelImage.raycastTarget = true;
        _secondPanel.blocksRaycasts = true;
        _secondPanel.alpha = _isOpen ? 0 : 1;
        float _targetAlpha = _isOpen ? 1 : 0;
        int _direction = Mathf.RoundToInt(_targetAlpha - _secondPanel.alpha);

        while (Mathf.Abs(_targetAlpha - _secondPanel.alpha) > Mathf.Epsilon)
        {
            _secondPanel.alpha += _direction * Time.unscaledDeltaTime;
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
        if (!_isOpen)
        {
            _secondPanelImage.raycastTarget = false;
            _secondPanel.blocksRaycasts = false;
        }
    }
}
