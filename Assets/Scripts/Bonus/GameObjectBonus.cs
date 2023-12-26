using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameObjectBonus : MonoBehaviour
{
    private GameObject landingParticle;
    private GameObject startingParticle;
    public void Initialize(float duration)
    {
        landingParticle = transform.GetChild(0).gameObject;
        startingParticle = transform.GetChild(1).gameObject;

        startingParticle.GetComponent<ParticleSystem>().Pause();
        landingParticle.GetComponent<ParticleSystem>().Pause();
        this.transform.position = new Vector3(-95, 118.5f, -45);
        StartCoroutine(StartMoveBonusObject(duration));
    }

    IEnumerator StartMoveBonusObject(float time)
    {
        //landingParticle.GetComponent<ParticleSystem>().Play();
        this.transform.DOMoveY(-18, 3.5f).SetEase(Ease.OutCirc).OnComplete(()=>
        {
            landingParticle.GetComponent<ParticleSystem>().Play();
        });
        yield return new WaitForSeconds(time -2);
        startingParticle.GetComponent<ParticleSystem>().Play();
        this.transform.DOMoveY(118, 3.5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
