using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SineObjectFloater : MonoBehaviour
{
    public bool paused = false;

    public float xAmplitude;
    public Ease xEase;
    public float xSpeed;
    Tween xTween;

    public float yAmplitude;
    public Ease yEase;
    public float ySpeed;
    Tween yTween;

    Vector3 initialPos;

    private void Start() {
        initialPos = transform.position;
        //xTween.SetSpeedBased(true);
        //yTween.SetSpeedBased(true);
        xTween = transform.DOMoveX(initialPos.x + xAmplitude, xSpeed).SetEase(xEase).SetSpeedBased(true);
        yTween = transform.DOMoveY(initialPos.y + yAmplitude, ySpeed).SetEase(yEase).SetSpeedBased(true);
    }

    bool xGoingBack = false;
    bool yGoingBack = false;

    private void Update() {
        if (paused) {
            xTween.Pause();
            yTween.Pause();
        } else {
            xTween.Play();
            yTween.Play();
        }
        if (!xTween.IsActive()) {
            if (xGoingBack) {
                xTween = transform.DOMoveX(initialPos.x + xAmplitude, xSpeed).SetEase(xEase).SetSpeedBased(true);
            } else {
                xTween = transform.DOMoveX(initialPos.x - xAmplitude, xSpeed).SetEase(xEase).SetSpeedBased(true);
            }
            xGoingBack = !xGoingBack;
        }
        if (!yTween.IsActive()) {
            if (yGoingBack) {
                yTween = transform.DOMoveY(initialPos.y + yAmplitude, ySpeed).SetEase(yEase).SetSpeedBased(true);;
            } else {
                yTween = transform.DOMoveY(initialPos.y - yAmplitude, ySpeed).SetEase(yEase).SetSpeedBased(true);;
            }
            yGoingBack = !yGoingBack;
        }
    }

}
