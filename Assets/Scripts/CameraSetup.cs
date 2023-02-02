using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    delegate void CameraActions();

    [SerializeField][Min(1f)] float followSpeed = 2f;

    CameraActions _cameraActions;

    // Start is called before the first frame update
    void Start()
    {
        _cameraActions = FollowPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        _cameraActions.Invoke();
    }

    void FollowPlayer()
    {
        Vector3 desiredPos = PlayerController.Instance.transform.position - Vector3.forward * 10f;
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);
    }
}
