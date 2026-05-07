using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEditor.U2D;
using UnityEngine;

public class DraggableRank : MonoBehaviour
{
    public int rankLevel = 1;
    public float dragSpeed = 10f;
    public float snapBackSpeed = 20f;

    public bool isDragging = false;
    public Vector3 originalPosition;
    public GridCell currentCell;


    public Camera mainCamera;
    public Vector3 dragOffset;
    public SpriteRenderer spriteRenderer;
    public RankGameManager gameManager;

    public void MoveToCell(GridCell targetCell)
    {
        if(currentCell != null)
        {
            currentCell.currentRank = null;
            
        }
        currentCell = targetCell;
        targetCell.currentRank = this;

        originalPosition = new Vector3(targetCell.transform.position.x, targetCell.transform.position.y, 0f);
        transform.position = originalPosition;
        
    }

    public void ReturnToOtiginalPosition()
    {
        transform.position = originalPosition;
    }

    public void MergeWithCell(GridCell targetCell)
    {
        if (targetCell.currentRank == null || targetCell.currentRank.rankLevel != rankLevel)
        {
            ReturnToOtiginalPosition();
            return;
        }
        if (currentCell != null)
        {
            currentCell.currentRank = null;
        }
    }


    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    public void SetRankLevel(int level)
    {
        rankLevel = level;
        if (gameManager != null && gameManager.rankSprites.Length > level - 1)
        {
            spriteRenderer.sprite = gameManager.rankSprites[level - 1];
        }
    }
}
