using System.Collections.Generic;
using UnityEngine;

public class repository : MonoBehaviour
{
    public static repository repositoryX;
    /*[SerializeField]
    private AudioClip clipDash = null;*/
    /*[SerializeField]
    private GameObject onomatopoeiaBase = null, efxHitObj = null;*/
    /*[SerializeField]
    private ballonsTalk ballonsTalkBase = null;*/
    /*[SerializeField]
    private GameObject gameMaskEnterChar = null, healObj = null;*/
    private List<AudioSource> audioSourcesList = new List<AudioSource>();
    public PhysicsMaterial2D physicsMaterialDontMove, physicsMaterialCharaterDafault;
    [Header("Layers")]
    /*[SerializeField]
    private LayerMask layerMaskHurt;*/
    [SerializeField]
    private LayerMask layerMaskGround, layerMaskInteract;
    private List<GameObject> listRespawObj = new List<GameObject>();

    private void Awake()
    {
        repositoryX = this;
    }

    // Start is called before the first frame update

    /*public GameObject GetBallonsTalk()
    {
        GameObject b = listRespawObj.Find(x => x.name == ballonsTalkBase.name && !x.activeInHierarchy);
        if (!b)
        {
            b = Instantiate(ballonsTalkBase.gameObject);
            b.name = ballonsTalkBase.name;
            b.gameObject.SetActive(false);
            listRespawObj.Add(b);
        }

        return b;
    }*/

    /*public LayerMask GetLayerMaskHurt()
    {
        return layerMaskHurt;
    }*/

    /*public BoxCollider2D GetHitCharsColl()
    {
        return hitCollChars;
    }*/

    public LayerMask GetLayerMaskGround()
    {
        return layerMaskGround;
    }

    public LayerMask GetLayerMaskInteract()
    {
        return layerMaskInteract;
    }

    /*public AudioClip GetClipDash()
    {
        return clipDash;
    }*/

    /*public void AddPower(powerBase pw)
    {
        if (!listRespawObj.Exists(x => x.name == pw.name))
        {
            for (int i = 0; i < 16; i++)
            {
                GameObject power = Instantiate(pw.gameObject);
                power.gameObject.SetActive(false);
                power.name = pw.name;
                power.transform.SetParent(transform);
                listRespawObj.Add(power);
            }
        }
    }*/

    public List<GameObject> GetListObjs(string name)
    {
        return listRespawObj.FindAll(x => x.name == name);
    }

    public void AddResapwObj(GameObject obj)
    {
        if (!listRespawObj.Exists(x => x.name == obj.name))
        {
            for (int i = 0; i < 32; i++)
            {
                GameObject objX = Instantiate(obj);
                objX.name = obj.name;
                objX.SetActive(false);
                objX.transform.SetParent(transform);
                listRespawObj.Add(objX);
            }
        }
    }

    public GameObject GetRespawObj(GameObject obj)
    {
        GameObject objX = listRespawObj.Find(x => x.name == obj.name && !x.activeInHierarchy);

        if (!objX)
        {
            for (int i = 0; i < 16; i++)
            {
                objX = Instantiate(obj);
                objX.name = obj.name;
                objX.SetActive(false);
                objX.transform.SetParent(transform);
                listRespawObj.Add(objX);
            }
        }

        return objX;
    }

   /* public GameObject Getonomatopoeia()
    {
        return GetRespawObj(onomatopoeiaBase);
    }*/
}
