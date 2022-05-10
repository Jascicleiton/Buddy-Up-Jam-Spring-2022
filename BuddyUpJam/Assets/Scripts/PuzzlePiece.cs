using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    [HideInInspector] public bool isCorrectRotation = false;
    private float[] possibleRotations = { 90f, 180f, 270f };

    private float correctRotation;
    private Animator animator = null;
    private Image highlight = null;

    [SerializeField] private BoardController boardController = null;
    private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
        highlight = GetComponentInChildren<Image>();
    }
    private void Start()
    {
        correctRotation = 0f;
        int random = Random.Range(0, 2);
        transform.Rotate(0f, 0f, possibleRotations[random]);
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.4f);
    }

    private void OnMouseDown()
    {
        print(isCorrectRotation);
        if (!isCorrectRotation)
        {
            
            gameObject.transform.Rotate(0f, 0f, 90f);
            CheckRotation();
        }
       
    }

    private void CheckRotation()
    {
        
            if (this.transform.eulerAngles.z > -30f && this.transform.eulerAngles.z < 50f)
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
}
