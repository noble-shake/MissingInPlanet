using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using System.Collections.Generic;

public class GridMapAuthoring : MonoBehaviour
{
    //[SerializeField] HashSet<Vector2> m_matrix;
    //[SerializeField] HashSet<Vector2> b_matrix;
    [SerializeField] int GridSizeX;
    [SerializeField] int GridSizeY;
    [SerializeField] GameObject GeoBlock;

    public class SubBaker : Baker<GridMapAuthoring>
    {
        public override void Bake(GridMapAuthoring authoring)
        {
            Dictionary<Vector2, int> tempFloors = new Dictionary<Vector2, int>();
            Dictionary<Vector2, bool> tempBlocks = new Dictionary<Vector2, bool>();

            //TODO: GeoMetry Creation Detail
            for (int i = 0; i < authoring.GridSizeX; i++)
            {
                for (int j = 0; j < authoring.GridSizeY; j++)
                {
                    tempFloors[new Vector2(i, j)] = UnityEngine.Random.Range(-1, 3);
                    tempBlocks[new Vector2(i, j)] = UnityEngine.Random.Range(0f, 1f) >= 0.25f ? true : false;
                }
            }

            var entity = GetEntity(TransformUsageFlags.WorldSpace); // must be in WorldSpace
            AddComponentObject<GridMap>(entity, new GridMap() { Floors = tempFloors, Blocks =tempBlocks });
            AddComponent<GridTag>(entity);
            AddComponent<GridMapTag>(entity);
            AddComponent<GeoBlockComponent>(entity, new GeoBlockComponent() { GeoBlockPrefab = GetEntity(authoring.GeoBlock, TransformUsageFlags.Dynamic) });
        }
    }
}


//public struct GridMatrixComponent : IComponentData
//{
//    // position : x, y, z, bool
//    // 4 floor : 0, 1, 2, 3
//    public Matrix4x4 matrix;
//}
public class GridMap : IComponentData 
{
    public Dictionary<Vector2, int> Floors;
    public Dictionary<Vector2, bool> Blocks;
}

public struct GridTag : IComponentData { }
public struct GridMapTag : IComponentData { }
public struct GeoBlockComponent : IComponentData
{
    public Entity GeoBlockPrefab;
}
