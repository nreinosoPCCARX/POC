using System;
using System.Collections;
using System.Collections.Generic;
using WebEx.Interfaces.Models.Interfaces;

namespace WebEx.Interfaces.Models.Base
{
    public abstract class DomainBase : IDomain
    {
        protected DomainBase() { }

        public long Id { get; set; }

        public object Clone()
        {
            var copiedObject = Activator.CreateInstance(GetType());

            foreach (var propInfo in GetType().GetProperties())
            {
                var currentPropertyValue = propInfo.GetValue(this);
                var currentPropertyValueAsICloneable = currentPropertyValue as ICloneable;
                if (currentPropertyValueAsICloneable != null)
                {
                    if (propInfo.CanWrite && propInfo.GetSetMethod(true).IsPublic)
                    {
                        propInfo.SetValue(copiedObject,
                        Convert.ChangeType(currentPropertyValueAsICloneable.Clone(), propInfo.PropertyType));
                    }
                }
                else if (currentPropertyValue is IEnumerable<ICloneable>)
                {
                    var listTypes = currentPropertyValue.GetType().GetGenericArguments();
                    if (listTypes.Length < 1) continue;
                    var listType = listTypes[0];
                    var genericListType = typeof(List<>).MakeGenericType(listType);
                    var copiedList = (IList)Activator.CreateInstance(genericListType);
                    var currentPropertyValueAsIEnumerable = currentPropertyValue as IEnumerable<ICloneable>;

                    foreach (var domain in currentPropertyValueAsIEnumerable)
                    {
                        copiedList.Add(domain.Clone());
                    }

                    if (propInfo.CanWrite && propInfo.GetSetMethod(true).IsPublic)
                    {
                        // The setter exists and is public.
                        propInfo.SetValue(copiedObject, copiedList);
                    }
                }
                else
                {
                    if (propInfo.CanWrite && propInfo.GetSetMethod(true).IsPublic)
                    {
                        // The setter exists and is public.
                        propInfo.SetValue(copiedObject, currentPropertyValue);
                    }
                }
            }

            return copiedObject;
        }
    }
}
