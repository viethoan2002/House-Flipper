using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] MeshRenderer m_Renderer;
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshCollider _col;
    Material[] mats;
    [SerializeField] private Outline outline;

    [Space(30)]
    [SerializeField] private bool _canDestroy;

    public void Build(Vector3 _pos, Quaternion _ro)
    {
        transform.position = _pos;
        transform.rotation = _ro;
    }

    public void ActiveOutline(bool _active)
    {
        outline.enabled = _active;
    }

    public bool CanDestroy()
    {
        return _canDestroy;
    }

    public int GetSubMeshIndex(int triangleIndex)
    {
        if (!meshFilter.mesh) return 0;

        int triangleCounter = 0;
        for (int subMeshIndex = 0; subMeshIndex < meshFilter.mesh.subMeshCount; subMeshIndex++)
        {
            var indexCount = meshFilter.mesh.GetSubMesh(subMeshIndex).indexCount;
            triangleCounter += indexCount / 3;
            if (triangleIndex < triangleCounter)
            {
                return subMeshIndex;
            }
        }

        return 0;
    }

    public void PaintWall(Material _mar,int _index)
    {
        mats = m_Renderer.materials;
        mats[GetSubMeshIndex(_index)] = _mar;
        m_Renderer.materials = mats;
    }

    public void EnableConvert(bool _enable)
    {
        _col.convex = _enable;
    }
}
