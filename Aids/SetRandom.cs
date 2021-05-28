﻿using System;
using System.Collections;
using System.Linq;
namespace MuscleCarRentProject.Aids {
    public static class SetRandom {

        public static void Values(object o) {
            if (o is null) return;
            if (o is IList list) setValuesForList(list);
            else setValuesForProperties(o);
        }
        private static void setValuesForProperties(object o) {
            if (o is null) return;
            var t = o.GetType();
            var properties = t.GetProperties();
            foreach (var p in properties) {
                if (!p.CanWrite) continue;
                if (p.PropertyType.Name == t.Name) continue;
                var v = GetRandom.ValueOf(p.PropertyType);
                p.SetValue(o, v);
            }
        }

        private static void setValuesForList(IList l) {
            if (l is null) return;
            var t = getListElementsType(l);
            for (var c = 0; c <= GetRandom.UInt8(3, 5); c++) {
                var v = GetRandom.ValueOf(t);
                l.Add(v);
            }
        }
        private static Type getListElementsType(IList list)
            => Safe.Run(
                () => {
                    var t = list.GetType();
                    var types =
                    (
                        from method in t.GetMethods()
                        where method.Name == "get_Item"
                        select method.ReturnType
                    ).Distinct().ToArray();
                    return types[0];
                }, default);
    }
}
