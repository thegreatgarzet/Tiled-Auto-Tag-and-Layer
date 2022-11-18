using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperTiled2Unity;
using System.Linq;

public class SetTagAndLayer : MonoBehaviour
{

    
    private void Awake()
    {
        Transform grid = transform.Find("Grid");
        
        foreach (Transform child in grid)
        {
            child.TryGetComponent<SuperCustomProperties>(out SuperCustomProperties props);
            if (props && props.m_Properties.Count!=0)
            {
                string tag = null;
                string layer = null;
                for (int i = 0; i < props.m_Properties.Count; i++)
                {
                    string value = props.m_Properties[i].m_Name;
                    if (value == "Tag" || value == "tag")
                    {
                        tag = props.m_Properties[i].m_Value;
                    }
                    if(value == "Layer" || value == "layer")
                    {
                        layer = props.m_Properties[i].m_Value;
                    }

                }
                
                Transform[] inner_childs = child.GetComponentsInChildren<Transform>();
                for (int i = 0; i < inner_childs.Length; i++)
                {
                    if (tag != null)
                    {
                        inner_childs[i].tag = tag;
                    }
                    if(layer != null)
                    {
                        inner_childs[i].gameObject.layer = LayerMask.NameToLayer(layer);
                    }
                }
            }
        }   
    }
}
