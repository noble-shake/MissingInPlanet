using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;

[RequireMatchingQueriesForUpdate]
public partial struct GridManager : ISystem
{
    EntityQuery query;

    public void OnCreate(ref SystemState state)
    {
        query = new EntityQueryBuilder(Allocator.Persistent)
            .WithAllRW<GridMap>()
            .WithAll<GridTag>()
            .WithNone<GridMapTag>()
            .Build(state.EntityManager);
    }

    public void OnUpdate(ref SystemState state)
    {


#if UNITY_EDITOR
        // renderer

#endif
    }
}