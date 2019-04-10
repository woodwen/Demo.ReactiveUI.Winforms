namespace Demo.ReactiveUI.Winforms.Bindings.BindingTypeConverter
{
    using global::ReactiveUI;
    using System;

    public class DateTimeFileTimeConverter : IBindingTypeConverter
    {
        #region Methods

        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            return (fromType == typeof(DateTime) && toType == typeof(long)) ||
                (toType == typeof(DateTime) && fromType == typeof(long)) ? 4 : -1;
        }

        public bool TryConvert(object from, Type toType, object conversionHint, out object result)
        {
            result = null;

            if (from.GetType() == typeof(DateTime) && toType == typeof(long))
            {
                var dt = (DateTime)from;
                result = dt.ToFileTime();
                return true;
            }
            else if (from.GetType() == typeof(long) && toType == typeof(DateTime))
            {
                var dt = (long)from;
                result = DateTime.FromFileTime(dt);
                return true;
            }

            return false;
        }

        #endregion Methods
    }
}