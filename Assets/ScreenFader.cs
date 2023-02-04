using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] Image _faderImage;
    [SerializeField] Material _screenFader;
    [SerializeField] EventManager _eventManager;
    [SerializeField][Min(1f)] float _sequenceLength = 1.5f;

    private void Start()
    {
        _eventManager.OnScreenTransitionCalled += () => Fade(true);
        Fade(false);
    }

    void Fade(bool _isFadingIn)
    {
        StartCoroutine(FadeScreen(_isFadingIn));
    }

    IEnumerator FadeScreen(bool _isFadingIn)
    {
        _faderImage.raycastTarget = true;
        _screenFader.SetFloat("_DissolveAmount", _isFadingIn ? 0.9f : -0.1f);
        float _currentAlpha = _screenFader.GetFloat("_DissolveAmount"), _startAlpha = _currentAlpha;
        int direction = _isFadingIn ? -1 : 1;

        while (Mathf.Abs(_startAlpha - _currentAlpha) < 1)
        {
            _currentAlpha += Time.deltaTime * direction / _sequenceLength;
            _screenFader.SetFloat("_DissolveAmount", _currentAlpha);
            yield return new WaitForEndOfFrame();
        }
        if (_isFadingIn)
        {
            //fade in finished, time to call scene transition
            Debug.Log("Ready to change scenes!");
            _eventManager.OnReadyToSceneTransition?.Invoke();
        }
        else
        {
            _faderImage.raycastTarget = false;
        }
    }
}
