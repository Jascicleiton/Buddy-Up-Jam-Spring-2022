using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    [SerializeField] Sprite[] foldSprites;
    Image image = null;
    // Correct sequence: up, up, down, down, left, right
    PuzzleSequence[] pieceSequence = null;
    //public int sequenceIndex = 0;
    public int currentSequenceIndex = 0;
    [SerializeField] float speed;

    private bool canBeClicked = false;

    private void Awake()
    {
        image = GetComponent<Image>();
        SetSequenceList();
    }

    private void OnEnable()
    {
        EventHandler.Slide += OnMoveMade;
        EventHandler.CraneClicked += CraneClicked;

    }

    private void OnDisable()
    {
        EventHandler.Slide -= OnMoveMade;
        EventHandler.CraneClicked -= CraneClicked;
    }

    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
    }

    public void FillImageUpdate(int nextSequenceIndex)
    {
        currentSequenceIndex = nextSequenceIndex;
        image.sprite = foldSprites[currentSequenceIndex];
    }

    private void FillImageUpdate()
    {
        image.sprite = foldSprites[currentSequenceIndex];
    }

    private void OnMoveMade(PuzzleSequence sequencePressed)
    {
        if(sequencePressed == pieceSequence[currentSequenceIndex])
        {
            currentSequenceIndex++;
            if (currentSequenceIndex < pieceSequence.Length)
            {
                FillImageUpdate();
            }
            else
            {
                Board.Instance.AddCrane();
                PieceRemoved();

            }
        }
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

    private void CraneClicked()
    {
        GetComponent<Button>().interactable = true;
    }

    private void PieceRemoved()
    {
        GetComponentInParent<Cell>().fill = null;
        Destroy(this.gameObject);
    }

    public void Clicked()
    {
            PieceRemoved();
            EventHandler.CallPieceRemoved();    
    }


    //   public bool useRandomSequenceindex = true;
    //   public Board board = null;
    //  [HideInInspector] public int pieceIndex = 0;
    //   public bool canBeClicked = false;

    //   private void Awake()
    //   {
    //       SetSequenceList();
    //       spriteRenderer = GetComponent<SpriteRenderer>();
    //       if (useRandomSequenceindex)
    //       {
    //           sequenceIndex = Random.Range(0, 4);
    //           currentSequenceIndex = sequenceIndex;
    //       }
    //       SetFoldSprite();
    //   }

    //   private void Start()
    //   {
    //       if(board == null)
    //       {
    //           board = FindObjectOfType<Board>();
    //       }
    //   }

    //   private void OnEnable()
    //   {
    //       EventHandler.CraneClicked += CraneClicked;
    //       EventHandler.PieceRemoved += PieceRemoved;
    //   }

    //   private void OnDisable()
    //   {
    //       EventHandler.CraneClicked -= CraneClicked;
    //       EventHandler.PieceRemoved -= PieceRemoved;
    //   }

    //   private void SetSequenceList()
    //   {
    //       pieceSequence = new PuzzleSequence[6];
    //       // Correct sequence: up, up, down, down, left, right
    //       pieceSequence[0] = PuzzleSequence.Up;
    //       pieceSequence[1] = PuzzleSequence.Up;
    //       pieceSequence[2] = PuzzleSequence.Down;
    //       pieceSequence[3] = PuzzleSequence.Down;
    //       pieceSequence[4] = PuzzleSequence.Left;
    //       pieceSequence[5] = PuzzleSequence.Right;
    //   }

    //   public void SetFoldSprite()
    //   {
    //       if (spriteRenderer != null)
    //       {
    //           if (sequenceIndex >= foldSprites.Length)
    //           {
    //               AddCrane();
    //               board.RemovePiece(this);
    //           }
    //           if (sequenceIndex < foldSprites.Length)
    //           {
    //               spriteRenderer.sprite = foldSprites[sequenceIndex];
    //           }
    //       }
    //   }



    //   private void CraneClicked()
    //   {
    //       canBeClicked = true;
    //   }

    //   private void PieceRemoved()
    //   {
    //       canBeClicked = false;
    //   }

    //   public void Clicked ()
    //   {
    //       print("click");
    //       if (canBeClicked)
    //       {
    //           print("piece clicked");
    //           board.RemovePiece(this);
    //       }
    //   }

    //   private void OnMouseDown()
    //   {
    //       print("click");
    //       if (canBeClicked)
    //       {
    //           print("piece clicked");
    //           board.RemovePiece(this);
    //       }

    //   }

    //   public void MoveUp()
    //   {

    //   }
    //   public void MoveDown()
    //   {
    //   }
    //   public void MoveRight()
    //   {
    //   }
    //   public void MoveLeft()
    //   {
    //   }
}
