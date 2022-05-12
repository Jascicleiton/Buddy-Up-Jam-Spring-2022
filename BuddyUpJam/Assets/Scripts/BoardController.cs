using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private GameObject piecesHolder = null;
   [SerializeField] private GameObject[] puzzlePieces = null;
    [SerializeField] private GameObject piecePrefab = null;
    private bool[] piecesRotationsCorrect = null;

    [SerializeField] private int totalPieces = 25;
    public bool gameWon = true;
    // Start is called before the first frame update
    void Start()
    {
        puzzlePieces = new GameObject[totalPieces];
        //for (int i = 0; i < Mathf.Sqrt(totalPieces); i++)
        //{
        //    for (int j = 0; j < Mathf.Sqrt(totalPieces); j++)
        //    {
        //        puzzlePieces[i] = Instantiate(piecePrefab, this.transform);
        //        puzzlePieces[i].name = "PuzzlePiece_" + i + j;
        //        puzzlePieces[i].transform.position = new Vector3(i * 3, j * 3, 0f);
        //    }
            
        //}
        //gameObject.transform.position = new Vector3(-6, -6, 0);
       // totalPieces = gameObject.transform.childCount;
        
        piecesRotationsCorrect = new bool[puzzlePieces.Length];
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i] = piecesHolder.transform.GetChild(i).gameObject;
        }
    }

    private void SpawnPieces()
    {

    }

    public void SetPieceRotation(PuzzlePiece piece)
    {
        
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            
            if (piece.GetPieceName() == puzzlePieces[i].gameObject.name)
            {
                piecesRotationsCorrect[i] = piece.isCorrectRotation;
                if (CheckIfAllPiecesRotationsAreCorrect())
                {
                    SceneManager.LoadScene(SceneName.MainMenu.ToString());
                }

                return;
            }
        }
        
    }

    private bool CheckIfAllPiecesRotationsAreCorrect()
    {
        gameWon = true;

        for (int i = 0; i < piecesRotationsCorrect.Length; i++)
        {
           
            if (!piecesRotationsCorrect[i])
            {
                gameWon = false;
                break;
            }         
            else
            {
                gameWon = true;
                
            }
        }
        return gameWon;
    }
}
