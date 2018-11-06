using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ColorShifter : MonoBehaviour {
    public Image img;
    public float slider_full;
    public Color full;
    public Color empty;

    public void OnValueChanged (float val) {
        img.color = Color.Lerp (full, empty, 1 - (val / slider_full));
    }
}
