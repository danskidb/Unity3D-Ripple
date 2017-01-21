﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPulse : MonoBehaviour {

    private Material mat;
    private Color startColor;

    private Color flashColor;
    private float flashColorTime = 0;

    void Start() {
        mat = GetComponent<MeshRenderer>().material;
        startColor = mat.GetColor("_Tint");
    }

    void Update() {
        mat.SetColor("_Tint", 
            Color.Lerp(startColor + new Color(0, 0, 0, Mathf.Sin(Time.time) / 6), flashColor, flashColorTime)
            );

        flashColorTime = Mathf.Lerp(flashColorTime, 0, 0.1f);
    }

    public void FlashColor(Color c) {
        flashColor = c;
        flashColorTime = 2;
    }
}
