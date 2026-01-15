namespace KANIYONIKA.ECSEventHelper
{
    using Unity.Burst;
    using Unity.Entities;

    [BurstCompile]
    public partial struct ECSEventHelper
    {
        [BurstCompile]
        public static void IssueEventFor<T>(
                ref EntityManager em,
                T EventData,
                SceneTag? SceneTag = null
            ) where T : unmanaged, IComponentData
        {
            var eventEntity = em.CreateEntity();
            em.SetName(eventEntity, "Event");
            em.AddComponentData(eventEntity, EventData);
            if (SceneTag.HasValue) { em.AddSharedComponent(eventEntity, SceneTag.Value); }
        }

        [BurstCompile]
        public static void IssueEventFor<T>(
                ref EntityCommandBuffer.ParallelWriter ecbPW,
                int chunkIndex,
                T EventData,
                SceneTag? SceneTag = null
            ) where T : unmanaged, IComponentData
        {
            var eventEntity = ecbPW.CreateEntity(chunkIndex);
            ecbPW.SetName(chunkIndex, eventEntity, "Event");
            ecbPW.AddComponent(chunkIndex, eventEntity, EventData);
            if (SceneTag.HasValue) { ecbPW.AddSharedComponent(chunkIndex, eventEntity, SceneTag.Value); }
        }


        [BurstCompile]
        public static void IssueEventFor<T>(
            ref EntityCommandBuffer ecb,
            T EventData,
            SceneTag? SceneTag = null
        ) where T : unmanaged, IComponentData
        {
            var eventEntity = ecb.CreateEntity();
            ecb.SetName(eventEntity, "Event");
            ecb.AddComponent(eventEntity, EventData);
            ecb.AddComponent(eventEntity, EventData);
            if (SceneTag.HasValue) { ecb.AddSharedComponent(eventEntity, SceneTag.Value); }
        }
    }
}
