using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mousePaint : MonoBehaviour
{
    private Color testColor;
    private Color mainColor;
    private Color paintColor;
    public Color[] colorList;
    public GameObject[] objectHit;
    public GameObject[] dieList;
    public GameObject dieDisplay;
    private Component[] disabledColors;
    public int colorCount, step;
    private PolygonCollider2D hit,undo;
    private bool check, active;
    public Sprite unusableSprite;
    public Sprite genericSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "ColorChoice")
        {
            paintColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            dieList[colorCount].GetComponent<SpriteRenderer>().color = paintColor;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColorChoice")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                check = false;
                colorList[colorCount] = paintColor;                
                objectHit[colorCount].GetComponent<SpriteRenderer>().sprite = genericSprite;
                objectHit[colorCount] = collision.gameObject;
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = dieList[colorCount].GetComponent<SpriteRenderer>().sprite;
                hit = collision.gameObject.GetComponent<PolygonCollider2D>();
                hit.enabled = !hit.enabled;
                Debug.Log("fire1");
                active = false;
            }
            else
            {
                check = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (check && active && collision.gameObject.tag == "ColorChoice")
        {
            dieList[colorCount].GetComponent<SpriteRenderer>().color = colorList[colorCount];
        }
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<mousePaint>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 5; i++)
        {
            objectHit[i].GetComponent<SpriteRenderer>().sprite = dieList[i].GetComponent<SpriteRenderer>().sprite;
            dieList[i].GetComponent<SpriteRenderer>().color = objectHit[i].GetComponent<SpriteRenderer>().color;
            colorList[i] = objectHit[i].GetComponent<SpriteRenderer>().color;
            hit = objectHit[i].GetComponent<PolygonCollider2D>();
            hit.enabled = !hit.enabled;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 2f;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    public void paint(int colorCode)
    {
        colorCount = colorCode;
        if (!active)
        {
            active = true;
            Debug.Log("paint");
            dieDisplay.GetComponent<ColorTransit>().die = dieList[colorCount];
            step = colorCount;
            undo = objectHit[colorCount].GetComponent<PolygonCollider2D>();
            undo.enabled = !undo.enabled;
            for (int i = 0; i <= 4; i++)
            {
                Debug.Log("forloop");
                if (step == 5)
                {
                    step = 0;
                    Debug.Log("if");
                }
                else
                {
                    step = step + 1;
                    Debug.Log("else");
                }
                dieDisplay.transform.GetChild(i).gameObject.GetComponent<ColorTransit>().die = dieList[step];
            }
        }
    }
}
