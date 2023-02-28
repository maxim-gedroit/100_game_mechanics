using System.Collections.Generic;
using UnityEngine;

public class BridgeConstructor : MonoBehaviour
{
    [SerializeField] private Material _material;
    private List<Vector3> verticies = new List<Vector3>(); 
    private List<int> triangles = new List<int>();
    
    public void CreateBridge(Vector3Int[] blocks)
    {
        Mesh chunkMesh = new Mesh();
        GenerateBlock(blocks);

        chunkMesh.vertices = verticies.ToArray();
        chunkMesh.triangles = triangles.ToArray();
        chunkMesh.Optimize();
        chunkMesh.RecalculateBounds();
        chunkMesh.RecalculateNormals();
        
        var  meshRenderer = gameObject.GetComponent<MeshRenderer>();
        var meshFilter = gameObject.GetComponent<MeshFilter>();
        var meshCollider = gameObject.GetComponent<MeshCollider>();

        meshRenderer.sharedMaterial = _material;
        meshFilter.mesh = chunkMesh;
        meshCollider.sharedMesh = chunkMesh;
        

    }

    private void GenerateBlock(Vector3Int[] path)
    {
        
        for (int i = 0; i < path.Length; i++)
        {
            GenerateEntrySide(ParsePoints(path[i]),i);
            
            var nextPath = i + 1 == path.Length ? path[i] : path[i+1];
            
            GenerateBottomSide(ParsePoints(path[i]), ParsePoints(nextPath));
            GenerateLeftSide(ParsePoints(path[i]), ParsePoints(nextPath));
            GenerateRightSide(ParsePoints(path[i]), ParsePoints(nextPath));
            GenerateTopSide(ParsePoints(path[i]), ParsePoints(nextPath));
        }
    }

    private Vector3Int[] ParsePoints(Vector3Int point)
    {
        var y = point.y;
        var z = point.x;
        int x = 0;

        Vector3Int[] _array =
        {
            new Vector3Int(x,y,z),
            new Vector3Int(x+1,y,z),
            new Vector3Int(x+1,y+1,z),
            new Vector3Int(x,y+1,z)
        };

        return _array;
    }
    
    private void GenerateEntrySide(Vector3Int[] points, int index)
    {
        if (index != 0 && index != points.Length)
        {
            verticies.Add(points[1]);
            verticies.Add(points[0]);
            verticies.Add(points[2]);
            verticies.Add(points[3]);
        }
        
        if (index == 0)
        {
            verticies.Add(points[1]);
            verticies.Add(points[0]);
            verticies.Add(points[2]);
            verticies.Add(points[3]);
            AddLastTriangles();
        }

        if (index == points.Length)
        {
            verticies.Add(points[3]);
            verticies.Add(points[0]);
            verticies.Add(points[2]);
            verticies.Add(points[1]);

            AddLastTriangles();
        }
        
    }
    
    private void GenerateBottomSide(Vector3Int[] points, Vector3Int[] pointsNext)
    {
        verticies.Add(points[0]);
        verticies.Add(points[1]);
        verticies.Add(pointsNext[0]);
        verticies.Add(pointsNext[1]);
        
        AddLastTriangles();
    }
    
    private void GenerateTopSide(Vector3Int[] points, Vector3Int[] pointsNext)
    {
        
        verticies.Add(points[2]);
        verticies.Add(points[3]);
        verticies.Add(pointsNext[2]);
        verticies.Add(pointsNext[3]);
        
        AddLastTriangles();
    }
    
    private void GenerateLeftSide(Vector3Int[] points, Vector3Int[] pointsNext)
    {
        verticies.Add(points[1]);
        verticies.Add(points[2]);
        verticies.Add(pointsNext[1]);
        verticies.Add(pointsNext[2]);
        
        AddLastTriangles();
    }
    
    private void GenerateRightSide(Vector3Int[] points, Vector3Int[] pointsNext)
    {
        verticies.Add(points[3]);
        verticies.Add(points[0]);
        verticies.Add(pointsNext[3]);
        verticies.Add(pointsNext[0]);
        
        
        AddLastTriangles();
    }
    
    private void GenerateFrontSide(Vector3Int[] points, Vector3Int[] pointsNext)
    {
        verticies.Add(points[0]);
        verticies.Add(points[1]);
        verticies.Add(pointsNext[0]);
        verticies.Add(pointsNext[1]);
        
        AddLastTriangles();
    }

    private void AddLastTriangles()
    {
        triangles.Add(verticies.Count - 4);
        triangles.Add(verticies.Count - 3);
        triangles.Add(verticies.Count - 2);

        triangles.Add(verticies.Count - 3);
        triangles.Add(verticies.Count - 1);
        triangles.Add(verticies.Count - 2);
    }
    
}