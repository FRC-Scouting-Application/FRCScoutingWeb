using Microsoft.EntityFrameworkCore;
using Models.Dbo.Bases;
using Models.Dbo.Interfaces;

namespace FRCScouting_API.Helpers
{
    public static class EFHelper
    {
        private enum Action
        {
            Add,
            Update,
            None
        }

        /// <summary>
        /// Add or Update an entity to the database
        /// </summary>
        /// <typeparam name="TEntity">Enity Type (Must extend from DboBase, and implement INeedsUpdate and IKey</typeparam>
        /// <typeparam name="TKey">Type of key used for this entity (string, int, etc.)</typeparam>
        /// <param name="set">Database set to be read and modified</param>
        /// <param name="entity">Entity to add/update in the database</param>
        public static async void AddUpdate<TEntity, TKey>(DbSet<TEntity> set, TEntity entity) where TEntity : DboBase, INeedsUpdate<TEntity>, IKey<TKey>
        {
            if (entity == null)
                return;

            List<TEntity> dbItems = set.ToList();
            Action action = GetAction<TEntity, TKey>(dbItems, entity);

            if (action == Action.Add)
                await set.AddAsync(entity);
            else if (action == Action.Update)
                set.Update(entity);
        }

        /// <summary>
        /// Add or Update a range of enties to the database
        /// </summary>
        /// <typeparam name="TEntity">Enity Type (Must extend from DboBase, and implement INeedsUpdate and IKey</typeparam>
        /// <typeparam name="TKey">Type of key used for this entity (string, int, etc.)</typeparam>
        /// <param name="set">Database set to be read and modified</param>
        /// <param name="entities">List of entites to add/update in the database</param>
        public static async void AddUpdateRange<TEntity, TKey>(DbSet<TEntity> set, IEnumerable<TEntity> entities) where TEntity : DboBase, INeedsUpdate<TEntity>, IKey<TKey>
        {
            if (entities == null || !entities.Any())
                return;

            List<TEntity> dbItems = set.ToList();
            Stack<TEntity> entitiesStack = new(entities);

            List<TEntity> add = new();
            List<TEntity> update = new();

            while (entitiesStack.Count > 0)
            {
                TEntity entity = entitiesStack.Pop();
                Action action = GetAction<TEntity, TKey>(dbItems, entity);

                if (action == Action.Add)
                    add.Add(entity);
                else if (action == Action.Update)
                    update.Add(entity);
            }

            await set.AddRangeAsync(add);
            set.UpdateRange(update);
        }

        /// <summary>
        /// Get the action to be applied on to the entity (Add, Update, None)
        /// </summary>
        /// <typeparam name="TEntity">Enity Type (Must extend from DboBase, and implement INeedsUpdate and IKey</typeparam>
        /// <typeparam name="TKey">Type of key used for this entity (string, int, etc.)</typeparam>
        /// <param name="dbItems">Database set to be read and modified</param>
        /// <param name="entity">List of entites to add/update in the database</param>
        /// <returns>Action to be applied to this entity</returns>
        private static Action GetAction<TEntity, TKey>(List<TEntity> dbItems, TEntity entity) where TEntity : DboBase, INeedsUpdate<TEntity>, IKey<TKey>
        {
            if (!dbItems.Any())
                return Action.Add;

            TEntity? existing = null;

            var existingItems = dbItems.Where(i =>
            {
                if (i.Id == null)
                    return false;
                return i.Id.Equals(entity.Id);
            });

            if (dbItems.Any())
                existing = existingItems.FirstOrDefault();

            if (existing == null)
                return Action.Add;
            else if (existing.NeedsUpdate(entity))
                return Action.Update;
            else
                return Action.None;
        }

    }
}
