using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopupPoints : MonoBehaviour
{
    private void Start()
    {
        this.transform.DOScale(0, .5f).SetEase(Ease.InBack);
        this.transform.DOMoveY(transform.position.y + 1.5f, 1f).OnComplete(()=> {
            Destroy(this.gameObject);
        });        
    }
}
