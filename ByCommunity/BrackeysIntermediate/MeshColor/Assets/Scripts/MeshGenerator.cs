using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;
    Color[] colors;

    float minTerrainHeight;
    float maxTerrainHeight;

    public int xSize = 20;
    public int zSize = 20;
    public Texture2D texture;

    public Gradient gradient;

    public Vector3 scaleNoise = new Vector3(.3f, 2f, .3f);

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        StartCoroutine(CreateMesh());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(CreateMesh());
        }
    }

    IEnumerator CreateMesh()
    {
        // Creating vertices
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for(int i = 0, z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * scaleNoise.x, z * scaleNoise.z) * scaleNoise.y;
                vertices[i] = new Vector3(x, y, z);

                if(i == 0)
                {
                    minTerrainHeight = y;
                    maxTerrainHeight = y;
                }

                if (y < minTerrainHeight)
                    minTerrainHeight = y;
                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;

                i++;
            }
        }
         
        // Creating UV

        /*uvs = new Vector2[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }*/

        // Coloring (Vertex Color)

        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }

        // Creating triangles
        triangles = new int[xSize * zSize * 6];

        int tris = 0;
        int verts = 0;

        for(int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                // Triangles
                triangles[tris + 0] = verts + 0;
                triangles[tris + 1] = verts + xSize + 1;
                triangles[tris + 2] = verts + 1;
                triangles[tris + 3] = verts + 1;
                triangles[tris + 4] = verts + xSize + 1;
                triangles[tris + 5] = verts + xSize + 2;

                verts++;
                tris += 6;
                UpdateMesh();
                yield return null;
            }
            verts++;
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.uv = uvs;
        mesh.colors = colors;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

}
