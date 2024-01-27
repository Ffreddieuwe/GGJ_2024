using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudioController : MonoBehaviour
{

    public Transform ToesEnd_L;
    public Material[] checkMaterials;
    public AudioClip[] clips;
    AudioSource audioSource;
    Mesh mesh;
    RaycastHit hit;
    Material hitMaterial;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(ToesEnd_L.position, Vector3.down, Color.red);
        if (Physics.Raycast(ToesEnd_L.position, Vector3.down, out hit))
        {
            MeshCollider meshCollider = hit.collider as MeshCollider;
            Renderer renderer = hit.transform.GetComponent<Renderer>();

            if (meshCollider)
            {
                mesh = meshCollider.sharedMesh;

                int[] hitTriangle = new int[]
                {
                    mesh.triangles[hit.triangleIndex * 3 + 0],
                    mesh.triangles[hit.triangleIndex * 3 + 1],
                    mesh.triangles[hit.triangleIndex * 3 + 2],
                };

                for (int i = 0; i < mesh.subMeshCount; i++)
                {
                    int[] subMeshTriangles = mesh.GetTriangles(i);
                    for (int j = 0; j < subMeshTriangles.Length; j += 3)
                    {
                        if (subMeshTriangles[j + 0] == hitTriangle[0] && subMeshTriangles[j + 1] == hitTriangle[1] && subMeshTriangles[j + 2] == hitTriangle[2])
                        {
                            hitMaterial = renderer.materials[i];
                        }

                    }
                }
            }
        }

        for (int i = 0; i < checkMaterials.Length; i++)
        {
            if (hitMaterial.name.Contains(checkMaterials[i].name))
            {
                if (audioSource.isPlaying)
                {
                    return;
                }
                audioSource.clip = clips[i];
                audioSource.Play();
            }
        }
    }

}
