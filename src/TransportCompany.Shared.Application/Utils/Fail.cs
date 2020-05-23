using TransportCompany.Shared.Application.Exceptions;

namespace TransportCompany.Shared.Application.Utils
{
    public static class Fail
    {
        public static void IfNull<TEntity, TKey>(TEntity entity, TKey id)
        {
            if (entity == null)
            {
                throw new NotFoundEntityException($"No entity of type: {typeof(TEntity).Name} for key: {id}");
            }
        }

        public static void IfNull<TEntity, TParentEntity, TParentKey>(TEntity entity, TParentEntity parent,
            TParentKey parentId)
        {
            if (entity == null)
            {
                throw new NotFoundEntityException(
                    $"No requested entity of type: {typeof(TEntity).Name} found in " +
                    $"{typeof(TParentEntity).Name} for key: {parentId}");
            }
        }
    }
}
