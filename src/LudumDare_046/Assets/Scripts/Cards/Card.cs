using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
  None,
  Gene,
  Part,
  Blessing
}

public class Card : MonoBehaviour
{
  public string Name;
  public string Tooltip;

  public CardType CardType;

  public Color Color;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    
  }
}
