using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject sparklePrefab;
    public float sparkleInterval;
    public Vector2 bloodTrailOffset = Vector2.zero;
    private float bloodTrailDelay;

    void Update()
    {
        bloodTrailDelay += Time.deltaTime;
        if (bloodTrailDelay >= sparkleInterval)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.x = mousePosition.x + bloodTrailOffset.x;
            mousePosition.y = mousePosition.y + bloodTrailOffset.y;
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
            GameObject sparkle = Instantiate(sparklePrefab);

            sparkle.transform.position = new Vector3(mouseRay.origin.x, mouseRay.origin.y, 0f);

            bloodTrailDelay -= sparkleInterval;
        }
    }
}