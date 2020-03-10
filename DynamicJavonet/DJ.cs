using JavaBridges.Api.PrimitiveTypes;
using JavonetBridge;
using JavonetBridge.Api;

namespace DynamicJavonet
{
    public static class DJ
    {
        /// <summary>
        /// Auto convert int, long, short, bool to primitive and vise versa
        /// </summary>
        public static bool PreferPrimitive { get; set; } = true;

        public static DJObject New(string name) => Javonet.New(name).ToDJ();
        public static DJObject New(string name, params object[] paras) => Javonet.New(name, paras.AsParameters()).ToDJ();
        public static DJType Type(string name) => Javonet.GetType(name).ToDJ();

        public static DJObject ToDJ(this JObject obj)
        {
            return new DJObject(obj);
        }

        public static DJType ToDJ(this JType type)
        {
            return new DJType(type);
        }

        public static JPrimitive GetJPrimitiveArray<T>(T[] array)
        {
            //bugs here, contact Javonet for a fix or let's talk how to workaround
            return new JPrimitive(array);
        }

        internal static object[] AsParameters(this object[] args)
        {
            //args.Select(a => a.AsParameter()).ToArray()
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].AsParameter();
            }

            return args;
        }

        internal static object AsParameter(this object obj)
        {
            if (PreferPrimitive)
            {
                switch (obj)
                {
                    //Primitives
                    case int i: return new JPrimitive(i);
                    case short s: return new JPrimitive(s);
                    case long l: return new JPrimitive(l);
                    case bool b: return new JPrimitive(b);
                    case float f: return new JPrimitive(f);
                    case double d: return new JPrimitive(d);
                    //Primitive Arrays
                    case int[] ia: return GetJPrimitiveArray(ia);
                    case short[] sa: return GetJPrimitiveArray(sa);
                    case long[] la: return GetJPrimitiveArray(la);
                    case bool[] ba: return GetJPrimitiveArray(ba);
                    case float[] fa: return GetJPrimitiveArray(fa);
                    case double[] da: return GetJPrimitiveArray(da);
                    case JPrimitive jp: return jp.GetValue();
                    case DJObject djo: return djo.JObject;
                    case DJType djt: return djt.JType;
                    default: return obj;
                }
            }
            else
            {
                switch (obj)
                {
                    case DJObject djo: return djo.JObject;
                    case DJType djt: return djt.JType;
                    default: return obj;
                }
            }
        }

        internal static object ToDJ(this object obj)
        {
            if (obj is JObject jo)
            {
                return new DJObject(jo);
            }
            else if (obj is JType jt)
            {
                return new DJType(jt);
            }

            return obj;
        }
    }
}