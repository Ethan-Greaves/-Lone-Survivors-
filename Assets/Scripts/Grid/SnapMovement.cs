using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapMovement : MonoBehaviour
{
    [SerializeField] float gridSize = 10f;
    TextMesh textMesh;
    private Vector2 snapPos;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;

        transform.position = new Vector2(snapPos.x, snapPos.y);

        string grideCubeText = textMesh.text = (snapPos.x + 8.5) + ", " + (snapPos.y + 4.5);
        gameObject.name = grideCubeText;
    }
}
