using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barscript : MonoBehaviour {
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Text barText;

    [SerializeField]
    private Color fullColour;

    [SerializeField]
    private Color lowColour;

    public float MaxValue { get; set; }

    // Use this for initialization
    void Start () {
		
	}

    public float Value
    {
        set
        {
            string[] tmp = barText.text.Split(':');
            barText.text = tmp[0] + ": " + Mathf.Round(value);
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
        content.color = Color.Lerp(lowColour, fullColour, fillAmount);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
