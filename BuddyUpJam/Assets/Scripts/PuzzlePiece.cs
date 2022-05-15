using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour
{
    public bool isCorrectRotation = false;
    public Sprite pieceSprite;
    private float[] possibleRotations = { 90f, 180f, 270f };

    private float correctRotation;
    private Animator animator = null;
    

    [SerializeField] private BoardController boardController = null;
    [SerializeField] private GameObject objectToRotate = null;
    private Image image = null;
    private string pieceName;

    private void Awake()
    {
        image = GetComponent<Image>();
        animator = GetComponentInParent<Animator>();
        objectToRotate = this.gameObject;
        pieceName = transform.parent.name;
    }
    private void Start()
    {
        correctRotation = 0f;
        int random = Random.Range(0, 2);
        objectToRotate.transform.Rotate(0f, 0f, possibleRotations[random], Space.Self);
        image.color = new Color(1f, 1f, 1f, 0.8f);
        isCorrectRotation = false;
    }

    public void OnMouseDown()
    {
        if (!isCorrectRotation)
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySfx(7);
            }
                objectToRotate.transform.Rotate(0f, 0f, 90f, Space.Self);
                CheckRotation();
        }
        else
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySfx(8);
            }
        }
       
    }

    private void CheckRotation()
    {

        if (objectToRotate.transform.localRotation.eulerAngles.z > -80 && objectToRotate.transform.localRotation.eulerAngles.z < 80)
        {
            isCorrectRotation = true;
            animator.SetBool("shouldWigle", false);
            
            boardController.SetPieceRotation(this);
            image.color = new Color(1f, 1f, 1f, 1f);
        }


        else
        {
            isCorrectRotation = false;
            boardController.SetPieceRotation(this);
        }


    }

    public void OnMouseEnter()
    {
        if (!isCorrectRotation)
        {
            animator.SetBool("shouldWigle", true);
           // highlight.enabled = true;
        }
    }

    public void OnMouseExit()
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
