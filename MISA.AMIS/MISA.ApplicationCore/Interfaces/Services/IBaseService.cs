using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces.Services
{
    public interface IBaseService<TEntity>
    {
        #region Method

        /// <summary>
        /// Hiển thị danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        IEnumerable<TEntity> Get();

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="entity">Object nhân viên</param>
        /// <returns>ServiceResult</returns>
        ServiceResult Add(TEntity entity);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="entity">Object nhân viên</param>
        /// <param name="entityId">id nhân viên</param>
        /// <returns>ServiceResult</returns>
        ServiceResult Update(TEntity entity, Guid entityId);

        /// <summary>
        /// Xóa nhân viên theo id
        /// </summary>
        /// <param name="entityId">id nhân viên</param>
        /// <returns></returns>
        ServiceResult Delete(Guid entityId);

        /// <summary>
        /// Lọc nhân viên theo id
        /// </summary>
        /// <param name="entityId">id nhân viên</param>
        /// <returns>Object nhân viên</returns>
        TEntity GetById(Guid entityId);

        /// <summary>
        /// Tìm theo thuộc tính
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        /// <returns></returns>
        TEntity GetByProp(TEntity entity, PropertyInfo property);

        #endregion
    }
}
