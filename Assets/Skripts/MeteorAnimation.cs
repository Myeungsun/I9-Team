using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeteorAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector2(-170, 470),1).SetEase(Ease.Unset); //  140, 790 에서 -170, 470 으로가기
    }
}
