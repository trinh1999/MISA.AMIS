using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces.Repository;
using MISA.ApplicationCore.MISAAttribute;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructor.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity:BaseEntity
    {
        //Truy cập vào database
        //1. Khởi tạo thông tin kết nối database
        #region DEC
        protected IDbConnection _dbConnection;
        public readonly string _connectionString;
        string _tagName;
        #endregion

        #region Contructor
        public BaseRepository(IConfiguration configuration)
        {
            _tagName = typeof(TEntity).Name;
            _connectionString = configuration.GetConnectionString("AMISDatabase");
        }

        #endregion
        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Trả về số bản ghi được thêm</returns>
        /// CreateBy: DTTrinh
        public int Add(TEntity entity)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();
            //Khai báo dyanamicParam:
            var dyanamicParam = new DynamicParameters();

            //3. Thêm dữ liệu vào trong database
            var columnsName = string.Empty;

            var columnsParam = string.Empty;

            //Đọc từng property của object:
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                //Lấy tên của prop:
                var propName = prop.Name;

                if (!prop.IsDefined(typeof(MISANotMap), true))
                {
                    //Lấy value của prop
                    var propValue = prop.GetValue(entity);
                    if (propName == $"{_tagName}Id")
                    {
                        propValue = Guid.NewGuid();
                    }
                    //Lấy kiểu dữ liệu của prop
                    var propType = prop.PropertyType;

                    //Thêm param tương ứng với mỗi property của đối tượng
                    dyanamicParam.Add($"@{propName}", propValue);

                    columnsName += $"{propName},";

                    columnsParam += $"@{propName},";
                }
            }

            columnsName = columnsName.Remove(columnsName.Length - 1, 1);

            columnsParam = columnsParam.Remove(columnsParam.Length - 1, 1);

            var sqlCommand = $"INSERT INTO {_tagName}({columnsName}) VALUES ({columnsParam})";
            var rowEffects = _dbConnection.Execute(sqlCommand, param: dyanamicParam);
            //var rowEffects = _dbConnection.Execute("Proc_InsertEmployee", param: dyanamicParam, commandType: CommandType.StoredProcedure);

            return rowEffects;
        }

        /// <summary>
        /// Xóa bản ghi     
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>Số bản ghi đã xóa</returns>
        ///  CreateBy: DTTrinh
        public int Delete(Guid entityId)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();

            //3. Lấy dữ liệu
            var sqlCommand = $"DELETE FROM {_tagName} WHERE {_tagName}Id= @{_tagName}IdParam";

            //De trach loi SQL Injection           
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add($"@{_tagName}IdParam", entityId);

            var rowEffects = _dbConnection.Execute(sqlCommand, param: parameters);
            return rowEffects;
        }

        /// <summary>
        /// Hàm get ra danh sách
        /// </summary>
        /// <returns>List danh sách</returns>
        ///  CreateBy: DTTrinh
        public IEnumerable<TEntity> Get()
        {

            //2. Khởi tạo đối tượng kết nối với database
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();

            ////3. Lấy dữ liệu
            var sqlCommand = $"SELECT * FROM {_tagName}";
            var entities = _dbConnection.Query<TEntity>(sqlCommand);

            // 3.Khởi tạo các commandText
            //var entities = _dbConnection.Query<TEntity>(sql, commandType: CommandType.StoredProcedure);

            //4. Trả về cho client
            return entities;
        }

        /// <summary>
        /// Lọc bản ghi theo tên thuộc tính và giá trị thuộc tính 
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="property">Tên thuộc tính</param>
        /// <returns>Bản ghi nào có thuộc tính bằng giá trị đã cho</returns>
        /// CreateBy: DTTrinh
        public TEntity GetByProp(TEntity entity, PropertyInfo property)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();
            var propName = property.Name;
            var keyValue = entity.GetType().GetProperty($"{_tagName}Id").GetValue(entity);
            var propValue = entity.GetType().GetProperty(propName).GetValue(entity);
            var query = string.Empty;
            if(entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT * FROM {_tagName} WHERE {propName} = '{propValue}'";
            }
            else if(entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {_tagName} WHERE {propName} = '{propValue}' AND {_tagName}Id <> '{keyValue}'";

            }
            else
            {
                return null;
            }
            //chỉ cần tìm được 1 object trùng với thuộc tính  nên dùng FirstOrDefault
            var res = _dbConnection.QueryFirstOrDefault<TEntity>(query, commandType: CommandType.Text) ;
            return res;
        }
        /// <summary>
        /// Lọc theo id bản ghi
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// CreateBy: DTTrinh
        public TEntity GetById(Guid entityId)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();

            var sqlCommand = $"SELECT * FROM {_tagName} WHERE {_tagName}Id= @{_tagName}IdParam";

            //De trach loi SQL Injection           
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add($"@{_tagName}IdParam", entityId);

            var res = _dbConnection.QueryFirstOrDefault<TEntity>(sqlCommand, param: parameters);

            //var res = _dbConnection.Query<TEntity>($"Proc_Get{_tagName}ById", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        /// <summary>
        /// Cập nhật bản ghih
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Update(TEntity entity, Guid entityId)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();

            //Khai báo dyanamicParam:
            var dyanamicParam = new DynamicParameters();

            //3. Thêm dữ liệu vào trong database
            var columnsUpadateParam = string.Empty;

            //Đọc từng property của object:         
            var properties = entity.GetType().GetProperties();
             
            foreach (var prop in properties)
            {
                //Lấy tên của prop:
                var propName = prop.Name;

                if (!prop.IsDefined(typeof(MISANotMap), true)){
                    //Lấy value của prop
                    var propValue = prop.GetValue(entity);

                    //Lấy kiểu dữ liệu của prop
                    var propType = prop.PropertyType;

                    //Thêm param tương ứng với mỗi property của đối tượng
                    dyanamicParam.Add($"@{propName}", propValue);

                    columnsUpadateParam += $"{propName} = @{ propName} ,";
                }
            }
            columnsUpadateParam = columnsUpadateParam.Remove(columnsUpadateParam.Length - 1, 1);

            var sqlCommand = $"UPDATE {_tagName} SET {columnsUpadateParam} WHERE {_tagName}Id = @{_tagName}Id";
            dyanamicParam.Add($"@{_tagName}Id", entityId);

            var rowEffects = _dbConnection.Execute(sqlCommand, param: dyanamicParam);
            return rowEffects;
        }

        /// <summary>
        /// Dong ket noi
        /// </summary>
        ///  CreateBy: DTTrinh
        public void Dispose()
        {
           if(_dbConnection != null && _dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

       
    }
}
