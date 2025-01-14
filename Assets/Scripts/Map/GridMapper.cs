using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial class GridMapper : SystemBase
{

    protected override void OnCreate()
    {
        RequireForUpdate<GridMapTag>();
    }

    protected override void OnUpdate()
    {
        var entity = SystemAPI.GetSingletonEntity<GridMapTag>();
        var BlockEntity = SystemAPI.GetComponent<GeoBlockComponent>(entity);
        var mapper = SystemAPI.ManagedAPI.GetComponent<GridMap>(entity);

        foreach(Vector2 position in mapper.Floors.Keys)
        {
            int floor = mapper.Floors[position];
            bool block = mapper.Blocks[position];

            var bEntity = EntityManager.Instantiate(BlockEntity.GeoBlockPrefab, floor + 2,  Allocator.Persistent);

            int count = 0;
            foreach (var ent in bEntity)
            {
                
                var transform = SystemAPI.GetComponentRW<LocalTransform>(ent);
                transform.ValueRW.Position = new float3(position.x, count++, position.y);
                // MeshRenderer meshRenderer= SystemAPI.ManagedAPI.GetComponent<MeshRenderer>(ent);
                // float4 colorValue = GeoColorManager.GetColor((GeoColor)(floor + 1));
                // meshRenderer.material.color = new Color(colorValue.x, colorValue.y, colorValue.w, colorValue.z);
                

            }


            // bEntity Color Check.
        }
        


        this.EntityManager.RemoveComponent<GridMapTag>(entity);
        this.Enabled = false;
    }
}