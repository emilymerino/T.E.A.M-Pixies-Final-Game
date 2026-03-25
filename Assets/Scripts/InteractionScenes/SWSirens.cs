using System.Collections;
using UnityEngine;

public class SWSirens : MonoBehaviour
{
    public SpriteRenderer RedSiren;
    public Sprite alertRedSiren;

    public SpriteRenderer BlueSiren;
    public Sprite alertBlueSiren;

    public float onTime = 2f;
    public float offTime = 2f;

    void Start()
    {
        RedSiren.sprite = alertRedSiren;
        BlueSiren.sprite = alertBlueSiren;

        StartCoroutine(SirenLoop());
    }

    IEnumerator SirenLoop()
    {
        while (true)
        {
            // red on
            RedSiren.enabled = true;
            BlueSiren.enabled = false;
            yield return new WaitForSeconds(onTime);

            // both off
            RedSiren.enabled = false;
            yield return new WaitForSeconds(offTime);

            // blue on
            BlueSiren.enabled = true;
            yield return new WaitForSeconds(onTime);

            // both off
            BlueSiren.enabled = false;
            yield return new WaitForSeconds(offTime);
        }
    }
}