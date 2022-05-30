using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell up;
    public Cell down;
    public Cell right;
    public Cell left;

    public Fill fill;

    private void OnEnable()
    {
        EventHandler.Slide += OnMoveMade;
    } 

    private void OnDisable()
    {
        EventHandler.Slide -= OnMoveMade;
    }

    private void OnMoveMade(PuzzleSequence direction)
    {
        
        if (direction == PuzzleSequence.Up)
        {
            if (up != null)
            {
                return;
            }
            Cell currentCell = this;
            UpPressed(currentCell);
        }

        if (direction == PuzzleSequence.Down)
        {
            if (down != null)
            {
                return;
            }
            Cell currentCell = this;
            DownPressed(currentCell);
        }
        if (direction == PuzzleSequence.Right)
        {
            if (right != null)
            {
                return;
            }
            Cell currentCell = this;
            RightPressed(currentCell);
        }
        if (direction == PuzzleSequence.Left)
        {
            if (left != null)
            {
                return;
            }
            Cell currentCell = this;
            LeftPressed(currentCell);
        }
        
    }



    private void UpPressed(Cell currentCell)
    {
        if(currentCell.down == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == fill)
            {
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.down.transform);
                currentCell.down.fill = nextCell.fill;
                nextCell.fill = null;
            }
        }
        else
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == fill)
            {
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.transform);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                UpPressed(currentCell);
            }
        }

        if (currentCell.down == null)
        {
            return;
        }
        UpPressed(currentCell.down);
    }

    private void DownPressed(Cell currentCell)
    {
        if (currentCell.up == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == fill)
            {
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.up.transform);
                currentCell.up.fill = nextCell.fill;
                nextCell.fill = null;
            }
        }
        else
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == fill)
            {
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.transform);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                DownPressed(currentCell);
            }
        }

        if (currentCell.up == null)
        {
            return;
        }
        DownPressed(currentCell.up);
    }


    private void RightPressed(Cell currentCell)
    {
        if (currentCell.left == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == fill)
            {
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.left.transform);
                currentCell.left.fill = nextCell.fill;
                nextCell.fill = null;
            }
        }
        else
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == fill)
            {
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.transform);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                RightPressed(currentCell);
            }
        }

        if (currentCell.left == null)
        {
            return;
        }
        RightPressed(currentCell.left);
    }

    private void LeftPressed(Cell currentCell)
    {
        if (currentCell.right == null)
        {
            return;
        }
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == fill)
            {
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.right.transform);
                currentCell.right.fill = nextCell.fill;
                nextCell.fill = null;
            }
        }
        else
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == fill)
            {
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.SetParent(currentCell.transform);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                LeftPressed(currentCell);
            }
        }

        if (currentCell.right == null)
        {
            return;
        }
        LeftPressed(currentCell.right);
    }

   
}
