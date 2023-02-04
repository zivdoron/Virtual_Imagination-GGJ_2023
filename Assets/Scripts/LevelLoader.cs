using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level Loader", menuName = "Managers/Level Loader")]
public class LevelLoader : ScriptableObject
{
    [SerializeField] EventManager _eventManager;
    int _targetLevel;

    public void SetTargetLevel(int _target)
    {
        if (_eventManager.OnReadyToSceneTransition == null)
        {
            _eventManager.OnReadyToSceneTransition += LoadTargetLevel;
        }
        _targetLevel = _target;
    }

    void LoadTargetLevel()
    {
        Debug.Log("Loading target level!");
        SceneManager.LoadScene(_targetLevel);
    }
}
