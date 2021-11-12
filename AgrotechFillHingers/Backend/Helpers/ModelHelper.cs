using AgrotechFillHingers.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Helpers
{
    public class ModelHelper<T> where T : IModel
    {
        protected List<T> listModels = new List<T>();

        private enum FormatType : int
        {
            FromDatabase = 0,
            ToDatabase = 1
        }

        public ModelHelper(T _model)
        {
            listModels.Add(_model);
        }

        public ModelHelper(List<T> _modelsList)
        {
            listModels = _modelsList;
        }

        public T SingleParseAttribyteToDb()
        {
            return ParseAttributes(listModels.First(), FormatType.ToDatabase);
        }

        public T SingleParseAttribyteFromDb()
        {
            return ParseAttributes(listModels.First(), FormatType.FromDatabase);
        }

        public List<T> ListParseAttribyteToDb()
        {
            listModels.ForEach(model => ParseAttributes(model, FormatType.ToDatabase));
            return listModels;
        }
        public List<T> ListParseAttribyteFromDb()
        {
            listModels.ForEach(model => ParseAttributes(model, FormatType.FromDatabase));
            return listModels;
        }

        private T ParseAttributes(T model, FormatType formatType)
        {
            string dbFormat = "MM/dd/yyyy HH:mm:ss";
            if (model == null) return model;
            foreach (PropertyInfo prop in model.GetType().GetProperties())
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DbTypeAttribute dbAttr = attr as DbTypeAttribute;
                    if (dbAttr != null)
                    {
                        if (dbAttr.type == typeof(DateTime) && prop.GetValue(model) != null)
                        {
                            string attrFormat = string.IsNullOrWhiteSpace(dbAttr.format) ? "yyyy-MM-dd HH:mm:ss" : dbAttr.format;

                            DateTime dateTime = DateTime.ParseExact(prop.GetValue(model).ToString(), formatType == FormatType.FromDatabase ? dbFormat : attrFormat, CultureInfo.InvariantCulture);
                            prop.SetValue(model, dateTime.ToString(formatType == FormatType.FromDatabase ? attrFormat : dbFormat));
                        }
                    }
                }
            }

            return model;
        }
    }
}
