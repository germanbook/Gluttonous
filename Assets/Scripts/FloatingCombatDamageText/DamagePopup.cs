using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {

        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    private TextMeshPro textMesh;
    private float disappearTimer;
    private const float DISAPPEAR_TIME_MAX = 1f;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount)
    {
        string damageText;
        if( damageAmount == 0)
        {
            damageText = "Blocked";
        }
        else
        { damageText = damageAmount.ToString();}

        textMesh.SetText(damageText);
        textColor = textMesh.color;
        disappearTimer = 0.1f;
        disappearTimer = DISAPPEAR_TIME_MAX;

        moveVector = new Vector3(0, 1) * 6;
    }
    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        /*if (disappearTimer > DISAPPEAR_TIME_MAX * .5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float increaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * increaseScaleAmount * Time.deltaTime;

        }
*/
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 1f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
        }
        if (textColor.a < 0)
        {
            Destroy(gameObject);
        }
    }
}
