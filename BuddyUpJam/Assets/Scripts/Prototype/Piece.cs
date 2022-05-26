using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
 [SerializeField]   Sprite[] foldSprites = null;
    SpriteRenderer spriteRenderer = null;
    // Correct sequence: up, up, down, down, left, right
    PuzzleSequence[] pieceSequence = null;
    public int sequenceIndex = 0;
    public int currentSequenceIndex = 0;
    public bool useRandomSequenceindex = true;
    public Board board = null;
   [HideInInspector] public int pieceIndex = 0;
    public bool canBeClicked = false;

    private void Awake()
    {
        SetSequenceList();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (useRandomSequenceindex)
        {
            sequenceIndex = Random.Range(0, 4);
            currentSequenceIndex = sequenceIndex;
        }
        SetFoldSprite();
    }

    private void Start()
    {
        if(board == null)
        {
            board = FindObjectOfType<Board>();
        }
    }

    private void OnEnable()
    {
        EventHandler.CraneClicked += CraneClicked;
        EventHandler.PieceRemoved += PieceRemoved;
    }

    private void OnDisable()
    {
        EventHandler.CraneClicked -= CraneClicked;
        EventHandler.PieceRemoved -= PieceRemoved;
    }

    private void SetSequenceList()
    {
        pieceSequence = new PuzzleSequence[6];
        // Correct sequence: up, up, down, down, left, right
        pieceSequence[0] = PuzzleSequence.Up;
        pieceSequence[1] = PuzzleSequence.Up;
        pieceSequence[2] = PuzzleSequence.Down;
        pieceSequence[3] = PuzzleSequence.Down;
        pieceSequence[4] = PuzzleSequence.Left;
        pieceSequence[5] = PuzzleSequence.Right;
    }

    public void SetFoldSprite()
    {
        if (spriteRenderer != null)
        {
            if (sequenceIndex >= foldSprites.Length)
            {
                AddCrane();
                board.RemovePiece(this);
            }
            if (sequenceIndex < foldSprites.Length)
            {
                spriteRenderer.sprite = foldSprites[sequenceIndex];
            }
        }
    }

    public void AddCrane()
    {
        if (board == null)
        {
            board = FindObjectOfType<Board>();
        }
        else
        {
            board.AddCrane();
            Destroy(gameObject);
        }
    }

    private void CraneClicked()
    {
        canBeClicked = true;
    }

    private void PieceRemoved()
    {
        canBeClicked = false;
    }

    public void Clicked ()
    {
        print("click");
        if (canBeClicked)
        {
            print("piece clicked");
            board.RemovePiece(this);
        }
    }

    private void OnMouseDown()
    {
        print("click");
        if (canBeClicked)
        {
            print("piece clicked");
            board.RemovePiece(this);
        }

    }
}
