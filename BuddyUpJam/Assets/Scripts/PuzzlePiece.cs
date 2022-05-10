using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public bool isCorrectRotation = false;
    private float[] possibleRotations = { 90f, 180f, 270f };

    private float correctRotation;

    [SerializeField] private BoardController boardController = null;
    private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        correctRotation = 0f;
        int random = Random.Range(0, 2);
        transform.Rotate(0f, 0f, possibleRotations[random]);
    }

    private void OnMouseDown()
    {
        if (!isCorrectRotation)
        {
            gameObject.transform.Rotate(0f, 0f, 90f);
            CheckRotation();
        }
       
    }

    private void CheckRotation()
    {
        
            if (transform.eulerAngles.z > -10f && transform.eulerAngles.z < 50f)
            {
                isCorrectRotation = true;

                boardController.SetPieceRotation(this);
                spriteRenderer.color = new Color(1f, 1f, 1f, 0.4f);
            }


        else
        {
            isCorrectRotation = false;
            boardController.SetPieceRotation(this);
        }
        

    }
}
