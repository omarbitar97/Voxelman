using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class VoxelPoolSystem : SystemBase
{
    private NativeQueue<Entity> _voxelPool;

    protected override void OnCreate()
    {
        // Initialize the pool with capacity
        _voxelPool = new NativeQueue<Entity>(Allocator.Persistent);
    }

    protected override void OnDestroy()
    {
        // Dispose of the pool when the system is destroyed
        _voxelPool.Dispose();
    }

    protected override void OnUpdate()
    {
        // Example: Check if we need more voxels or reset existing ones
    }

    // Get a voxel from the pool or create a new one if none are available
    public Entity GetVoxel(Entity prefab, float3 position, quaternion rotation, float scale)
    {
        Entity voxel;

        if (_voxelPool.TryDequeue(out voxel))
        {
            // Reset the voxel's transform
            EntityManager.SetComponentData(voxel, new LocalTransform
            {
                Position = position,
                Rotation = rotation,
                Scale = scale
            });
        }
        else
        {
            // Instantiate a new voxel if the pool is empty
            voxel = EntityManager.Instantiate(prefab);
            EntityManager.SetComponentData(voxel, new LocalTransform
            {
                Position = position,
                Rotation = rotation,
                Scale = scale
            });
        }

        return voxel;
    }

    // Return a voxel to the pool
    public void ReturnVoxel(Entity voxel)
    {
        // Disable the voxel before pooling (optional: set inactive components)
        _voxelPool.Enqueue(voxel);
    }
}
