using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Repository
{
    public interface IBaseRepository<TEntity>
    {
        #region METHOD
        /// <summary>
        /// Danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(TEntity entity);

        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        int Update(TEntity entity, Guid entityId);

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        int Delete(Guid entityId);

        /// <summary>
        /// Lọc theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        TEntity GetById(Guid entityId);
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        /// <returns></returns>
        TEntity GetByProp(TEntity entity, PropertyInfo property);
        #endregion
    }
}
