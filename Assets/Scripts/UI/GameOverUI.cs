using System;
using _GAME_.Scripts.Actions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Vector3 startPos;
    [SerializeField] private Image restartImage;
    private void OnEnable()
    {
        GameFlow.levelFailed += DisplaySelf;
        GameFlow.levelRestarted += ResetPosition;
    }

    private void OnDisable()
    {
        GameFlow.levelFailed -= DisplaySelf;
        GameFlow.levelRestarted -= ResetPosition;
    }

    private void Awake()
    {
        restartImage.enabled = false;
        startPos = transform.position;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void ResetPosition()
    {
        restartImage.enabled = false;
        transform.position = startPos;
    }

    private void DisplaySelf()
    {
        
        _rectTransform.DOAnchorPosY(-250,1f).SetEase(Ease.InOutCirc).onComplete = () =>
        {
            restartImage.enabled = true;
        };
    }
}
