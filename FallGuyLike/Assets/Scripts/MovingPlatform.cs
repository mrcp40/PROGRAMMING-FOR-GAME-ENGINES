using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _movingPlatform = null;
    [SerializeField]
    private Transform _targetTransform = null;
    [SerializeField]
    private float _moveSpeed = 2.0f;
    [SerializeField]
    private float _waitDuration = 2.0f;

    private Coroutine _movingCoroutine = null;
    private bool _moveToTarget = true;


    private void OnEnable()
    {
        ClearCoroutine();
        if (_moveToTarget)
        {
            MoveToTarget();
        }
        else
        {
            MoveToStart();
        }

    }

    private void OnDisable()
    {
        if (_movingCoroutine != null)
        {
            StopCoroutine(_movingCoroutine);
        }
        _movingCoroutine = null;
    }


    private void ClearCoroutine()
    {
        if (_movingCoroutine != null)
        {
            StopCoroutine(_movingCoroutine);
        }
        _movingCoroutine = null;
    }


    private void MoveToTarget()
    {
        _moveToTarget = true;
        ClearCoroutine();
        _movingCoroutine = StartCoroutine(MovePlatfotm());
    }

    private void MoveToStart()
    {
        _moveToTarget = false;
        ClearCoroutine();
        _movingCoroutine = StartCoroutine(MovePlatfotm());
    }

    IEnumerator MovePlatfotm()
    {
        while (true)
        {
            Vector3 targetPos = (_moveToTarget) ? _targetTransform.position : transform.position;
            yield return null;

            float duration = (_movingPlatform.transform.position - targetPos).magnitude / _moveSpeed;
            Tween moveTween = _movingPlatform.DOMove(targetPos, duration);
            yield return new WaitForSeconds(duration);

            moveTween.Kill();
            yield return new WaitForSeconds(_waitDuration);
            _moveToTarget = !_moveToTarget;
        }


    }
}
