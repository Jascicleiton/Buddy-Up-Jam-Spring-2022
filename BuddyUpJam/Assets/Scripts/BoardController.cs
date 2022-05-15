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
        totalPieces = transform.childCount;
        puzzlePieces = new GameObject[totalPieces];
        if(SceneManager.GetActiveScene().name == SceneName.TeoPuzzle.ToString())
        {           
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayMusic(3);
            }
        }
        
        piecesRotationsCorrect = new bool[puzzlePieces.Length];
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i] = piecesHolder.transform.GetChild(i).gameObject;
        }
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
                    SceneManager.LoadScene(SceneName.Credits.ToString());
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
