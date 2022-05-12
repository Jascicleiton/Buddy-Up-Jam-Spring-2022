using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public bool isCorrectRotation = false;
    public Sprite pieceSprite;
    private float[] possibleRotations = { 90f, 180f, 270f };

    private float correctRotation;
    private Animator animator = null;
    private Image highlight = null;

    [SerializeField] private BoardController boardController = null;
    [SerializeField] private GameObject objectToRotate = null;
    private SpriteRenderer spriteRenderer = null;
    private string pieceName;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
        highlight = GetComponentInChildren<Image>();
        pieceName = transform.parent.name;
    }
    private void Start()
    {
        correctRotation = 0f;
        int random = Random.Range(0, 2);
        objectToRotate.transform.Rotate(0f, 0f, possibleRotations[random], Space.Self);
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.4f);
        isCorrectRotation = false;
    }

    private void OnMouseDown()
    {
        
        if (!isCorrectRotation)
        {
            if (Input.GetMouseButton(0))
            {
                objectToRotate.transform.Rotate(0f, 0f, 90f, Space.Self);
                CheckRotation();
            }
            else if (Input.GetMouseButton(2))
            {
                objectToRotate.transform.Rotate(0f, 0f, -90f, Space.Self);
                CheckRotation();
            }
        }
       
    }

    private void CheckRotation()
    {

        if (objectToRotate.transform.localRotation.eulerAngles.z > -80 && objectToRotate.transform.localRotation.eulerAngles.z < 80)
        {
            isCorrectRotation = true;
            animator.SetBool("shouldWigle", false);
            highlight.enabled = false;
            boardController.SetPieceRotation(this);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }


        else
        {
            isCorrectRotation = false;
            boardController.SetPieceRotation(this);
        }


    }

    private void OnMouseEnter()
    {
        if (!isCorrectRotation)
        {
            animator.SetBool("shouldWigle", true);
           // highlight.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (!isCorrectRotation)
        {
            animator.SetBool("shouldWigle", false);
           // highlight.enabled = false;
        }
    }

    public string GetPieceName()
    {
        return pieceName;
    }
}
