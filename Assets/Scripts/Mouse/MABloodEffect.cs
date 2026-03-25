using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject sparklePrefab;
    public Transform canvas; // drag your Canvas here
    public float sparkleInterval = 0.05f;
    public Vector2 bloodTrailOffset = Vector2.zero;

    private float bloodTrailDelay;

    void Update()
    {
        bloodTrailDelay += Time.deltaTime;

        if (bloodTrailDelay >= sparkleInterval)
        {
            Vector3 mousePosition = Input.mousePosition;

            // apply offset
            mousePosition.x += bloodTrailOffset.x;
            mousePosition.y += bloodTrailOffset.y;

            // spawn inside canvas
            GameObject sparkle = Instantiate(sparklePrefab, canvas);

            // set UI position
            RectTransform rect = sparkle.GetComponent<RectTransform>();
            rect.position = mousePosition;

            // make sure it renders on top
            sparkle.transform.SetAsFirstSibling();

            bloodTrailDelay = 0f;
        }
    }
}