using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public Image hoverImage;
    public Image activeImage;
    public Image normalImage;
    public List<Sprite> normalImages;

    public bool Selected { get; set; }
    public int SquareIndex { get; set; }
    public bool SquareOccupied { get; set; }
    void Start()
    {
        Selected = false;
        SquareOccupied = false;

    }
    public bool CanWeUseThisSquare() // temporary functiopn. Remove it later
    {
        return hoverImage.gameObject.activeSelf;
    }

    public void ActivateSquare()
    {
        hoverImage.gameObject.SetActive(false);
        activeImage.gameObject.SetActive(true);
        Selected = true;
        SquareOccupied = true;
    }
    public void SetImage(bool setFirstImage)
    {
        normalImage.GetComponent<Image>().sprite = setFirstImage ? normalImages[1] : normalImages[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hoverImage.gameObject.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        hoverImage.gameObject.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hoverImage.gameObject.SetActive(false);

    }



}
