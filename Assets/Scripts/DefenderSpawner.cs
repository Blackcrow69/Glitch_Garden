using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    // Use this for initialization
    public Camera myCamera;

    private GameObject parent;
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        parent = GameObject.Find("Defenders");
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(defender);
        }
        else
        {
            Debug.LogWarning("Insufficient Stars!");
        }
    }

    private void SpawnDefender(GameObject defender)
    {
        GameObject newDef = Instantiate(defender, SnapToGrid(CalcWorldPointMouseClick()), Quaternion.identity) as GameObject;
        newDef.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid (Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    Vector2 CalcWorldPointMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);


        return worldPos;
    }
}
