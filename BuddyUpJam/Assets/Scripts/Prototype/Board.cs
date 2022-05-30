using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Board : Singleton<Board>
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;
    PuzzleSequence[] pieceSequence = null;
    public bool canMove = true;

   [SerializeField] private float spawnTimer = 0.5f;
   [SerializeField] private Crane[] cranes = null;


    [Tooltip("The number of cranes that need to be made to 'finish' the puzzle")]
    [SerializeField] int cranesGoal = 5;
    private int currentCranesCount = 0;




    protected override void Awake()
    {
        base.Awake();
        SetSequenceList();
    }

    private void Start()
    {
        StartSpawnFill();
    }

    private void OnEnable()
    {
        EventHandler.CraneClicked += CraneClicked;
        EventHandler.PieceRemoved += RemoveCrane;
    }

    private void OnDisable()
    {
        EventHandler.CraneClicked -= CraneClicked;
        EventHandler.PieceRemoved -= RemoveCrane;
    }

    private void Update()
    {
        if (canMove)
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            //{
            //    SpawnFill();
            //}
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                EventHandler.CallSlide(PuzzleSequence.Up);
                StartCoroutine(SpawnRoutine());
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                EventHandler.CallSlide(PuzzleSequence.Down);
                StartCoroutine(SpawnRoutine());
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                EventHandler.CallSlide(PuzzleSequence.Right);
                StartCoroutine(SpawnRoutine());
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                EventHandler.CallSlide(PuzzleSequence.Left);
                StartCoroutine(SpawnRoutine());
            }
        }
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(spawnTimer);
        SpawnFill();
    }

    private void CraneClicked()
    {
        canMove = false;
        
    }

    public void SpawnFill()
    {
        int whereToSpawn = Random.Range(0, allCells.Length);

        if (allCells[whereToSpawn].childCount != 0)
        {
            SpawnFill();
            return;
        }
        float chance = Random.Range(0f, 1f);
        
        if (chance < 0.25)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whereToSpawn]);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[whereToSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillImageUpdate(Random.Range(0, 4));
        }
        else if (chance < 0.50)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whereToSpawn]);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[whereToSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillImageUpdate(Random.Range(0, 4));

        }
        else if(chance < 0.75)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whereToSpawn]);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[whereToSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillImageUpdate(Random.Range(0, 4));

        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whereToSpawn]);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[whereToSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillImageUpdate(Random.Range(0, 4));
        }
    }

    public void StartSpawnFill()
    {
        int whereToSpawn = Random.Range(0, allCells.Length);

        if (allCells[whereToSpawn].childCount != 0)
        {
            SpawnFill();
            return;
        }    
            GameObject tempFill = Instantiate(fillPrefab, allCells[whereToSpawn]);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[whereToSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillImageUpdate(0);      
    }


    private void SetSequenceList()
    {
        pieceSequence = new PuzzleSequence[6];
        pieceSequence[0] = PuzzleSequence.Up;
        pieceSequence[1] = PuzzleSequence.Up;
        pieceSequence[2] = PuzzleSequence.Down;
        pieceSequence[3] = PuzzleSequence.Down;
        pieceSequence[4] = PuzzleSequence.Left;
        pieceSequence[5] = PuzzleSequence.Right;
    }

    //  private List<Piece> pieces = null;
    //  [SerializeField] Transform[] piecesTransforms = null;
    //[SerializeField]  private bool[] spaceOccupied = null;
    /// <summary>
    /// The number of cranes that need to be made to "finish" the puzzle
    /// </summary>
    //  PuzzleSequence[] pieceSequence = null;

    //  [SerializeField] private GameObject warningText = null;
    //  [SerializeField] private GameObject piecePrefab = null;
    //  [SerializeField] private GameObject endGameMessage = null;

    //  public int currentPieceIndex = 0;
    //  public bool canMove = true;


    //  private void Awake()
    //  {
    //      pieces = new List<Piece>();
    //      SetSequenceList();
    //      spaceOccupied = new bool[piecesTransforms.Length];
    //      for (int i = 0; i < spaceOccupied.Length; i++)
    //      {
    //          spaceOccupied[i] = false;
    //      }       
    //  }

    //  // Start is called before the first frame update
    //  void Start()
    //  {
    //      Piece[] tempPieces = FindObjectsOfType<Piece>();
    //      for (int i = 0; i < tempPieces.Length; i++)
    //      {
    //          pieces.Add(tempPieces[i]);
    //          tempPieces[i].board = this;
    //          pieces[i].pieceIndex = i;
    //          SetPositionOccupied();
    //      }
    //      if (cranes == null)
    //      {
    //          cranes = FindObjectsOfType<Crane>();
    //      }
    //  }

    //  private void Update()
    //  {
    //      if (canMove)
    //      {
    //          if (Input.GetKeyDown(KeyCode.UpArrow))
    //          {
    //              CheckSequence(PuzzleSequence.Up);
    //              MovePieces(0);
    //          }
    //          if (Input.GetKeyDown(KeyCode.DownArrow))
    //          {
    //              CheckSequence(PuzzleSequence.Down);
    //              MovePieces(1);
    //          }
    //          if (Input.GetKeyDown(KeyCode.RightArrow))
    //          {
    //              CheckSequence(PuzzleSequence.Right);
    //              MovePieces(2);
    //          }
    //          if (Input.GetKeyDown(KeyCode.LeftArrow))
    //          {
    //              CheckSequence(PuzzleSequence.Left);
    //              MovePieces(3);
    //          }
    //      }
    //  }

    //  private void SetSequenceList()
    //  {
    //      pieceSequence = new PuzzleSequence[6];
    //      // Correct sequence: up, up, down, down, left, right
    //      pieceSequence[0] = PuzzleSequence.Up;
    //      pieceSequence[1] = PuzzleSequence.Up;
    //      pieceSequence[2] = PuzzleSequence.Down;
    //      pieceSequence[3] = PuzzleSequence.Down;
    //      pieceSequence[4] = PuzzleSequence.Left;
    //      pieceSequence[5] = PuzzleSequence.Right;
    //  }

    //  private void CheckSequence(PuzzleSequence puzzleSequence)
    //  {
    //      for (int i = 0; i < pieces.Count; i++)
    //      {   
    //          if(pieceSequence[pieces[i].currentSequenceIndex] == puzzleSequence)
    //          {
    //              pieces[i].currentSequenceIndex++;
    //              pieces[i].sequenceIndex = pieces[i].currentSequenceIndex;
    //              pieces[i].SetFoldSprite();
    //          }
    //      }        

    //  }

    //  private bool CheckPositionOccupied(int positionIndex)
    //  {
    //      if (spaceOccupied[positionIndex])
    //      {
    //          return true;
    //      }
    //      else
    //      {
    //          return false;
    //      }
    //  }

    //  private void SetPositionOccupied()
    //  {
    //      for (int i = 0; i < piecesTransforms.Length; i++)
    //      {
    //          for (int j = 0; j < pieces.Count; j++)
    //          {
    //              if (pieces[j].transform.position == piecesTransforms[i].position)
    //              {
    //                  spaceOccupied[i] = true;
    //              }
    //          }
    //      }
    //  }

    //  private bool CheckIfNoSpaceAvailable()
    //  {
    //      bool noSpaceAvailable = true;
    //      for (int i = 0; i < spaceOccupied.Length; i++)
    //      {
    //          if (!spaceOccupied[i])
    //          {
    //              noSpaceAvailable = false;
    //              break;
    //          }
    //      }
    //      return noSpaceAvailable;
    //  }

    //  private void AddPiece()
    //  {
    //      int indexToAdd = Random.Range(0, 9);

    //      if (!CheckIfNoSpaceAvailable())
    //      {
    //          while (CheckPositionOccupied(indexToAdd))
    //          {
    //              indexToAdd = Random.Range(0, 9);
    //          }
    //         GameObject newPiece =  Instantiate(piecePrefab, piecesTransforms[indexToAdd].position, Quaternion.identity);
    //          pieces.Add(newPiece.GetComponent<Piece>());
    //          SetPositionOccupied();
    //      }

    //  }

    //  private IEnumerator Deactivate(GameObject gameObjectToDeactivate)
    //  {
    //      yield return new WaitForSeconds(3f);
    //      gameObjectToDeactivate.SetActive(false);
    //  }

    //  /// <summary>
    //  /// Direction to move: 0 = up, 1 = down, 2 = right, 3 = left
    //  /// </summary>
    //  private void MovePieces(int direction)
    //  {
    //      switch (direction)
    //      {
    //          case 0:
    //              for (int i = 0; i < pieces.Count; i++)
    //              {
    //                  pieces[i].MoveUp();
    //              }
    //              break;
    //          case 1:
    //              for (int i = 0; i < pieces.Count; i++)
    //              {
    //                  pieces[i].MoveDown();
    //              }
    //              break;
    //          case 2:
    //              for (int i = 0; i < pieces.Count; i++)
    //              {
    //                  pieces[i].MoveRight();
    //              }
    //              break;
    //          case 3:
    //              for (int i = 0; i < pieces.Count; i++)
    //              {
    //                  pieces[i].MoveLeft();
    //              }
    //              break;
    //          default:
    //              break;
    //      }
    //      MoveMade();
    //  }

    //  public void RemovePiece(Piece pieceToRemove)
    //  {
    //      print("removing piece");
    //      pieces.Remove(pieceToRemove);
    //      Destroy(pieceToRemove.gameObject);
    //      if (pieceToRemove.canBeClicked)
    //      {
    //          RemoveCrane();
    //      }
    //      EventHandler.CallPieceRemoved();
    //  }

    //  public void MoveMade()
    //  {
    //      if (!CheckIfNoSpaceAvailable())
    //      {
    //          AddPiece();
    //      }
    //      else
    //      {
    //          canMove = false;
    //          if(currentCranesCount <=0)
    //          {
    //              endGameMessage.SetActive(true);
    //          }
    //          else
    //          {
    //              warningText.SetActive(true);
    //              StartCoroutine(Deactivate(warningText));
    //          }
    //      }
    //  }

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
            SceneManager.LoadScene(SceneName.Credits.ToString());
        }
    }

    public void RemoveCrane()
    {
        print("crane removed");
        currentCranesCount--;
        int tempIndex = cranesGoal - 1;
        for (int i = tempIndex; i > -1 ; i--)
        {
            if (cranes[i].isActiveAndEnabled)
            {
                cranes[i].gameObject.SetActive(false);
                break;
            }
        }
        SpawnFill();
        canMove = true;
    }

}
