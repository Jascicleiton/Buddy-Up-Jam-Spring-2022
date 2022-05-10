using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private GameObject piecesHolder = null;
   [SerializeField] private GameObject[] puzzlePieces = null;
    private bool[] piecesRotations = null;

    private int totalPieces = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalPieces = gameObject.transform.childCount;
        puzzlePieces = new GameObject[totalPieces];
        piecesRotations = new bool[puzzlePieces.Length];
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i] = piecesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void SetPieceRotation(PuzzlePiece piece)
    {
        print(piece.gameObject.name);
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            print(puzzlePieces[i].gameObject.name);
            if (piece.gameObject.name == puzzlePieces[i].gameObject.name)
            {
                piecesRotations[i] = piece.isCorrectRotation;
               
                CheckIfPiecesRotationsAreCorrect();
                return;
            }
        }
    }

    private void CheckIfPiecesRotationsAreCorrect()
    {
        for (int i = 0; i < piecesRotations.Length; i++)
        {
           
            if (!piecesRotations[i])
            {
              
                continue;
            }
            else
            {
                print("Game won");
            }
        }
    }
}
