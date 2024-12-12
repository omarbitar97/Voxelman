using Unity.Entities;
using UnityEngine;

public class VoxelPrefabAuthoring : MonoBehaviour
{
    class Baker : Baker<VoxelPrefabAuthoring>
    {
        public override void Bake(VoxelPrefabAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PrefabTag());
        }
    }
}

public struct PrefabTag : IComponentData { }
