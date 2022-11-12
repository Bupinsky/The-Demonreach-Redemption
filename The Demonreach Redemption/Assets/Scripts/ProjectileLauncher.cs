using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject player;
    public GameObject arrow;
    public GameObject bulletBlueprint;
    public List<GameObject> bullets;
    public int numBullets;
    PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // convert mouse position to the relative world position of the mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);

        //calculate the direction vector for the bullet trajectory
        Vector3 launchDir = this.gameObject.transform.position - mousePosWorld;
        launchDir.z = 0;
        launchDir /= 2;
        Vector2 unitVec = new Vector2(0.0f, 1.0f);

        // rotating arrow shows the player where the bullets will go when they fire
        Vector3 arrowPos = (launchDir * 2.2f) + player.transform.position;
        arrow.transform.position = new Vector3(arrowPos.x, arrowPos.y, arrow.transform.position.z);

        // setting up the rotation
        //Vector2 unitVec = new Vector2(0, 1);
        Vector2 dirVec2 = new Vector2(launchDir.x, launchDir.y);
        arrow.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(unitVec, dirVec2));

        // get the normalized one:
        Vector3 launchNorm = launchDir.normalized;

        // hide the arrow if the player is not aiming
        if (Input.GetMouseButton(0) && playerScript.cooldown == false && numBullets > 0 && (bullets.Count == 0 || bullets[0] == null))
        {
            arrow.SetActive(true);
        } else
        {
            arrow.SetActive(false);
        }

        //controls
        if (Input.GetMouseButtonUp(0) && playerScript.cooldown == false)
        {
            // only shoot if the player has bullets & there are no bullets in play
            if (numBullets > 0 && (bullets.Count == 0 || bullets[0] == null))
            {
                //add bullets to the list of bullets, this will make them easy to manage.
                bullets.Add(Instantiate(bulletBlueprint, new Vector3(this.transform.position.x + launchNorm.x, this.transform.position.y + launchNorm.y, 0), Quaternion.identity));
                bullets[bullets.Count - 1].transform.localScale = new Vector3(1, 1, 1);
                bullets[bullets.Count - 1].GetComponent<BulletScript>().SetVelocity(launchDir.x, launchDir.y);
                
                numBullets -= 1;
            }
        }

        // the mouse is not clicked, so its safe to assume the next time the player clicks, they want to fire a bullet
        if (!Input.GetMouseButton(0))
        {
            playerScript.cooldown = false;
        }
    }

    void OnGUI()
    {

        GUI.color = Color.white;
        GUI.skin.box.fontSize = 24;
        GUI.skin.box.wordWrap = false;


        GUI.Box(new Rect(10, 10, 100, 30), "Shots: " + numBullets);
    }
}
