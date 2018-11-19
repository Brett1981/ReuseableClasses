using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using PropertyAttributes = System.Reflection.PropertyAttributes;

namespace Re_useable_Classes.Converters
{
    public static class DataTableToList
    {
        /// <summary>
        ///     Convert a database data table to a runtime dynamic definied type collection (dynamic class' name as table name).
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static List<dynamic> ToDynamicList
            (
            DataTable dt,
            string className)
        {
            return ToDynamicList
                (
                    ToDictionary(dt),
                    GetNewObject
                        (
                            dt.Columns,
                            className));
        }

        private static List<Dictionary<string, object>> ToDictionary(DataTable dt)
        {
            IEnumerable<DataColumn> columns = dt.Columns.Cast<DataColumn>();
            List<Dictionary<string, object>> temp = dt.AsEnumerable()
                                                      .Select
                (
                    dataRow => columns.Select
                                   (
                                       column =>
                                       new
                                       {
                                           Column = column.ColumnName,
                                           Value = dataRow[column]
                                       })
                                      .ToDictionary
                                   (
                                       data => data.Column,
                                       data => data.Value))
                                                      .ToList();
            return temp.ToList();
        }

        private static List<dynamic> ToDynamicList
            (
            List<Dictionary<string, object>> list,
            Type typeObj)
        {
            dynamic temp = new List<dynamic>();
            foreach (var step in list)
            {
                object obj = Activator.CreateInstance(typeObj);

                PropertyInfo[] properties = obj.GetType()
                                               .GetProperties();

                Dictionary<string, object> dictList = step;

                foreach (var keyValuePair in dictList)
                {
                    KeyValuePair<string, object> pair = keyValuePair;
                    foreach (PropertyInfo property in properties.Where(property => property.Name == pair.Key))
                    {
                        if (keyValuePair.Value != null && keyValuePair.Value.GetType() != typeof(DBNull))
                        {
                            if (keyValuePair.Value is Guid)
                            {
                                property.SetValue
                                    (
                                        obj,
                                        keyValuePair.Value,
                                        null);
                            }
                            else
                            {
                                property.SetValue
                                    (
                                        obj,
                                        keyValuePair.Value,
                                        null);
                            }
                        }
                        break;
                    }
                }
                temp.Add(obj);
            }
            return temp;
        }

        private static Type GetNewObject
            (
            DataColumnCollection columns,
            string className)
        {
            var assemblyName = new AssemblyName
                               {
                                   Name = "YourAssembly"
                               };
            AssemblyBuilder assemblyBuilder = Thread.GetDomain()
                                                    .DefineDynamicAssembly
                (
                    assemblyName,
                    AssemblyBuilderAccess.Run);
            ModuleBuilder module = assemblyBuilder.DefineDynamicModule("YourDynamicModule");
            TypeBuilder typeBuilder = module.DefineType
                (
                    className,
                    TypeAttributes.Public);

            foreach (DataColumn column in columns)
            {
                string propertyName = column.ColumnName;
                FieldBuilder field = typeBuilder.DefineField
                    (
                        propertyName,
                        column.DataType,
                        FieldAttributes.Public);
                PropertyBuilder property = typeBuilder.DefineProperty
                    (
                        propertyName,
                        PropertyAttributes.None,
                        column.DataType,
                        new[]
                        {
                            column.DataType
                        });
                const MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
                MethodBuilder currGetPropMthdBldr = typeBuilder.DefineMethod
                    (
                        "get_value",
                        getSetAttr,
                        column.DataType,
                        new[]
                        {
                            column.DataType
                        }); // Type.EmptyTypes);
                ILGenerator currGetIl = currGetPropMthdBldr.GetILGenerator();
                currGetIl.Emit(OpCodes.Ldarg_0);
                currGetIl.Emit
                    (
                        OpCodes.Ldfld,
                        field);
                currGetIl.Emit(OpCodes.Ret);
                MethodBuilder currSetPropMthdBldr = typeBuilder.DefineMethod
                    (
                        "set_value",
                        getSetAttr,
                        null,
                        new[]
                        {
                            column.DataType
                        });
                ILGenerator currSetIl = currSetPropMthdBldr.GetILGenerator();
                currSetIl.Emit(OpCodes.Ldarg_0);
                currSetIl.Emit(OpCodes.Ldarg_1);
                currSetIl.Emit
                    (
                        OpCodes.Stfld,
                        field);
                currSetIl.Emit(OpCodes.Ret);
                property.SetGetMethod(currGetPropMthdBldr);
                property.SetSetMethod(currSetPropMthdBldr);
            }
            Type obj = typeBuilder.CreateType();
            return obj;
        }
    }
}