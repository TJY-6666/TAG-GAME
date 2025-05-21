using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
    public playerScript playerScript;
    public Color colorGhost = Color.red;
    public Color colorPlayer = Color.blue;

    public Renderer objRenderer;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        // Get the current color of the material
        Color color = objRenderer.material.color;
        // Set the alpha value to 0
        color.a = 0f;
        // Assign the new color back to the material
        objRenderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerScript.hit)
        {
            ChangeColor(colorGhost);
        } else
        {
            ChangeColor(colorPlayer);
        }
    }

    public void ChangeColor(Color newColor)
    {
        // Change the color of the parent
        ChangeObjectColor(gameObject, newColor);

        // Iterate through all the children and change their color
        foreach (Transform child in transform)
        {
            ChangeObjectColor(child.gameObject, newColor);
        }
    }

    private void ChangeObjectColor(GameObject obj, Color newColor)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            objRenderer.material.color = newColor;
            objRenderer.material.SetColor("_EmissionColor", newColor);
            objRenderer.material.EnableKeyword("_EMISSION");
        }
    }

}
