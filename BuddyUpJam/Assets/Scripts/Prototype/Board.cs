using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Board : MonoBehaviour
{
    private List<Piece> pieces = null;
    [SerializeField] Transform[] piecesTransforms = null;
  [SerializeField]  private bool[] spaceOccupied = null;
    /// <summary>
    /// The number of cranes that need to be made to "finish" the puzzle
    /// </summary>
    [Tooltip("The number of cranes that need to be made to 'finish' the puzzle")]
    [SerializeField] int cranesGoal = 5;
    private int currentCranesCount = 0;
    PuzzleSequence[] pieceSequence = null;

    [SerializeField] private GameObject warningText = null;
    [SerializeField] private Crane[] cranes = null;
    [SerializeField] private GameObject piecePrefab = null;
    [SerializeField] private GameObject endGameMessage = null;

    public int currentPieceIndex = 0;
    public bool canMove = true;
    

    private void Awake()
    {
        pieces = new List<Piece>();
        SetSequenceList();
        spaceOccupied = new bool[piecesTransforms.Length];
        for (int i = 0; i < spaceOccupied.Length; i++)
        {
            spaceOccupied[i] = false;
        }       
    }

    // Start is called before the first frame update
    void Start()
    {
        Piece[] tempPieces = FindObjectsOfType<Piece>();
        for (int i = 0; i < tempPieces.Length; i++)
        {
            pieces.Add(tempPieces[i]);
            tempPieces[i].board = this;
            pieces[i].pieceIndex = i;
            SetPositionOccupied();
        }
        if (cranes == null)
        {
            cranes = FindObjectsOfType<Crane>();
        }
    }

    private void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CheckSequence(PuzzleSequence.Up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CheckSequence(PuzzleSequence.Down);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CheckSequence(PuzzleSequence.Right);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CheckSequence(PuzzleSequence.Left);
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

    private void CheckSequence(PuzzleSequence puzzleSequence)
    {
        for (int i = 0; i < pieces.Count; i++)
        {   
            if(pieceSequence[pieces[i].currentSequenceIndex] == puzzleSequence)
            {
                pieces[i].currentSequenceIndex++;
                pieces[i].sequenceIndex = pieces[i].currentSequenceIndex;
                pieces[i].SetFoldSprite();
            }
        }        
       MoveMade();
    }

    private bool CheckPositionOccupied(int positionIndex)
    {
        if (spaceOccupied[positionIndex])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetPositionOccupied()
    {
        for (int i = 0; i < piecesTransforms.Length; i++)
        {
            for (int j = 0; j < pieces.Count; j++)
            {
                if (pieces[j].transform.position == piecesTransforms[i].position)
                {
                    spaceOccupied[i] = true;
                }
            }
        }
    }

    private bool CheckIfNoSpaceAvailable()
    {
        bool noSpaceAvailable = true;
        for (int i = 0; i < spaceOccupied.Length; i++)
        {
            if (!spaceOccupied[i])
            {
                noSpaceAvailable = false;
                break;
            }
        }
        return noSpaceAvailable;
    }

    private void AddPiece()
    {
        int indexToAdd = Random.Range(0, 9);

        if (!CheckIfNoSpaceAvailable())
        {
            while (CheckPositionOccupied(indexToAdd))
            {
                indexToAdd = Random.Range(0, 9);
            }
           GameObject newPiece =  Instantiate(piecePrefab, piecesTransforms[indexToAdd].position, Quaternion.identity);
            pieces.Add(newPiece.GetComponent<Piece>());
            SetPositionOccupied();
        }
       
    }

    private IEnumerator Deactivate(GameObject gameObjectToDeactivate)
    {
        yield return new WaitForSeconds(3f);
        gameObjectToDeactivate.SetActive(false);
    }

    public void RemovePiece(Piece pieceToRemove)
    {
        print("removing piece");
        pieces.Remove(pieceToRemove);
        Destroy(pieceToRemove.gameObject);
        if (pieceToRemove.canBeClicked)
        {
            RemoveCrane();
        }
        EventHandler.CallPieceRemoved();
    }

    public void MoveMade()
    {
        if (!CheckIfNoSpaceAvailable())
        {
            AddPiece();
        }
        else
        {
            canMove = false;
            if(currentCranesCount <=0)
            {
                endGameMessage.SetActive(true);
            }
            else
            {
                warningText.SetActive(true);
                StartCoroutine(Deactivate(warningText));
            }
        }
    }

    public void AddCrane()
    {
        currentCranesCount++;
        for (int i = 0; i < cranes.Length; i++)
        {
            if (!cranes[i].isActiveAndEnabled)
            {
                cranes[i].gameObject.SetActive(true);
                break;
            }
        }
        if (currentCranesCount == cranesGoal)
        {
            // End puzzle
        }
    }

    public void RemoveCrane()
    {
        currentCranesCount--;
        int indexToRemove =  cranes.Length - 1;
        cranes[indexToRemove].gameObject.SetActive(false);
        AddPiece();
        canMove = true;
    }
        
}
