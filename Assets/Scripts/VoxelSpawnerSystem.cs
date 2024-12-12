using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class VoxelSpawnerSystem : SystemBase
{
    private VoxelPoolSystem _voxelPoolSystem;
    private Entity _voxelPrefab;

    protected override void OnCreate()
    {
        base.OnCreate();

        // Get the VoxelPoolSystem instance
        _voxelPoolSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<VoxelPoolSystem>();

        // Assign your voxel prefab (replace with the correct prefab reference)
        _voxelPrefab = GetSingleton<Voxelizer>().Prefab; // Example, adjust as needed
    }

    protected override void OnUpdate()
    {
        // Spawn a voxel at a specific position
        var spawnPosition = new float3(0, 0, 0); // Example position
        var voxelScale = 1f; // Example scale

        var spawnedVoxel = _voxelPoolSystem.GetVoxel(
            prefab: _voxelPrefab,
            position: spawnPosition,
            rotation: quaternion.identity,
            scale: voxelScale
        );
        
        // Example: Logic for returning a voxel to the pool
        // (For now, you might not return it immediately; add return logic based on your use case)
    }
}

