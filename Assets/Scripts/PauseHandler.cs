using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;
    MenuManager _menu;
    bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        _menu = GetComponent<MenuManager>();
        Time.timeScale = 1f;
        _eventManager.OnPausePressed += TogglePause;
        _eventManager.OnScreenTransitionCalled += () => Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        _menu.SetSecondPanelOpen(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
    }
}
