using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public List<colletable> colletablesList = new List<colletable>();

  public void AddItem(colletable item)
    {
        colletablesList.Add(item);
    }
}
